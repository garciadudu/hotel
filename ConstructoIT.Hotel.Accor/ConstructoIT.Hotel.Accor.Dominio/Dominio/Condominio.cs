using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Domain.Entities
{
    public class Condominio
    {
        public int Id { get; set; }

        [Column(TypeName = ("varchar(256)"))]
        public string Nome { get; set; }
        [Column(TypeName = ("varchar(256)"))]
        public string Bairro { get; set; }

        public virtual List<Familia> Familias { get; set; }
    }
}
