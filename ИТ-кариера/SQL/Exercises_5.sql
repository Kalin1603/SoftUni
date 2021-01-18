use gringotts;
-- Брой на записи
select count(id) as 'Count' from wizzard_deposits;

-- Най-дългата магическа пръчка
select max(magic_wand_size) from wizzard_deposits;

-- Сума на депозитите по група
select deposit_group as 'Name', sum(deposit_amount) as 'Sum' from wizzard_deposits
group by deposit_group;

select  max(age),min(age), deposit_group from wizzard_deposits
group by deposit_group;

-- Най-дългата магическа пръчка по депозитна група
select deposit_group, max(magic_wand_size) as 'longest_magic_wand' from wizzard_deposits
group by deposit_group
order by max(magic_wand_size) desc, deposit_group;

-- Най-малката депозитна група с най-малката магическа пръчка
select deposit_group from wizzard_deposits
group by deposit_group
order by avg(magic_wand_size) asc
limit 1;