namespace HackersTry001.Core.Common.Base
{
    public class ResponseBase<T> where T : class
    {
        public ResultEnum Result { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
