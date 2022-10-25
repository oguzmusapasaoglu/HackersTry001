using Dapper.Contrib.Extensions;

using HackersTry001.Core.Dapper.DapperBase;

namespace HackersTry001.Domain.Users.Models.Entities
{
    [Table("Users.UserInfo")]
    public class UserInfoEntity : ExtendBaseEntity
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