using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class UserFetcher
    {
        public static User FetchUsers(string searchName)
        {
            using (var db = new UserDB())
            {
                return db.Users.Find(searchName);
            }
        }
    }
}
