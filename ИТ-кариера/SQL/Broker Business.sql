create database broker_business_db;
use broker_business_db;

create table cities
(
  id int auto_increment primary key,
  name varchar(45) not null,
  country_name varchar(60) not null
);

create table companies
(
  id int auto_increment primary key,
  name varchar(45) not null,
  rate int not null,
  created_on date not null
);

create table building_types
(
  id int auto_increment primary key,
  name varchar(30) not null unique
);

create table persons
(
  id int auto_increment primary key,
  username varchar(30) not null unique,
  company_id int,
  constraint fk_companyID_persons
  foreign key (company_id)
  references companies(id),
  city_id int not null,
  constraint fk_cityID_persons
  foreign key (city_id)
  references cities(id)
);

create table person_info
(
  id int auto_increment primary key,
  first_name varchar(60) not null,
  last_name varchar(60),
  money decimal(15,2) default 0,
  person_id int not null,
  constraint fk_personID_person_info
  foreign key (person_id)
  references persons(id)
);

create table buildings
(
  id int auto_increment primary key,
    name varchar(80) not null unique,
    rent_amount decimal(17,2) not null,
    height decimal(15,2) not null,
    floors int,
    finished_year int,
    status varchar(50) not null,
    city_id int not null,
    type_id int not null,
    company_id int not null,
    constraint fk_buildings_cities
        foreign key (city_id)
        references cities (id),
    constraint fk_buildings_building_types
        foreign key (type_id)
        references building_types (id),
    constraint fk_buildings_companies
        foreign key (company_id)
        references companies (id)
);

create table persons_buildings
(
  person_id int not null,
  building_id int not null,
    primary key (person_id,building_id),
    constraint fk_persons_buildings_persons
        foreign key (person_id)
        references persons (id),
    constraint fk_persons_buildings_buildings
        foreign key (building_id)
        references buildings (id)
);

-- 01: Хора
use broker_business_db;
select id, username, company_id from persons
where city_id=10 and company_id is not null
order by username asc, id asc;

-- 02: Заети сгради
SELECT id, name as building_name, rent_amount, height, status 
FROM buildings
WHERE rent_amount > 5000 AND height > 500
ORDER BY rent_amount DESC, building_name ASC;

-- 03: Компания West
select p.id,p.username,pi.first_name,pi.last_name,c.name as 'company_name' from persons as p
join person_info as pi on pi.person_id=p.id
join companies as c on c.id=p.company_id
where c.name = 'West'
order by pi.first_name asc, pi.last_name asc;

-- 04: Първите 15
select p.username, cmp.name as 'company_name', c.name as 'city_name', c.country_name from persons as p
join cities as c on c.id=p.city_id
left outer join companies as cmp on cmp.id=p.company_id
where p.id<=15
order by cmp.id asc, p.username asc;

-- 05: Типове сгради
select but.name as 'building_types',count(bu.id) as 'buildings_count', max(bu.rent_amount) as 'max_rent_amount', min(bu.rent_amount) as 'min_rent_amount' from buildings as bu
join building_types as but on but.id=bu.type_id
group by but.name
order by count(bu.id) desc;

-- 06: Поръчки по държави
select bu.name as 'building_name', bt.name as 'building_type', bu.status as 'status', c.name as 'city_name', count(p.id) as 'persons_count'  from buildings as bu
join building_types bt on bt.id = bu.type_id
join cities as c on c.id = bu.city_id
join persons_buildings pb on pb.building_id = bu.id
join persons p on p.id = pb.person_id
GROUP BY bu.id
order by persons_count desc
limit 20;

-- 07: Поръчки от род
select c.name, b.status, SUM(b.rent_amount) AS 'sum', COUNT(b.id) AS 'buildings_count' FROM companies as c
 INNER JOIN buildings b ON b.company_id = c.id
 GROUP BY c.id, b.status HAVING sum > 150000
 ORDER BY sum DESC, buildings_count DESC
