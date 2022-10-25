using HackersTry001.Core.Common.Base;

namespace HackersTry001.Domain.Users.Models
{
    public class UserInfoModel : ExtendBaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public DateTime? BirthDay { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ApprovalStatusEnum ApprovalStatusValue { get; set; }

        public ICollection<UsersAdressModel> UsersAdressList { get; set; }
    }
}
