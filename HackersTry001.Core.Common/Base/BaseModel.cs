namespace HackersTry001.Core.Common.Base
{
    public class BaseModel
    {
        public int? ID { get; set; }
        public ActivationStatusEnum StatusValue { get; set; }
    }
    public class ExtendBaseModel : BaseModel
    {
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}
