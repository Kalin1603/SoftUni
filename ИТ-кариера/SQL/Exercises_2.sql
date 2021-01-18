-- Problem 1.	Адреси с градове
use soft_uni;
select first_name,last_name,a.address_text,t.name from employees as e
join addresses as a on a.address_id=e.address_id
join towns as t on a.town_id=t.town_id
order by first_name,last_name asc
limit 5;

-- Problem 2.	Служители, наети по-късно
use soft_uni;
select first_name,last_name,hire_date,d.name from employees as e
join departments as d on d.department_id=e.department_id
where hire_date>1/1/1999 and d.name in('Finance','Sales')
order by hire_date;


-- Problem 3.	Служители с проект
use soft_uni;
select e.employee_id, first_name, p.name from employees as e
join employees_projects as ep on ep.employee_id=e.employee_id
join projects as p on p.project_id=ep.project_id
where p.start_date>13/08/2002 and end_date is null
order by first_name,p.name
limit 5; 

-- Problem 4.	Резюме на служителите
use soft_uni;
select e.employee_id, concat(e.first_name,' ',e.last_name) as employee_name, m.first_name as manager,d.name from employees as e
join employees as m on e.manager_id=m.employee_id
join departments as d on d.department_id=e.department_id
limit 5;

-- Problem 5.	Най-високи върхове в България
use geography;
