using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository("users.txt");
            AuthenticationService.LoggedUser = userRepo.GetByUsernameAndPassword(username, password);
        }
    }
}
