1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

select * from users where id = 2 or id =3 or id=4;


2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
select first_name, last_name, 
count(case l.status when 2 then 1 else null end) as Basic,
count(case l.status when 3 then 1 else null end) as Premium
 from users u
 inner join  listings l
 on l.user_id = u.id
 where u.status = 2
 group by u.id


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium
select first_name, last_name, 
count(case l.status when 2 then 1 else null end) as Basic,
count(case l.status when 3 then 1 else null end) as Premium
 from users u
 inner join  listings l
 on l.user_id = u.id
 where u.status = 2
 group by u.id
 Having Count(Premium) > 1

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue
select u.first_name, u.last_name, currency, sum(price) as revenue 
 from clicks
 inner join listings l on l.id = clicks.listing_id
 right  join users u on l.user_id = u.id
 where u.status = 2 and  YEAR(clicks.created) = '2013'
 group by u.id,currency

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
insert into clicks(listing_id,price,currency) values (3,'4.00','USD');
select last_insert_id();

6. Show listings that have not received a click in 2013
- Please return at least: listing_name
select name from listings where id in (select distinct(listing_id) from clicks  where YEAR(created)!= '2013');

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
select DATE(created) as 'date',  count(listing_id) as total_listings_clicked, count(distinct l.user_id) as total_vendors_affected from clicks c
 inner join listings l
 on l.id = c.listing_id
 group by DATE(created)
 order by created


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
select u.first_name,u.last_name, group_concat(l.name) from listings l join users u on l.user_id=u.id where u.status =2
group by u.first_name,u.last_name