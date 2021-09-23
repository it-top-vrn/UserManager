using System;

namespace ChainOfAuthorizationLib.TestHands
{
    class Program
    {
        static void Main(string[] args)
        {
            var ident = new IdentificationHandler();
            var auth = new AuthenticationHandler();
            
            auth.SetHandler(null);
            ident.SetHandler(auth);

            var arg = new AuthArgs { InputLogin = "admin", InputPassword = "123"};
            var res = ident.Execute(arg);
            Console.WriteLine(res);
        }
    }
}