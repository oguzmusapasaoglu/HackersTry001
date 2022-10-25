namespace HackersTry001.Core.Common.Helper
{
    public class ResponseMessageHelper
    {
        public static string SuccessCreate(string parmMessage)
        {
            return (parmMessage.IsNullOrEmpty())
                ? string.Empty
                : string.Format("{0} kaydı başarı ile yapıldı!", parmMessage);
        }
        public static string SuccessUpdate(string parmMessage)
        {
            return (parmMessage.IsNullOrEmpty())
                ? string.Empty
                : string.Format("{0} kaydı başarı ile düzenlendi!", parmMessage);
        }
        public static string SuccessDelete(string parmMessage)
        {
            return (parmMessage.IsNullOrEmpty())
                ? string.Empty
                : string.Format("{0} kaydı başarı ile kaldırıldı!", parmMessage);
        }
    }
}
