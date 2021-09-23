using ChainOfAuthorizationLib.BaseClasses;
using ChainOfAuthorizationLib.DataBase;

namespace ChainOfAuthorizationLib
{
    public class IdentificationHandler : BaseHandler
    {
        public override bool Execute(IArgs obj)
        {
            if (obj is not AuthArgs loginArgs) return false;

            var db = new DB();
            loginArgs.Account = db.GetAccountAsync(loginArgs.InputLogin).Result;
            
            return loginArgs.Account is not null && ExecuteNext(loginArgs);
        }
    }
}