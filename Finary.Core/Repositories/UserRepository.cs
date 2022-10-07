using Finary.Core.Enumerations;
using Finary.Core.Models.DTO;
using Finary.Core.RepositoryDefinition;
using Finary.Core.Utils;
using RockCandy.Web.Framework.Core.Enumerations;
using RockCandy.Web.Framework.Core.HelperClasses;
using RockCandy.Web.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }
        public UserRepository(FinaryEntities db, bool disableLazyLoading = false) : base(db,disableLazyLoading) { }

        public Expression<Func<User, bool>> GetPredicate(List<SearchModel> searchModels)
        {
            List<Expression<Func<User, bool>>> predicates = new List<Expression<Func<User, bool>>>();
            foreach (var item in searchModels)
            {
                if (item.IsInvolve)
                {
                    switch (item.MentionField.Name)
                    {
                        case "xEmail":
                            Expression<Func<User, bool>> temp = null;
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
                       
                        case "xDescription":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xDescription == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xDescription != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xDescription.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xDescription == "" || t.xDescription == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xNationalIDNumber":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xNationalIDNumber == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xNationalIDNumber != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xNationalIDNumber.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xNationalIDNumber == "" || t.xNationalIDNumber == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xFullName":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xFullName == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xFullName != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xFullName.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xFullName == "" || t.xFullName == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                       
                      
                        case "xCellphone":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xCellphone == (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xCellphone != (string)item.Value;
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.xCellphone.Contains((string)item.Value);
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = t => t.xCellphone == "" || t.xCellphone == null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xBankCardCount":
                            temp = null;
                            Int64 xBankCardCountValue = Convert.ToInt64(item.Value);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.UserBankAccount.Count() == xBankCardCountValue;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.UserBankAccount.Count() >= xBankCardCountValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.UserBankAccount.Count() > xBankCardCountValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.UserBankAccount.Count() <= xBankCardCountValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.UserBankAccount.Count() < xBankCardCountValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.UserBankAccount.Count() != xBankCardCountValue;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xVerifiedBankAccount":
                            temp = null;
                            Int64 xVerifiedBankAccountValue = Convert.ToInt64(item.Value);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.UserBankAccount.Where(x=>x.xIsVerified).Count() == xVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified).Count() >= xVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified).Count() > xVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified).Count() <= xVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified).Count() < xVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified).Count() != xVerifiedBankAccountValue;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xNotVerifiedBankAccount":
                            temp = null;
                            Int64 xNotVerifiedBankAccountValue = Convert.ToInt64(item.Value);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified==false).Count() == xNotVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified == false).Count() >= xNotVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified == false).Count() > xNotVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified == false).Count() <= xNotVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified == false).Count() < xNotVerifiedBankAccountValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xIsVerified == false).Count() != xNotVerifiedBankAccountValue;
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
                        case "xIsEmailValidated":
                            temp = null;
                            bool xIsEmailValidatedValue = Convert.ToBoolean((string)item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xIsEmailValidated == xIsEmailValidatedValue;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xIsEmailValidated != xIsEmailValidatedValue;
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
                        case "xIsNationalIDValidated":
                            temp = null;
                            bool xIsNationalIDValidatedValue = Convert.ToBoolean((string)item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xIsNationalIDValidated == xIsNationalIDValidatedValue;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xIsNationalIDValidated != xIsNationalIDValidatedValue;
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
              
                     
                        case "xCellphoneValidated":
                            temp = null;
                            bool xCellphoneActivatedValue = Convert.ToBoolean(item.Value);
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.xCellphoneValidated == xCellphoneActivatedValue;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.xCellphoneValidated != xCellphoneActivatedValue;
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
                        
                        case "xInviteID":
                            temp = null;
                            Int64 xInviteIDValue = Convert.ToInt64(item.Value);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.xInviteID == xInviteIDValue;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.xInviteID >= xInviteIDValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.xInviteID > xInviteIDValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.xInviteID <= xInviteIDValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.xInviteID < xInviteIDValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.xInviteID != xInviteIDValue;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        
                        case "xSignupDate":
                            temp = null;
                            DateTime xSignupDateValue = Convert.ToDateTime(((string)item.Value));
                            DateTime xSignupDateValueRange = Convert.ToDateTime(((string)item.Value)).AddDays(1).AddMinutes(-1);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.xSignupDate >= xSignupDateValue && t.xSignupDate <= xSignupDateValueRange;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.xSignupDate >= xSignupDateValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.xSignupDate > xSignupDateValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.xSignupDate <= xSignupDateValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.xSignupDate < xSignupDateValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.xSignupDate < xSignupDateValue || t.xSignupDate > xSignupDateValueRange;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xLastSigninDate":
                            temp = null;
                            DateTime xLastSigninDateValue = Convert.ToDateTime(((string)item.Value));
                            DateTime xLastSigninDateValueRange = Convert.ToDateTime(((string)item.Value)).AddDays(1).AddMinutes(-1);
                            switch (item.LogicalOperator)
                            {
                                case LogicalOperatorType.Equal:
                                    temp = t => t.xLastSigninDate >= xLastSigninDateValue && t.xSignupDate <= xLastSigninDateValueRange;
                                    break;
                                case LogicalOperatorType.GreaterOrEqual:
                                    temp = t => t.xLastSigninDate >= xLastSigninDateValue;
                                    break;
                                case LogicalOperatorType.GreaterThan:
                                    temp = t => t.xLastSigninDate > xLastSigninDateValue;
                                    break;
                                case LogicalOperatorType.LessOrEqual:
                                    temp = t => t.xLastSigninDate <= xLastSigninDateValue;
                                    break;
                                case LogicalOperatorType.LessThan:
                                    temp = t => t.xLastSigninDate < xLastSigninDateValue;
                                    break;
                                case LogicalOperatorType.NotEqual:
                                    temp = t => t.xLastSigninDate < xLastSigninDateValue || t.xLastSigninDate > xLastSigninDateValueRange;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;

                        case "xCardNumber":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.UserBankAccount.Where(x=>x.xCartNumber== (string)item.Value).Any() ;
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xCartNumber != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.UserBankAccount.Where(x => x.xCartNumber.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xAccountNumber":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.UserBankAccount.Where(x => x.xAccountNumber == (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xAccountNumber != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.UserBankAccount.Where(x => x.xAccountNumber.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xShebaNumber":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.UserBankAccount.Where(x => x.xShebaNumber == (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.UserBankAccount.Where(x => x.xShebaNumber != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.UserBankAccount.Where(x => x.xShebaNumber.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        
                        case "xDeviceID":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.LoginHistory.Where(x => x.xDeviceID == (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.LoginHistory.Where(x => x.xDeviceID != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.LoginHistory.Where(x => x.xDeviceID.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xRayID":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.LoginHistory.Where(x => x.xRayID == (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.LoginHistory.Where(x => x.xRayID != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.LoginHistory.Where(x => x.xRayID.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
                                    break;
                                default:
                                    break;
                            }
                            if (temp != null)
                                predicates.Add(temp);
                            break;
                        case "xIp":
                            temp = null;
                            switch (item.NoneNumericalOperation)
                            {
                                case NoneNumericalOperationType.Equal:
                                    temp = t => t.LoginHistory.Where(x => x.xIP == (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.NotEqual:
                                    temp = t => t.LoginHistory.Where(x => x.xIP != (string)item.Value).Any();
                                    break;
                                case NoneNumericalOperationType.Contains:
                                    temp = t => t.LoginHistory.Where(x => x.xIP.Contains((string)item.Value)).Any();
                                    break;
                                case NoneNumericalOperationType.EmptyOrNull:
                                    temp = null;
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
            Expression<Func<User, bool>> res = null;
            ParameterExpression op = Expression.Parameter(typeof(User), "User");
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

        public User Authentication(UserDTO instance)
        {
            return (from u in db.User where u.xEmail == instance.Email && u.xPassword == instance.Password select u).SingleOrDefault();
        }
        public User Authentication(string xEmail, string xPassword)
        {
            return (from u in db.User where u.xEmail == xEmail && u.xPassword == xPassword select u).SingleOrDefault();
        }


        public User GetbyEmail(string email)
        {
            return (from u in db.User where u.xEmail==email select u).SingleOrDefault();
        }




        public User GetbyCellphone(string cellphone)
        {
            return (from u in db.User where u.xCellphone == cellphone select u).SingleOrDefault();
        }

        public User GetbyInviteID(long inviteID)
        {
            return (from u in db.User where u.xInviteID == inviteID select u).SingleOrDefault();
        }

        public int GetUserCount(bool isBot=false)
        {
            return (from u in db.User where u.xIsActive select u.xID).Count();
        }

        public async Task<JsonResponse> RegisterUser(UserDTO args)
        {
            JsonResponse jr = new JsonResponse(true, "");

            if (!new EmailAddressAttribute().IsValid(args.Email))
            {
                jr.CustomFields.Add("title", "خطا");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                jr.Message = "پست الکترونیک معتبر نیست";
                jr.Status = false;
                return jr;
            }

            if (!(args.Cellphone.Length == 11 && args.Cellphone.Substring(0, 2) == "09" && args.Cellphone.All(char.IsDigit)))
            {
                jr.CustomFields.Add("title", "خطا");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                jr.Message = "تلفن همراه را درست وارد کنید";
                jr.Status = false;
                return jr;
            }
            if (args.InviteID != 0 && GetbyInviteID(args.InviteID) == null)
            {
                jr.CustomFields.Add("title", "خطا");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                jr.Message = "کد معرف شناسایی نشد";
                jr.Status = false;
                return jr;
            }

            if (GetbyEmail(args.Email) != null)
            {
                jr.Message = "با این پست الکترونیک ثبت نام شده است،در صورتی که رمز عبور خود را فراموش کرده اید به قسمت بازیابی رمز عبور مراجعه کنید\n";
                jr.Status = false;
            }
            if (GetbyEmail(args.Cellphone) != null)
            {
                jr.Message = "تلفن همراه تکراری است\n";
                jr.Status = false;
            }

            if (!jr.Status)
            {
                return jr;
            }
            User newUserInstance = new User();
            newUserInstance.xEmail = args.Email;
            newUserInstance.xFullName = args.Fullname;
            newUserInstance.xCellphone = args.Cellphone;
            if (args.InviteID != 0)
            {
               newUserInstance.xInviter = GetbyInviteID(args.InviteID).xID;
                var InvitedUser = GetByID(newUserInstance.xInviter).Result;
                InvitedUser.xTotalInvitedUsers++;
                Update(InvitedUser);
            }
           newUserInstance.xIsActive = true;
           newUserInstance.xSalt = new EncryptionUtils().GenerateSalt();
           newUserInstance.xPassword = new EncryptionUtils().ComputeSha256Hash(args.Password + newUserInstance.xSalt);
           
           newUserInstance.xSignupDate = DateTime.Now.Date;
           newUserInstance.xActivationCode = new Random().Next(1000000, 10000000).ToString();
           newUserInstance.xCellphoneActivationCode = new Random().Next(1000000, 10000000).ToString();
           newUserInstance.xActivationCodeExpireAt = DateTime.Now.AddMinutes(15);//SectionInfo.Setting.ActivationCodeExpireInMins
           newUserInstance.xDescription = "";
           newUserInstance.xNationalIDNumber = "None";
            //newUserInstance.xInviteID
           newUserInstance.xSubscriptionExpireDate = DateTime.Now;


            try
            {
                Insert(newUserInstance);
                await Save();
                jr.CustomFields.Add("title", "خوش آمدید");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                jr.Message = "ثبت نام شما انجام شد ، لطفا وارد شوید";
                jr.Status = true;
            }
            catch (Exception e) {
                jr.CustomFields.Add("title", "خطا");
                jr.CustomFields.Add("confirmButtonText", "باشه");
                jr.Message = "خطا در ثبت نام ، با پشتیبانی تماس بگیرید";
                jr.Status = false;
            }
           

            return jr;
        }













    }
}
