using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services
{
    public class ConstrutoITValidationException: Exception
    { 
        public ConstrutoITValidationException(string message, IDictionary<string, IEnumerable<string>> errors): this(message, errors, null)
        {

        }

        public ConstrutoITValidationException(string message, IDictionary<string, IEnumerable<string>> erros, Exception innerException): base(message, innerException)
        {
            Errors = erros;
        }

        public IDictionary<string, IEnumerable<string>> Errors { get;  }
    }
}
