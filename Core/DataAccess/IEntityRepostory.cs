using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Constraint
    //class: Referans tip
    //T için aşağıdaki gibi bir Constraint yaparken aşağıdaki gibi bir yapı kullanılmaktadır. Ientity de olan bir nesne olması gerekir.
    public interface IEntityRepostory<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
