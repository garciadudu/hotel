using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Domain.Entities
{
    public class Morador
    {
        public int Id { get; set; }
        public int Id_Familia { get; set; }
        [Column(TypeName = ("varchar(256)"))]
        public string Nome  { get; set; }
        public int QuantidadeBichosEstimacao { get; set; }

        public virtual Familia Familia { get; set; }
    }
}
