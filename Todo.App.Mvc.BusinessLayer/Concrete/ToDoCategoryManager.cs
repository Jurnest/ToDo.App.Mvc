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
    public class ToDoCategoryManager : IToDoCategoryService
    {
        private readonly IToDoCategoryDal _ToDoCategoryDal;

        public ToDoCategoryManager(IToDoCategoryDal toDoCategoryDal)
        {
            _ToDoCategoryDal = toDoCategoryDal;
        }

        public void TDelete(ToDoCategory entity)
        {
            _ToDoCategoryDal.Delete(entity);
        }

        public List<ToDoCategory> TGetAll()
        {
            return _ToDoCategoryDal.GetAll();
        }

        public ToDoCategory TGetById(int id)
        {
            return _ToDoCategoryDal.GetById(id);
        }

        public List<ToDoCategory> TGetByUserId(string userId)
        {
            var values = _ToDoCategoryDal.GetAll();
            return values.Where(x => x.UserId == userId).ToList();
        }

        public void TInsert(ToDoCategory entity)
        {
            _ToDoCategoryDal.Insert(entity);
        }

        public void TUpdate(ToDoCategory entity)
        {
            _ToDoCategoryDal.Update(entity);
        }
    }
}
