-- Problem 1.   Вмъкване на данни
use soft_uni;

insert into towns(name)
values('Sofia'),('Plovdiv'),('Varna'),('Burgas');

insert into departments (name, manager_id)
values ('Engineering',15)
,('Sales',16)
,('Marketing',17)
,('Software Development',18)
,('Quality Assurance',19);

insert into employees (first_name,middle_name,last_name , job_title,department_id,hire_date,salary)
values ('Petar','Petrov','Petrov','Senior Engineer',
    (
        select department_id from departments
        where name='Engineering'
        limit 1
    ),
    now(),4000);
    
    select * from towns;
    select * from departments;
    
-- Problem 2.	Основно избиране на всички полета
use soft_uni;
select * from towns;
select * from departments;
select * from employees;

-- Problem 3.	Основно избиране на няколко полета
select name from towns;
select name from departments;
select first_name,last_name,job_title,salary from employees;

-- Problem 4.	Увеличете заплатата на работника
use soft_uni;
select salary from employees;
update employees as s
set s.salary = s.salary * 1.1
where employee_id;