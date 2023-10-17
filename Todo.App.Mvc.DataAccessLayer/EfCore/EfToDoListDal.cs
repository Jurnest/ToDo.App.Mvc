using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.App.Mvc.DataAccessLayer.Abstract;
using Todo.App.Mvc.DataAccessLayer.Concrete;
using Todo.App.Mvc.DataAccessLayer.Repositories;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.DataAccessLayer.EfCore
{
    public class EfToDoListDal : GenericRepository<ToDoList>, IToDoListDal
    {
        public EfToDoListDal(Context context) : base(context)
        {
            
        }
    }
}
