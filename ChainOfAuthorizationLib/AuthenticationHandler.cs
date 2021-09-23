using ChainOfAuthorizationLib.BaseClasses;

namespace ChainOfAuthorizationLib
{
    public class AuthenticationHandler : BaseHandler
    {
        public override bool Execute(IArgs obj)
        {
            if (obj is not AuthArgs args) return false;

            return args.InputPassword == args.Account.Password && ExecuteNext(args);
        }
    }
}