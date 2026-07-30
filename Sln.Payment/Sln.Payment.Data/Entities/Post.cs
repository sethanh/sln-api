using Sln.Payment.Data.Models;
using Sln.Shared.Common.Enums.Captures;

namespace Sln.Payment.Data.Entities;

public class Post : PaymentAuditModel<Guid>
{
    public Guid AccountId { get; set; }

    /// <summary>
    /// Bộ sưu tập (Cats, Wine Bottles...)
    /// </summary>
    // public Guid CollectionId { get; set; }

    /// <summary>
    /// Đối tượng được capture (British Shorthair...)
    /// </summary>
    // public Guid? ItemId { get; set; }

    /// <summary>
    /// Tiêu đề (không bắt buộc)
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Mô tả
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ảnh chính
    /// </summary>
    public required string ImageUrl { get; set; }

    public int ImageWidth { get; set; }

    public int ImageHeight { get; set; }

    /// <summary>
    /// Hiển thị công khai hay riêng tư
    /// </summary>
    public PostVisibility Visibility { get; set; } = PostVisibility.Public;

    /// <summary>
    /// Tổng số lượt thích
    /// </summary>
    public int LikeCount { get; set; }

    /// <summary>
    /// Tổng số bình luận
    /// </summary>
    public int CommentCount { get; set; }

    /// <summary>
    /// Tổng số lượt lưu
    /// </summary>
    public int SaveCount { get; set; }

    public virtual Account? Account { get; set;}
    
}
