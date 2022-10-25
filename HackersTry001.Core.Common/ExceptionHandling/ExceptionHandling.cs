using System.Diagnostics;

namespace HackersTry001.Core.Common.ExceptionHandling
{
    public class NotificationException : Exception
    {
        public string MethotName { get; set; }
        public ExceptionTypeEnum ExceptionType { get; set; }
        public string Message { get; set; }
        public Exception ExceptionProp { get; set; }
        public NotificationException(string message, ExceptionTypeEnum exceptionType = ExceptionTypeEnum.Info)
            : base(message)
        {
            ExceptionType = exceptionType;
            Message = message;
        }
    }

    public class KnownException : Exception
    {
        public string MethotName { get; set; }
        public ExceptionTypeEnum ExceptionType { get; set; }
        public string Message { get; set; }
        public Exception ExceptionProp { get; set; }
        public KnownException(string message)
            : base(message)
        {
        }
        public KnownException(ExceptionTypeEnum exceptionType, Exception exception)
        {
            ExceptionType = exceptionType;
            Message = exception.Message;
            ExceptionProp = exception;
            MethotName = GetMethodName(exception);
        }
        public KnownException(ExceptionTypeEnum exceptionType, string message, Exception exception)
            : base(message, exception)
        {
            ExceptionType = exceptionType;
            Message = message;
            ExceptionProp = exception;
            MethotName = GetMethodName(exception);
        }
        private string GetMethodName(Exception exception)
        {
            var trace = new StackTrace(exception).GetFrames().Select(q => q.GetMethod()).FirstOrDefault();
            return trace.DeclaringType.FullName + "." + trace.Name;
        }
    }
}
