using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TasksRepository : BaseRepository<Taask>
    {
        public TasksRepository(string filePath) : base(filePath)
        {
        }

        protected override void ReadItem(StreamReader sr, Taask item)
        {
            item.Id = Convert.ToInt32(sr.ReadLine());
            item.ParentUserId = Convert.ToInt32(sr.ReadLine());
            item.FullName = sr.ReadLine();
            item.Description = sr.ReadLine();
            item.Grade = Convert.ToInt32(sr.ReadLine());
            item.Responsible = sr.ReadLine();
            item.Creator = sr.ReadLine();
            item.Start = sr.ReadLine();
            item.LastEdited = sr.ReadLine();
            item.Status = sr.ReadLine();
    }

        protected override void WriteItem(StreamWriter sw, Taask item)
        {
            sw.WriteLine(item.Id + 1);
            sw.WriteLine(item.ParentUserId);
            sw.WriteLine(item.FullName);
            sw.WriteLine(item.Description);
            sw.WriteLine(item.Grade);
            sw.WriteLine(item.Responsible);
            sw.WriteLine(item.Creator);
            sw.WriteLine(item.Start);
            sw.WriteLine(item.LastEdited);
            sw.WriteLine(item.Status);
        }

        public List<Taask> GetAll(int parentUserId)
        {
            List<Taask> result = new List<Taask>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Taask task = new Taask();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    task.FullName = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.Responsible = sr.ReadLine();
                    task.Creator = sr.ReadLine();
                    task.Start = sr.ReadLine();
                    task.LastEdited = sr.ReadLine();
                    task.Status = sr.ReadLine();

                    if (task.ParentUserId == parentUserId)
                    {
                        result.Add(task);
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
        public List<Taask> GetTasks()
        {
            List<Taask> result = new List<Taask>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Taask task = new Taask();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.ParentUserId = Convert.ToInt32(sr.ReadLine());
                    task.FullName = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.Responsible = sr.ReadLine();
                    task.Creator = sr.ReadLine();
                    task.Start = sr.ReadLine();
                    task.LastEdited = sr.ReadLine();
                    task.Status = sr.ReadLine();
                    result.Add(task);
                    
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
