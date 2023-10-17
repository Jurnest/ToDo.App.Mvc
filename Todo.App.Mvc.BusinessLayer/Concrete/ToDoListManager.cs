using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.App.Mvc.BusinessLayer.Abstract;
using Todo.App.Mvc.DataAccessLayer.Abstract;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        private readonly IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TDelete(ToDoList entity)
        {
            _toDoListDal.Delete(entity);
        }

        public List<ToDoList> TGetAll()
        {
            return _toDoListDal.GetAll();
        }

        public ToDoList TGetById(int id)
        {
            return _toDoListDal.GetById(id);
        }

        public List<ToDoList> TGetByUserId (string userId)
        {
            var values = _toDoListDal.GetAll();
            return values.Where(x => x.UserId == userId).ToList();
        }

        public void TInsert(ToDoList entity)
        {
            _toDoListDal.Insert(entity);
        }

        public void TUpdate(ToDoList entity)
        {
            _toDoListDal.Update(entity);
        }
    }
}
