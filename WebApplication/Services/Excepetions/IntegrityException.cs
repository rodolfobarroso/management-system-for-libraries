using System;

namespace WebApplication.Services.Excepetions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(String message) : base(message)
        {

        }
    }
}
