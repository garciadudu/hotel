using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.AplicaoDTO.DTO
{
    public class FamiliaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Id_Condominio { get; set; }
        public string Condominio { get; set; }

        public int Apto { get; set; }

    }
}
