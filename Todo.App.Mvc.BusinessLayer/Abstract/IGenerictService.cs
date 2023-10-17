using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.App.Mvc.BusinessLayer.Abstract
{
    public interface IGenerictService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        T TGetById(int id);
        List<T> TGetByUserId(string userId);
        List<T> TGetAll();
    }
}
