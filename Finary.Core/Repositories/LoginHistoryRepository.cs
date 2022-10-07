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
    public class LoginHistoryRepository : GenericRepository<LoginHistory>
    {
        public LoginHistoryRepository() { }
        public LoginHistoryRepository(FinaryEntities db, bool disableLazyLoading = false) : base(db,disableLazyLoading) { }

        public Expression<Func<LoginHistory, bool>> GetPredicate(List<SearchModel> searchModels)
        {
            List<Expression<Func<LoginHistory, bool>>> predicates = new List<Expression<Func<LoginHistory, bool>>>();
            /*foreach (var item in searchModels)
            {
                if (item.IsInvolve)
                {
                    switch (item.MentionField.Name)
                    {
                        case "xEmail":
                            Expression<Func<LoginHistory, bool>> temp = null;
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
            Expression<Func<LoginHistory, bool>> res = null;
            ParameterExpression op = Expression.Parameter(typeof(LoginHistory), "LoginHistory");
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

        public void Insert(string ip,string deviceID,long userID,string useragent,string rayID)
        {
            LoginHistory lhInstance = new LoginHistory();
            lhInstance.xDate = DateTime.Now;
            lhInstance.xDeviceID = deviceID;
            lhInstance.xIP = ip;
            lhInstance.xUserID = userID;
            lhInstance.xUserAgent = useragent;
            lhInstance.xFraudDetected = false;
            if (lhInstance.xUserAgent.Length>512)
            {
                lhInstance.xUserAgent = lhInstance.xUserAgent.Substring(0, 512);
            }
            lhInstance.xRayID = rayID;
            Insert(lhInstance);
            Save();
        }


        public IQueryable<LoginHistory> GetLastLogins(long userID,int count)
        {
            return (from l in db.LoginHistory where l.xUserID == userID orderby l.xID descending select l).Take(count);
        }


        public int GetCountByDate(DateTime startDate, DateTime endDate)
        {
            return (from c in db.LoginHistory where c.xDate >= startDate && c.xDate < endDate select c.xID).Count();
        }
        public int GetUniqueCountByDate(DateTime startDate, DateTime endDate)
        {
            return (from c in db.LoginHistory where c.xDate >= startDate && c.xDate < endDate select c.xUserID).Distinct().Count();
        }


        public IQueryable<LoginHistory> GetAllForFraudDetection(long userID)
        {
            return (from l in db.LoginHistory where l.xFraudDetected==false && l.xUserID==userID select l);
        }

        public IQueryable<LoginHistory> GetByDateAndUserID(long userID,DateTime date)
        {
            return (from l in db.LoginHistory where l.xUserID == userID && l.xDate>= date select l);
        }

        public void SetAllFraudDetectioned(long userID)
        {
            db.Database.ExecuteSqlCommand("Update LoginHistory set xFraudDetected=1 where xUserID=" + userID);
        }
    }
}
