using ChainOfAuthorizationLib.BaseClasses;
using ChainOfAuthorizationLib.DataBase;

namespace ChainOfAuthorizationLib
{
    public class AuthArgs : IArgs
    {
        public string InputLogin { get; set; }
        public string InputPassword { get; set; }
        
        public Account Account { get; set; }
    }
}