using System.Diagnostics.SymbolStore;

namespace ChainOfAuthorizationLib
{
    public interface IHandler
    {
        public bool Execute(IArgs obj);
    }
}