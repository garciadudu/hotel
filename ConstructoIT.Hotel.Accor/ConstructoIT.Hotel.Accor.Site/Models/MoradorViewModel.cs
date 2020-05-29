using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Models
{
    public class MoradorViewModel
    {
        public MoradorViewModel()
        {

        }


        public int Id { get; set; }
        public int Id_Familia { get; set; }
        public string Nome { get; set; }
        public int QuantidadeBichosEstimacao { get; set; }
        public string Familia { get; set; }

    }
}
