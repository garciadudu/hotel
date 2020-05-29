using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services
{
    public class ConstrutoITInvalidRequestException: Exception
    {
        public ConstrutoITInvalidRequestException(string message) : base(message)
        {

        }

        public ConstrutoITInvalidRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
