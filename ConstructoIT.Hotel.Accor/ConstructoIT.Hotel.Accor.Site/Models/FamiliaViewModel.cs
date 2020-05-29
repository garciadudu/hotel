using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Models
{
    public class FamiliaViewModel
    {
        public FamiliaViewModel()
        {

        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Id_Condominio { get; set; }
        public string Condominio { get; set; }
        public int Apto { get; set; }

    }
}
