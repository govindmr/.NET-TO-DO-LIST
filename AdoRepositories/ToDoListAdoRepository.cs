using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDOListModel;

namespace AdoRepositories
{
    public class ToDoListAdoRepository
    {
        public int CreateTasks(ToDOListEntity task)
        {
            using (var context = new ToDoListDBEntities())
            {
                TO_DO_LIST_TABLE model = new TO_DO_LIST_TABLE()
                {
                    TaskName = task.TaskName,
                    Description = task.Description,
                    Status = "",
                };
                context.TO_DO_LIST_TABLE.Add(model);
                context.SaveChanges();
                return model.Id;
            }
        }

        public List<ToDOListEntity> GetAllTasks()
        {
            using(var context = new ToDoListDBEntities())
            {
                var result = context.TO_DO_LIST_TABLE
                    .Select(x => new ToDOListEntity()
                    {
                        Id = x.Id,
                        TaskName = x.TaskName,
                        Description = x.Description,
                        Status = x.Status
                    }).ToList();
                return result;
            }
        }

        public ToDOListEntity GetTask(int id)
        {
            using(var context = new ToDoListDBEntities())
            {
                var result = context.TO_DO_LIST_TABLE.
                   // Where(x => x.Id == id).
                    Select(x => new ToDOListEntity()
                    {
                        Id = x.Id,
                        TaskName = x.TaskName,
                        Description = x.Description,
                        Status = x.Status
                    }).FirstOrDefault(x => x.Id == id);

                return result;
            }
        }

        public bool Update(int id, ToDOListEntity model)
        {
            using(var context = new ToDoListDBEntities())
            {
                var task = new TO_DO_LIST_TABLE()
                {
                    Id = id,
                    TaskName = model.TaskName,
                    Description = model.Description,
                    Status = model.Status
                };
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
                return true;
               
            };
        }
       
        public bool DeleteTask(int id)
        {
            using (var context = new ToDoListDBEntities())
            {
                var task = new TO_DO_LIST_TABLE()
                {
                    Id = id
                };
                context.Entry(task).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
       
    }
}
