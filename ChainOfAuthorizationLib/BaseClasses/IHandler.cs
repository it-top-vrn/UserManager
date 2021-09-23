namespace ChainOfAuthorizationLib.BaseClasses
{
    public interface IHandler
    {
        public bool Execute(IArgs obj);
    }
}