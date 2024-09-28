namespace Store.Service.Services.Helper
{
    public class PaginatedResultDto<T>
    {
        public PaginatedResultDto(int pageIndex, int pageSize, int totlaCount, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotlaCount = totlaCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotlaCount { get; set; }

        public IReadOnlyList<T> Data { get; set; }
    }
}
