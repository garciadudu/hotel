# hotel

#Exercicio - 01

Pasta 06-Testes no projeto ConstructoIT.Hotel.Accor.Testes, tem um teste de unidade QuintoDiaUtilTest.

#Exercicio - 02

SQL Gerado:

select c.Bairro AS Bairro, SUM(m.QuantidadeBichosEstimacao)
from Condominio c
inner join Familia f on f.Id_Condominio=c.Id
inner join Morador m on m.Id_Familia=f.Id

group by c.Bairro

union all

select c.Bairro AS Bairro, 0
from Condominio c
where not Exists(select * from Familia f where f.Id_Condominio=c.Id)

order by Bairro;

#Exercicio - 03

Projeto

Dotnet Core 3.1, C#, MVC, HTML5, CSS3 e SQL Server

Na pasta 02-Infraestrutura encontrasse o projeto ConstructoIT.Hotel.Accor.Infraestrutura.Repository com o DbContext ConstructoItDbContext

Alterar a linha a string de conexão neste ponto.

            optionsBuilder.UseSqlServer("server=DESKTOP-QL4VEUH;database=banco; Trusted_Connection=True;");
            
Após inserir a string de conexão do banco de dados sql server. 
Rodar dotnet ef database update --context ConstructoItDbContext

Para rodar a aplicação, trocar a conexão Na pasta, 04-Api projeto ConstructoIT.Hotel.Accor.Api.

appsettings.json

Na string de conexão

  "SqlConnection": {
    "ConnectionString": "server=DESKTOP-QL4VEUH;database=banco; Trusted_Connection=True;"
  }
  
Após isto rodar os dois projetos de api e site juntos, para possa subir a aplicação e o site.

