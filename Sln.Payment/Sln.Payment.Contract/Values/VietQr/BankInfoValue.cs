using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Payment.Contract.Values.VietQr
{
    public class BankInfoValue
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Bin { get; set; }
        public string? ShortName { get; set; }
        public string? Logo { get; set; }
        public long TransferSupported { get; set; }
        public long LookupSupported { get; set; }
        public string? Short_name { get; set; }
        public long Support { get; set; }
        public long IsTransfer { get; set; }
        public string? Swift_code { get; set; }
    }
    
    public class BankInfoResponse
    {
        public string? Code { get; set; }

        public string? Desc { get; set; }

        public List<BankInfoValue>? Data { get; set; } = [];
    }
}