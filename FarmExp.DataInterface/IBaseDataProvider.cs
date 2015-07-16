using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmExp.Data.Interface
{
    public interface IBaseDataProvider<T> where T:class
    {
        T GetEnityById(int id);
        T AddEnityBy(T entity);
        T UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        IQueryable<T> GetAllEntity<s>(int pageIndex, int pageSize, Func<T, bool> whereLambda, Func<T, s> orderLambda, bool isAsc);
    }
}
