using RockCandy.Web.Framework.Core.Enumerations;
using RockCandy.Web.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.RepositoryDefinition
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        void Delete(object id);
        IQueryable<T> FilterByParam<Tkey>(Expression<Func<T, bool>> predicate, Pagination pagination, OrderByType orderByType, string OrderByFieldName = "xID", bool NoTracking = false);
        IQueryable<T> GetAll(bool NoTracking = false);
        Task<T> GetByID(object id, bool NoTracking = false);
        void Insert(T obj);
        Task Save();
        void Update(T obj);
    }
}
