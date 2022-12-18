namespace SchoolSystem.DataModels.View
{
    public class PageData<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public T Data { get; set; }
        public PageData(int page, int totalPages, T data)
        {
            Page = page;
            TotalPages = totalPages;
            Data = data;
        }
    }
}
