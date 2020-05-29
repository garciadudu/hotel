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