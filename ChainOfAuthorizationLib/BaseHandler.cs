namespace ChainOfAuthorizationLib
{
    public abstract class BaseHandler : IHandler
    {
        protected IHandler _nextHandler;
        protected IArgs _result;
        public abstract bool Execute(IArgs obj);

        public void SetHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public bool ExecuteNext()
        {
            if (_nextHandler is null) return false;

            return _nextHandler.Execute(_result);
        }
    }
}