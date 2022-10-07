using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Models.DTO
{
    public class UserDTO
    {
        public UserDTO(){}
        public UserDTO(string fullname, string email, string cellphone, string password,long inviteID)
        {
            Fullname = fullname;
            Email = email;
            Cellphone = cellphone;
            Password = password;
            InviteID = inviteID;
        }

        public string Fullname { set; get; }
        public string Email { set; get; }
        public string Cellphone { set; get; }
        public string Password { set; get; }
        public long InviteID { set; get; }
    }
}
