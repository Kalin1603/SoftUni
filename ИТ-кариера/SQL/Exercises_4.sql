-- Игри на континенти
use geography;

select c1.continent_name as 'From', c2.continent_name as 'To' from continents as c1
cross join continents as c2 
      order by c1.continent_name, c2.continent_name;
      
      

 