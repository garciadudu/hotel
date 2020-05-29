using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Domain.Entities
{
    public static class MinhaData
    {
        public static DateTime QuintoDiaUtil(this DateTime data) {
            var novaData = data.AddDays(-data.Day + 1);

            // Ideia cadastrar no banco de dados

            List<DateTime> listaFeriados = new List<DateTime>
            {
                new DateTime(2020,1, 1),
                new DateTime(2020,2,24),
                new DateTime(2020,2,25),
                new DateTime(2020,4,10),
                new DateTime(2020,4,21),
                new DateTime(2020,5,1),
                new DateTime(2020,6,11),
                new DateTime(2020,9,7),
                new DateTime(2020,10,12),
                new DateTime(2020,11,2),
                new DateTime(2020,11,15),
                new DateTime(2020,12,25),
            };


            for (var x=0; x<5; x++)
            {

                if (novaData.DayOfWeek == DayOfWeek.Saturday) novaData = novaData.AddDays(1);
                if (novaData.DayOfWeek == DayOfWeek.Sunday) novaData = novaData.AddDays(1);

                if (listaFeriados.Where(x => x.Day == novaData.Day && x.Month == novaData.Month && x.Year == x.Year).Any())
                {
                    novaData = novaData.AddDays(1);
                }
                else
                {
                    novaData = novaData.AddDays(1);
                }
            }

            return novaData;
        }

    }
}
