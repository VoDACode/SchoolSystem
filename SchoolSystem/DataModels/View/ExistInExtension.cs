namespace SchoolSystem.DataModels.View
{
    public class ExistInExtension<T>
    {
        public bool ExistIn { get; set; }
        public T Data { get; set; }
        public ExistInExtension(T data, bool existIn)
        {
            Data = data;
            ExistIn = existIn;
        }
    }
}
