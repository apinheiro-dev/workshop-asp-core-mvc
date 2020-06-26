using System;

namespace VendasWebMVC.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string mensagem) : base(mensagem)
        {
        }

    }
}
