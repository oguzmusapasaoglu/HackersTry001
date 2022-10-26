using HackersTry001.Core.Common.Base;

namespace HackersTry001.Domain.Users.Services.Models
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
        public ICollection<UsersAdressModel> UserAdressList { get; set; }
    }
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserChangePasswordModel
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class UserForgotPasswordModel
    {
        public string UserEMail { get; set; }
    }
    public class UserFilterModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
    public class UserCreateOrUpdateModel : BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public DateTime? BirthDay { get; set; }
        public string UserName { get; set; }
    }
}
