use geography;

-- Държави с реки
select country_name, river_name from countries as c
left join countries_rivers as cr
	on cr.country_code=c.country_code
left join rivers as r
	on r.id=cr.river_id
where continent_code='AF'
    order by country_name asc
    limit 5;
    
-- Държави без планини
select * from countries as c
left join mountains_countries as mc	
	on mc.country_code=c.country_code
left join mountains as m    
	on m.id=mc.mountain_id
where mountain_id is null;    

-- Планини в България
select m.mountain_range,p.peak_name,elevation from mountains as m
left join peaks as p on p.mountain_id=m.id
join mountains_countries as mc on mc.mountain_id=m.id
join countries as c on c.country_code=mc.country_code
where c.country_code='BG' and (p.id is null or p.id=
(select id from peaks where mountain_id=m.id order by elevation desc limit 1));

-- Служители без проект	
use soft_uni;

select * from employees as e
left join employees_projects as ep	on ep.employee_id=e.employee_id
left join projects as p
	on p.project_id=ep.project_id
where project_id is null;