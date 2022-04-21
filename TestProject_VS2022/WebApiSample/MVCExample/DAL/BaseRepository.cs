using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCExample.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ERPEntities Db = new ERPEntities();

        #region 添加数据
        public virtual bool Add(T entity)
        {
            Db.Set<T>().Add(entity);

            return Db.SaveChanges() > 0;
        }
        public virtual bool AddRange(List<T> entities)
        {
            Db.Set<T>().AddRange(entities);
            return Db.SaveChanges() > 0;
        }
        #endregion

        #region 修改数据
        public virtual bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return Db.SaveChanges() > 0;
        }
        #endregion

        #region 删除数据
        public virtual bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }
        public virtual bool Delete(int id)
        {
            var entity = Db.Set<T>().Find(id);//如果实体已经在内存中，那么就直接从内存拿，如果内存中跟踪实体没有，那么才查询数据库。
            if (entity != null) Db.Entry(entity).State = EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }

        public virtual bool BatchDelete(List<T> entities)
        {
            Db.Set<T>().RemoveRange(entities);
            return Db.SaveChanges() > 0;
        }
        public virtual bool BatchDelete(params int[] ids)
        {
            foreach (var item in ids)
            {
                var entity = Db.Set<T>().Find(item);//如果实体已经在内存中，那么就直接从内存拿，如果内存中跟踪实体没有，那么才查询数据库。
                if (entity != null) Db.Set<T>().Remove(entity);
            }
            return Db.SaveChanges() > 0;
        }
        #endregion

        #region 获取数据
        public List<T> QueryList(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).ToList();
        }

        public T Query(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).SingleOrDefault();
        }


        public bool Exists(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).Any();
        }

        public List<T> QueryPageList<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, out int total, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();

            if (isAsc)
            {
                return
                Db.Set<T>()
                  .Where(whereLambda)
                  .OrderBy(orderbyLambda)
                  .Skip(pageSize * (pageIndex - 1))
                  .Take(pageSize)
                  .ToList();
            }
            else
            {
                return
               Db.Set<T>()
                 .Where(whereLambda)
                 .OrderByDescending(orderbyLambda)
                 .Skip(pageSize * (pageIndex - 1))
                 .Take(pageSize)
                 .ToList();
            }
        }
        #endregion
    }
}