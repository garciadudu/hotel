using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Domain.Entities
{
    public class Familia
    {
        public int Id { get; set; }

        [Column(TypeName = ("varchar(256)"))]
        public string Nome { get; set; }

        public int Id_Condominio { get; set; }
        public Condominio Condominio { get; set; }
        public int Apto { get; set; }

        public virtual List<Morador> Moradores { get; set; }
    }
}
