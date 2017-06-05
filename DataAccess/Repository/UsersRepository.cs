using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(string filePath)
               : base(filePath)
        {

        }

        protected override void ReadItem(StreamReader sr, User item)
        {
            item.Id = Convert.ToInt32(sr.ReadLine());
            item.FirstName = sr.ReadLine();
            item.LastName = sr.ReadLine();
            item.Username = sr.ReadLine();
            item.Password = sr.ReadLine();
            item.IsAdmin = sr.ReadLine();
        }

        protected override void WriteItem(StreamWriter sw, User item)
        {
            sw.WriteLine(item.Id);
            sw.WriteLine(item.FirstName);
            sw.WriteLine(item.LastName);
            sw.WriteLine(item.Username);
            sw.WriteLine(item.Password);
            sw.WriteLine(item.IsAdmin);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(sr.ReadLine());
                    user.FirstName = sr.ReadLine();
                    user.LastName = sr.ReadLine();
                    user.Username = sr.ReadLine();
                    user.Password = sr.ReadLine();
                    user.IsAdmin = sr.ReadLine();

                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }
    }
}
