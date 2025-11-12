using Sln.Shared.Common.Extensions;
using Sln.Shared.Contract.Extensions;

namespace Sln.Shared.Contract.Models
{
    public class PaginationResponse<TItem>
    {
        public static PaginationResponse<TItem> Create(IQueryable<TItem> queryable, PaginationRequest PaginationRequestModel)
        {
            if (string.IsNullOrEmpty(PaginationRequestModel.OrderBy) == false)
            {
                var isDesc = PaginationRequestModel.OrderDirection?.ToLower() == "desc";

                if (isDesc)
                {
                    queryable = queryable.OrderByDescending(PaginationRequestModel.OrderBy);
                }
                else
                {
                    queryable = queryable.OrderBy(PaginationRequestModel.OrderBy);
                }
            }

            var items = queryable.Skip((PaginationRequestModel.Page - 1) * PaginationRequestModel.PageSize).Take(PaginationRequestModel.PageSize).ToList();

            int? totalItems = PaginationRequestModel.UseCountTotal
                ? queryable.Count()
                : null;

            return new PaginationResponse<TItem>(items, PaginationRequestModel.PageSize, PaginationRequestModel.Page, totalItems);
        }

        public static PaginationResponse<TItem> Create(IQueryable<TItem> queryable, ScrollPaginationRequest PaginationRequestModel)
        {
            queryable = queryable.TryOrderByIdDescending(PaginationRequestModel);

            var items = queryable.Take(PaginationRequestModel.PageSize).ToList();

            int? totalItems = PaginationRequestModel.UseCountTotal
                ? queryable.Count()
                : null;

            return new PaginationResponse<TItem>(items, PaginationRequestModel.PageSize, 1, totalItems);
        }

        public static PaginationResponse<TItem> Create(List<TItem>? queryable, PaginationRequest PaginationRequestModel)
        {
            if (string.IsNullOrEmpty(PaginationRequestModel.OrderBy) == false)
            {
                var isDesc = PaginationRequestModel.OrderDirection?.ToLower() == "desc";

                if (isDesc)
                {
                    queryable = queryable?.OrderByDescending(PaginationRequestModel.OrderBy).ToList();
                }
                else
                {
                    queryable = queryable?.OrderBy(PaginationRequestModel.OrderBy).ToList();
                }
            }

            var items = queryable?.Skip((PaginationRequestModel.Page - 1) * PaginationRequestModel.PageSize).Take(PaginationRequestModel.PageSize).ToList();

            int? totalItems = PaginationRequestModel.UseCountTotal
                ? queryable?.Count
                : null;

            return new PaginationResponse<TItem>(items ?? new List<TItem>(), PaginationRequestModel.PageSize, PaginationRequestModel.Page, totalItems);
        }

        public PaginationResponse()
        {
            Meta = new PaginationMeta();
        }

        public PaginationResponse(List<TItem> items)
        {
            Items = items;
            Meta = new PaginationMeta();
        }

        public PaginationResponse(List<TItem> items, int pageSize, int page, int? totalItems)
        {
            Items = items;
            Meta = new PaginationMeta
            {
                TotalItems = totalItems,
                PageCount = totalItems is not null
                    ? (int)Math.Ceiling((double)totalItems / pageSize)
                    : null,
                Page = page,
                PageSize = pageSize
            };
        }

        public List<TItem> Items { get; set; } = new List<TItem>();
        public PaginationMeta Meta { get; set; }
    }

}
