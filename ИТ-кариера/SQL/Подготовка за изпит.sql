create database BuhtigSourceControl;
use BuhtigSourceControl;

create table Users
(
  id int auto_increment primary key,
  username varchar(30) not null unique,
  password varchar(30) not null,
  email varchar(50) not null
);

create table Repositories
(
  id int auto_increment primary key,
  name varchar(50) not null
);

create table Repositories_Contributors
(
  repository_id int,
  constraint fk_repositoryID_repositories_contributors
  foreign key (repository_id)
  references Repositories(id),
  
  contributor_id int,
  constraint fk_contributorID_repositories_contributors
  foreign key (contributor_id)
  references Users(id)
);

create table Issues
(
  id int auto_increment primary key,
  title varchar(255) not null,
  issue_status varchar(6) not null,
  repository_id int not null,
  
  constraint fk_repository_ID_issues
  foreign key (repository_id)
  references Repositories(id),
  
  assignee_id int not null,
  constraint fk_assigneeID_issues
  foreign key (assignee_id)
  references Users(id)
);

create table Commits
(
  id int auto_increment primary key,
  message varchar(255) not null,
  issue_id int,
  
  constraint fk_issueID_commits
  foreign key (issue_id)
  references Issues(id),
  
  repository_id int not null,
  constraint fk_repositoryID_commits
  foreign key (repository_id)
  references Repositories(id),
  
  contributor_id int not null,
  constraint fk_contributorID_commits
  foreign key (contributor_id)
  references Users(id)
);

create table Files
(
  id int auto_increment primary key,
  name varchar(100) not null,
  size double(10,2) not null,
  
  parent_id int,
  constraint fk_parentID_files
  foreign key (parent_id)
  references Files(id),
  
  commit_id int not null,
  constraint fk_commitID_files
  foreign key (commit_id)
  references Commits(id)
);

-- 01.Потребители
use BuhtigSourceControl;
select id,username from users
order by id asc;

-- 02. Късметлийски числа
select repository_id,contributor_id from repositories_contributors
where repository_id=contributor_id
order by repository_id,contributor_id asc;

-- 03.Проблеми и потребители
select i.id, concat(username,':',title ) as 'issue_assignee' from issues as i
join users as u on u.id=i.assignee_id
order by i.id desc;

-- 04.Файлове без директории
select id, name, concat(size, "KB") as '' from files
where id not in (
select distinct (parent_id) from files
where parent_id is not null);

-- 05.Активни хранилища
select r.id, r.name, count(repository_id) from repositories as r
join issues as i on i.repository_id=r.id
group by repository_id
order by count(repository_id) desc;

-- 06.Хранилището с най-много участници
select r.id,r.name, count(cr.contributor_id) as 'contributors'  from repositories as r
join repositories_contributors as cr on cr.repository_id=r.id
group  by r.id
order by count(cr.contributor_id) desc;

-- 07.    Хранилища и потребители
select r.id,r.name, count(c.repository_id) as 'commits'  from repositories as r
join commits as  c on c.repository_id=r.id
group  by r.id
order by count(c.repository_id) desc;
