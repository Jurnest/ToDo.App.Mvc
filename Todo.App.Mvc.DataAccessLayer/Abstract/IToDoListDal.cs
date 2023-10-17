using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.DataAccessLayer.Abstract
{
    public interface IToDoListDal : IGenericDal<ToDoList>
    {
    }
}
