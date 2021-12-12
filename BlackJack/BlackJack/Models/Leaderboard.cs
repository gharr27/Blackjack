using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Leaderboard
    {
        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get
            {
                return userList;
            }
        }

        public Leaderboard()
        {
            userList = new ObservableCollection<User>();

            BuildUserList();
        }

        private void BuildUserList()
        {
            userList.Clear();

            using (var db = new UserDB())
            {

                foreach(var user in db.Users)
                {
                    userList.Add(user);
                }
            }
        }

        public void AddUser(User newUser)
        {
            using (var db = new UserDB())
            {
                // Make sure a new Id is assigned
                newUser.Id = 0;

                db.Users.Add(newUser);

                // New MovieId assigned when saved
                db.SaveChanges();

                BuildUserList();
            }
        }

        public void UpdateUser(User updatedUser)
        {
            using (var db = new UserDB())
            {
                db.Users.Update(updatedUser);
                db.SaveChanges();
                BuildUserList();
            }
        }

        public void DeleteUser(User user)
        {
            using (var db = new UserDB())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                BuildUserList();
            }
        }

        
    }
}
