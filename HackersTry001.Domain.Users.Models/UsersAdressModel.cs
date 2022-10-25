using HackersTry001.Domain.Users.Models.Base;

namespace HackersTry001.Domain.Users.Models
{
    public class UsersAdressModel : ExtendBaseModel
    {
        public int UserInfoID { get; set; }
        public string AdressName { get; set; }
        public string FullAdress { get; set; }
        public string AdressDecription { get; set; }

        public UserInfoModel UserInfo { get; set; }
    }
}
