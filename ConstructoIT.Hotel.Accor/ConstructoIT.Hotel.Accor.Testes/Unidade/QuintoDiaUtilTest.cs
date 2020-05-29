using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using Xunit;

namespace ConstructoIT.Hotel.Accor.Testes
{
    public class QuintoDiaUtilTest
    {
        [Fact]
        public void ComoUsuarioQueroPassarUmaDataEmReceberOQuintoDiaUtilIgualAoDia5()
        {
            var novaData = DateTime.Now.QuintoDiaUtil();

            Assert.Equal(5, novaData.Day);
        }
    }
}
