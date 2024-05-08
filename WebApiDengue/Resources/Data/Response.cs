namespace WebApiDengue.Resources.Data
{
    public class Response<T>
    {
        public bool? iscorrect { get; set; }
        public int? status { get; set; }
        public string? message { get; set; }
        public List<T>? data { get; set; }

        public Response() { }
        public Response(bool _iscorrect)
        {
            this.iscorrect = _iscorrect;
        }
        public Response(bool _iscorrect, int _status)
        {
            this.iscorrect = _iscorrect; this.status = _status;
        }
        public Response(bool _iscorrect, int _status, string _message)
        {
            this.iscorrect = _iscorrect;
            this.status = _status;
            this.message = _message;
        }
        public Response(bool _iscorrect, int _status, string _message, List<T> _data)
        {
            this.iscorrect = _iscorrect;
            this.status = _status;
            this.message = _message;
            this.data = _data;
        }

    }
}
