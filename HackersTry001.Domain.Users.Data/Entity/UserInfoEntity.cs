using HackersTry001.Core.Dapper.Base;

using Dapper.Contrib.Extensions;

namespace HackersTry001.Domain.Users.Data.Entity
{
    [Table("Users.UserInfo")]
    public class UserInfoEntity : ExtendBaseDapperEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public DateTime? BirthDay { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ApprovalStatus { get; set; }
    }
}