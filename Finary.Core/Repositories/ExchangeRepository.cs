using Finary.Core.RepositoryDefinition;
using RockCandy.Web.Framework.Core.Enumerations;
using RockCandy.Web.Framework.Core.HelperClasses;
using RockCandy.Web.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Finary.Core;
using Finary.Core.Models.DTO;

namespace Finary.Core.Repositories
{
    public class ExchangeRepository : GenericRepository<Exchange>
    {
        public ExchangeRepository() { }
        public ExchangeRepository(FinaryEntities db, bool disableLazyLoading = false) : base(db,disableLazyLoading) { }

        public Expression<Func<Exchange, bool>> GetPredicate(List<SearchModel> searchModels)
        {
            List<Expression<Func<Exchange, bool>>> predicates = new List<Expression<Func<Exchange, bool>>>();
            foreach (var item in searchModels)
            {
                if (item.IsInvolve)
                {
                    switch (item.MentionField.Name)
                    {
                        default:
                            break;
                    }
                }
            }
            Expression<Func<Exchange, bool>> res = null;
            ParameterExpression op = Expression.Parameter(typeof(Exchange), "Exchange");
            foreach (var item in predicates)
            {
                if (res == null)
                {
                    res = item;
                }
                else
                {

                    res = res.And(item);

                }

            }

            return res;
            //http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
        }

        



        public void InsertTransaction(ExchangeDTO args)
        {
            /*var instance = GetBy("BadBeatJackpotValue");
            long newValue = Convert.ToInt64(instance.xValue);
            newValue += Convert.ToInt64(value);
            instance.xValue = newValue.ToString();
            Update(instance);
            Save();*/
        }
    }
}
