namespace ChainOfAuthorizationLib
{
    public class IdentificationHandler : BaseHandler
    {
        
        
        public override bool Execute(IArgs obj)
        {
            if (obj is LoginArgs loginArgs)
            {
                //TODO Запрос к БД

                _result = loginArgs;

                return true;
            }

            return false;
        }
    }
}