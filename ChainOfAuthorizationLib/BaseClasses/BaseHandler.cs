namespace ChainOfAuthorizationLib.BaseClasses
{
    public abstract class BaseHandler : IHandler
    {
        protected IHandler _nextHandler;
        public abstract bool Execute(IArgs obj);

        public void SetHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public bool ExecuteNext(IArgs obj)
        {
            if (_nextHandler is null) return false;

            return _nextHandler.Execute(obj);
        }
    }
}