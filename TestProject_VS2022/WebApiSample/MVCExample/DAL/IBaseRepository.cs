using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.DAL
{
    public interface IBaseRepository<T> where T : class
    {
        #region 添加数据
        bool Add(T entity);
        bool AddRange(List<T> entities);
        #endregion

        #region 修改数据
        bool Update(T entity);
        #endregion

        #region 删除数据
        bool Delete(T entity);

        bool BatchDelete(List<T> entities);
        bool BatchDelete(params int[] ids);
        #endregion

        #region 获取数据
        List<T> QueryList(Expression<Func<T, bool>> whereLambda);

        T Query(Expression<Func<T, bool>> whereLambda);


        bool Exists(Expression<Func<T, bool>> whereLambda);

        List<T> QueryPageList<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, out int total, bool isAsc);
        #endregion
    }
}
