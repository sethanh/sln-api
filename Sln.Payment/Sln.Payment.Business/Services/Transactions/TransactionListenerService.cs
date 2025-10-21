using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using HtmlAgilityPack;

namespace Sln.Payment.Business.Services.Transactions
{
    public class TransactionListenerService
    {
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _listeners = new();

        // Cấu hình IMAP (ví dụ Gmail)
        private readonly string _imapHost = "imap.gmail.com";
        private readonly int _imapPort = 993;
        private readonly string _email = "thanhse123@gmail.com";
        private readonly string _appPassword = "qwmuvrmzxpfsjoxh";

        public void StartBackgroundListening(string key, int timeoutSeconds = 300)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));
            _listeners[key] = cts;

            _ = Task.Run(async () =>
            {
                try
                {
                    Console.WriteLine($"▶️ Listening for Vietcombank transaction ({key}) up to {timeoutSeconds}s...");

                    using var client = new ImapClient();
                    await client.ConnectAsync(_imapHost, _imapPort, true, cts.Token);
                    await client.AuthenticateAsync(_email, _appPassword, cts.Token);

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadOnly, cts.Token);

                    DateTime startTime = DateTime.UtcNow;
                    int checkInterval = 5;

                    while (!cts.Token.IsCancellationRequested)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(checkInterval), cts.Token);

                        // Lọc mail Vietcombank đến sau thời điểm bắt đầu
                        var query = SearchQuery.DeliveredAfter(startTime)
                            .And(SearchQuery.FromContains("vietcombank.com.vn"))
                            .And(SearchQuery.SubjectContains("Biên lai chuyển tiền"));

                        var results = await inbox.SearchAsync(query, cts.Token);
                        if (results?.Any() == true)
                        {
                            // Dùng Fetch để lấy metadata (ngày gửi + ngày nhận)
                            var summaries = await inbox.FetchAsync(
                                results,
                                MessageSummaryItems.Envelope | MessageSummaryItems.InternalDate,
                                cts.Token
                            );

                            foreach (var summary in summaries)
                            {
                                var sentTime = summary.Envelope?.Date?.LocalDateTime;
                                var receivedTime = summary.InternalDate?.LocalDateTime;

                                // Đọc nội dung email thực tế
                                var message = await inbox.GetMessageAsync(summary.UniqueId, cts.Token);

                                if (message.HtmlBody != null)
                                {
                                    var tx = ParseVietcombankMail(message.HtmlBody);
                                    if (tx != null)
                                    {
                                        // Gán thời gian gửi hoặc nhận
                                        tx.MailSentTime = sentTime ?? receivedTime;
                                        tx.MailReceivedTime = receivedTime;

                                        Console.WriteLine($"✅ Transaction detected for {key}:");
                                        Console.WriteLine($"   - Amount: {tx.Amount}");
                                        Console.WriteLine($"   - From: {tx.RemitterName}");
                                        Console.WriteLine($"   - Sent: {tx.MailSentTime:yyyy-MM-dd HH:mm:ss}");
                                        Console.WriteLine($"   - Received: {tx.MailReceivedTime:yyyy-MM-dd HH:mm:ss}");

                                        StopListening(key);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine($"⏹️ Listener for {key} canceled or timed out.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error in listener {key}: {ex.Message}");
                }
                finally
                {
                    _listeners.TryRemove(key, out _);
                }
            });
        }

        public void StopListening(string key)
        {
            if (_listeners.TryRemove(key, out var cts))
            {
                Console.WriteLine($"🛑 Stop listening for {key}");
                cts.Cancel();
                cts.Dispose();
            }
        }

        public List<string> GetActiveKeys() => _listeners.Keys.ToList();

        private static VietcombankTransaction? ParseVietcombankMail(string html)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                string? dateTime = GetCellValue(doc, "Ngày, giờ giao dịch");
                string? amount = GetCellValue(doc, "Số tiền");
                string? orderNo = GetCellValue(doc, "Số lệnh giao dịch");
                string? remitter = GetCellValue(doc, "Tên người chuyển tiền");
                string? content = GetCellValue(doc, "Nội dung chuyển tiền");

                if (amount != null && remitter != null)
                {
                    return new VietcombankTransaction
                    {
                        OrderNumber = orderNo,
                        Amount = amount,
                        RemitterName = remitter,
                        Description = content,
                        DateTime = dateTime
                    };
                }
            }
            catch { }

            return null;
        }

        private static string? GetCellValue(HtmlDocument doc, string label)
        {
            var td = doc.DocumentNode
                .SelectNodes("//td")
                ?.FirstOrDefault(x => x.InnerText.Contains(label, StringComparison.OrdinalIgnoreCase));

            if (td != null)
            {
                var nextTd = td.ParentNode.SelectSingleNode("td[2]") ?? td.ParentNode.SelectSingleNode("td[last()]");
                return nextTd?.InnerText.Trim();
            }

            return null;
        }

        private class VietcombankTransaction
        {
            public string? OrderNumber { get; set; }
            public string? Amount { get; set; }
            public string? RemitterName { get; set; }
            public string? Description { get; set; }
            public string? DateTime { get; set; }

            // 🕒 Thêm thời gian mail
            public DateTime? MailSentTime { get; set; }     // từ Envelope.Date
            public DateTime? MailReceivedTime { get; set; } // từ InternalDate
        }
    }
}
