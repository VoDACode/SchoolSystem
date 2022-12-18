namespace SchoolSystem.Responses
{
    public class ResponseExtend<Input, View> : Response where View : class
    {
        public ResponseExtend(bool success, string? message, Input data) : base(success, message)
        {
            Data = createInstance(data);
        }

        public ResponseExtend(bool success, string? message, IList<Input> data) : base(success, message)
        {
            Data = data.Select(s => createInstance(s)).ToList();
        }

        private View createInstance(Input data)
        {
            return Activator.CreateInstance(typeof(View), data) as View;
        }
    }
}
