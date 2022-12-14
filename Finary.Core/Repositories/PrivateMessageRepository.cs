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

namespace Finary.Core.Repositories
{
    public class PrivateMessageRepository : GenericRepository<PrivateMessage>
    {
        public PrivateMessageRepository() { }
        public PrivateMessageRepository(FinaryEntities db, bool disableLazyLoading = false) : base(db,disableLazyLoading) { }

        public Expression<Func<PrivateMessage, bool>> GetPredicate(List<SearchModel> searchModels)
        {
            List<Expression<Func<PrivateMessage, bool>>> predicates = new List<Expression<Func<PrivateMessage, bool>>>();
            /*foreach (var item in searchModels)
            {
                if (item.IsInvolve)
                {
                    switch (item.MentionField.Name)
                    {
                        case "xEmail":
                            Expression<Func<PrivateMessage, bool>> temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xEmail == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xEmail != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xEmail.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xEmail == "" || t.xEmail == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xName":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xName == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xName != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xName.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xName == "" || t.xEmail == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xType":
                            temp = null;
                            byte value = Convert.ToByte((string)item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xType == value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xType != value;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;

                        default:
                            break;
                    }
                }
            }*/
            Expression<Func<PrivateMessage, bool>> res = null;
            ParameterExpression op = Expression.Parameter(typeof(PrivateMessage), "PrivateMessage");
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

        public IQueryable<PrivateMessage> GetUserMessages(long userID)
        {
            return (from pm in db.PrivateMessage where pm.xUserID==userID orderby pm.xID descending select pm);
        }

        public void Insert(long userID,string message,string title)
        {
            PrivateMessage instance = new PrivateMessage();
            instance.xUserID = userID;
            instance.xMessage = message;
            instance.xSendDate = DateTime.Now;
            instance.xTitle = title;

            Insert(instance);
            Save();
        }
    }
}
