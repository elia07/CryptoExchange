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
using Finary.Core.Enumerations;

namespace Finary.Core.Repositories
{
    public class RialGatewayRepository : GenericRepository<RialGateway>
    {
        public RialGatewayRepository() { }
        public RialGatewayRepository(FinaryEntities db, bool disableLazyLoading = false) : base(db,disableLazyLoading) { }

        public Expression<Func<RialGateway, bool>> GetPredicate(List<SearchModel> searchModels)
        {
            List<Expression<Func<RialGateway, bool>>> predicates = new List<Expression<Func<RialGateway, bool>>>();
            foreach (var item in searchModels)
            {
                if (item.IsInvolve)
                {
                    switch (item.MentionField.Name)
                    {
                        case "xName":
                            Expression<Func<RialGateway, bool>> temp = null;
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
                                    temp = t => t.xName == "" || t.xName == null;
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

                       
                        case "xTodayTotalTransactionAmounts":
                            temp = null;
                            Int64 xTodayTotalTransactionAmountsValue = Convert.ToInt64(item.Value);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.xTodayTotalTransactionAmounts == xTodayTotalTransactionAmountsValue;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.xTodayTotalTransactionAmounts >= xTodayTotalTransactionAmountsValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.xTodayTotalTransactionAmounts > xTodayTotalTransactionAmountsValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.xTodayTotalTransactionAmounts <= xTodayTotalTransactionAmountsValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.xTodayTotalTransactionAmounts < xTodayTotalTransactionAmountsValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.xTodayTotalTransactionAmounts != xTodayTotalTransactionAmountsValue;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
            
                       
                  
                        case "xIsActive":
                            temp = null;
                            bool xIsDisableValue = Convert.ToBoolean((string)item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xIsActive == xIsDisableValue;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xIsActive != xIsDisableValue;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xIsPrimary":
                            temp = null;
                            bool xIsPrimaryValue = Convert.ToBoolean((string)item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xIsPrimary == xIsPrimaryValue;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xIsPrimary != xIsPrimaryValue;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                       
                        case "xLastSuccessTransactionDate":
                            temp = null;
                            DateTime xLastSuccessTransactionDateValue = Convert.ToDateTime(((string)item.Value));
                            DateTime xLastSuccessTransactionDateValueRange = Convert.ToDateTime(((string)item.Value)).AddDays(1).AddMinutes(-1);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.xLastSuccessTransactionDate >= xLastSuccessTransactionDateValue && t.xLastSuccessTransactionDate <= xLastSuccessTransactionDateValueRange;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.xLastSuccessTransactionDate >= xLastSuccessTransactionDateValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.xLastSuccessTransactionDate > xLastSuccessTransactionDateValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.xLastSuccessTransactionDate <= xLastSuccessTransactionDateValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.xLastSuccessTransactionDate < xLastSuccessTransactionDateValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.xLastSuccessTransactionDate < xLastSuccessTransactionDateValue || t.xLastSuccessTransactionDate > xLastSuccessTransactionDateValueRange;
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
            }
            Expression<Func<RialGateway, bool>> res = null;
            ParameterExpression op = Expression.Parameter(typeof(RialGateway), "RialGateway");
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





        public int GetPrimaryRialGatewaysCount()
        {
            return (from g in db.RialGateway where g.xIsActive && g.xIsPrimary select g.xID).Count();
        }

        public RialGateway GetByName(string name)
        {
            return (from g in db.RialGateway where g.xName==name select g).SingleOrDefault();
        }
    }
}



/* availRialGateways= (from g in db.RialGateway where g.xIsActive && g.xActiveforLevelsAbove <= userInstance.xLevel && (g.xMaxDailyAmount == -1 || g.xTodayTotalTransactionAmounts <= g.xMaxDailyAmount) && ((g.xType==(byte)RialGatewayType.CartBeCart || g.xType == (byte)RialGatewayType.IPG) && g.xIsVip == userInstance.xIsVip) group g by g.xType into sg select sg.OrderBy(x => x.xLastSuccessTransactionDate).ThenBy(x=>x.xCommisionPercent).FirstOrDefault()).ToList();
                //availRialGateways = (from g in db.RialGateway where g.xIsActive && g.xActiveforLevelsAbove <= userInstance.xLevel && (g.xMaxDailyAmount == -1 || g.xMaxDailyAmount <= g.xTodayTotalTransactionAmounts) && g.xIsVip == userInstance.xIsVip && g.xType != (byte)RialGatewayType.GiftRialGateway select g).ToList();

                if (availRialGateways.Count() == 0)
                {
                    availRialGateways = (from g in db.RialGateway where g.xIsActive && g.xActiveforLevelsAbove <= userInstance.xLevel && (g.xMaxDailyAmount == -1 || g.xTodayTotalTransactionAmounts <= g.xMaxDailyAmount) && ((g.xType == (byte)RialGatewayType.CartBeCart || g.xType == (byte)RialGatewayType.IPG) && g.xIsVip == userInstance.xIsVip) && g.xIsPrimary == true select g).ToList();
                }
                if(!availRialGateways.Where(x=>x.xType==(byte)RialGatewayType.IPG).Any())
                {
                    var ipgRialGateway=(from g in db.RialGateway where g.xIsActive && g.xActiveforLevelsAbove <= userInstance.xLevel && (g.xMaxDailyAmount == -1 || g.xTodayTotalTransactionAmounts <= g.xMaxDailyAmount) && ((g.xType == (byte)RialGatewayType.CartBeCart || g.xType == (byte)RialGatewayType.IPG) && g.xIsVip == userInstance.xIsVip) && g.xType == (byte)RialGatewayType.IPG && g.xIsPrimary == true select g).SingleOrDefault();
                    if(ipgRialGateway!=null)
                    {
                        if (availRialGateways == null)
                        {
                            availRialGateways = new List<RialGateway>();
                        }
                        availRialGateways.Add(ipgRialGateway);
                    }
                }

                if (Convert.ToDateTime(userInstance.xIPGRestriction) > DateTime.Now)
                {
                    availRialGateways = availRialGateways.Where(x => x.xType != (byte)RialGatewayType.IPG).ToList();
                }*/
