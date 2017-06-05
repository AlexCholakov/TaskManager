using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class InfoRepository : BaseRepository<Info>
    {
        public InfoRepository(string filePath)
            : base(filePath)
        {

        }

        protected override void ReadItem(StreamReader sr, Info item)
        {
            item.Id = Convert.ToInt32(sr.ReadLine());
            item.ParentTaaskId = Convert.ToInt32(sr.ReadLine());
            item.UserTime = sr.ReadLine();
            item.TimePassed = Convert.ToInt32(sr.ReadLine());
            item.DateFromTime = sr.ReadLine();
        }

        protected override void WriteItem(StreamWriter sw, Info item)
        {
            sw.WriteLine(item.Id);
            sw.WriteLine(item.ParentTaaskId);
            sw.WriteLine(item.UserTime);
            sw.WriteLine(item.TimePassed);
            sw.WriteLine(item.DateFromTime);
        }

        public List<Info> GetAll(int ParentTaaskId)
        {
            List<Info> result = new List<Info>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Info info = new Info();
                    info.Id = Convert.ToInt32(sr.ReadLine());
                    info.ParentTaaskId = Convert.ToInt32(sr.ReadLine());
                    info.UserTime = sr.ReadLine();
                    info.TimePassed = Convert.ToInt32(sr.ReadLine());
                    info.DateFromTime = sr.ReadLine();

                    if (info.ParentTaaskId == ParentTaaskId)
                    {
                        result.Add(info);
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }
    }
}
