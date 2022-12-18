using SchoolSystem.DataModels.View;

namespace SchoolSystem.Responses
{
    public class ResponsePage<Input, View> : Response where View : class
    {
        public ResponsePage(bool success, IList<Input> data, int totalPages, int page) : base(success, "Page data")
        {
            var obj = data.Select(p => Activator.CreateInstance(typeof(View), p) as View);
            Data = new PageData<IEnumerable<View>>(page, totalPages, obj);
        }
        public ResponsePage(bool success, IList<Input> data, int totalPages, int page, params object?[]? args) 
            : base(success, "Page data")
        {
            var obj = data.Select(p => Activator.CreateInstance(typeof(View), p, args) as View);
            Data = new PageData<IEnumerable<View>>(page, totalPages, obj);
        }
    }
    public class ResponsePage<Input> : Response
    {
        public ResponsePage(bool success, IList<Input> data, int totalPages, int page) : base(success, "Page data")
        {
            Data = new PageData<IEnumerable<Input>>(page, totalPages, data);
        }
    }
}
