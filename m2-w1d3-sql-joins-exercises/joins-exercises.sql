-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
--    Rows: 30

SELECT title from film f
INNER JOIN film_actor f_a ON f.film_id=f_a.film_id
INNER JOIN actor a ON a.actor_id=f_a.actor_id
WHERE a.first_name='Nick'AND A.last_name= 'Stallone' 

-- 2. All of the films that Rita Reynolds has appeared in
--    Rows: 20

SELECT title FROM film f
INNER JOIN film_actor fa ON f.film_id=fa.film_id
INNER JOIN actor a ON fa.actor_id=a.actor_id
WHERE a.first_name='Rita'AND A.last_name= 'Reynolds' 

-- 3. All of the films that Judy Dean or River Dean have appeared in
--    Rows: 46

SELECT title FROM film f
JOIN film_actor fa on f.film_id=fa.film_id
JOIN actor a ON fa.actor_id=a.actor_id
WHERE (a.first_name='Judy' AND a.last_name='Dean')OR (a.first_name='River' AND a.last_name='Dean')

-- 4. All of the the ‘Documentary’ films
--    Rows: 68

SELECT title FROM film f
JOIN film_category fc ON f.film_id=fc.film_id
JOIN category c ON c.category_id=fc.category_id
where c.name='Documentary'

-- 5. All of the ‘Comedy’ films
--    Rows: 58

SELECT title FROM film f
JOIN film_category fc ON f.film_id=fc.film_id
JOIN category c ON c.category_id=fc.category_id
where c.name='Comedy'


-- 6. All of the ‘Children’ films that are rated ‘G’
--    Rows: 10 

SELECT title FROM film f
JOIN film_category fc ON f.film_id=fc.film_id
JOIN category c ON c.category_id=fc.category_id
where c.name='Children' AND f.rating='G'



-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
--    Rows: 3

SELECT title FROM film f
JOIN film_category fc ON f.film_id=fc.film_id
JOIN category c ON c.category_id=fc.category_id
where c.name='Family' AND f.rating='G' AND f.length<120

-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
--    Rows: 9

SELECT title FROM film f
INNER JOIN film_actor fa ON f.film_id=fa.film_id
INNER JOIN actor a ON fa.actor_id=a.actor_id
WHERE a.first_name='Matthew'AND A.last_name= 'Leigh'AND f.rating='G'

-- 9. All of the ‘Sci-Fi’ films released in 2006
--    Rows: 61

SELECT title FROM film f
JOIN film_category fc ON fc.film_id=f.film_id
JOIN category c ON c.category_id=fc.category_id
WHERE c.name='Sci-Fi' AND f.release_year=2006

-- 10. All of the ‘Action’ films starring Nick Stallone
--     Rows: 2

SELECT title FROM film f
JOIN film_category fc ON fc.film_id=f.film_id
JOIN category c ON c.category_id=fc.category_id
INNER JOIN film_actor fa ON f.film_id=fa.film_id
INNER JOIN actor a ON fa.actor_id=a.actor_id
WHERE c.name='Action' AND a.first_name='Nick' AND a.last_name='Stallone'


-- 11. The address of all stores, including street address, city, district, and country
--     Rows: 2

Select a.address,c.city,a.district, co.country,a.postal_code FROM store s 
JOIN address a ON s.address_id=a.address_id
JOIN city c ON c.city_id=a.city_id
JOIN country co ON co.country_id=c.country_id

-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
--     Rows: 2

Select s.store_id,(st.first_name+' '+st.last_name)as Manager_Name,a.address,c.city,a.district, co.country,a.postal_code FROM store s 
JOIN address a ON s.address_id=a.address_id
JOIN staff st ON s.manager_staff_id=st.staff_id
JOIN city c ON c.city_id=a.city_id
JOIN country co ON co.country_id=c.country_id

-- 13. The first and last name of the top ten customers ranked by number of rentals 
--     Hint: #1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals

SELECT top 10 (c.first_name+' '+c.last_name) AS customer_name,count(r.rental_id) 
FROM store s
JOIN inventory inv ON inv.store_id=s.store_id
JOIN rental r ON r.inventory_id=inv.inventory_id
JOIN customer c ON c.customer_id=r.customer_id
GROUP BY (c.first_name+' '+c.last_name)
ORDER BY count(r.rental_id) DESC


-- 14. The first and last name of the top ten customers ranked by dollars spent 
--     Hint: #1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent

SELECT top 10 (c.first_name+' '+c.last_name) AS customer_name,sum(p.amount) 
FROM customer c
JOIN payment p ON c.customer_id=p.customer_id
GROUP BY (c.first_name+' '+c.last_name)
ORDER BY sum(p.amount) DESC

-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store 
--     Hint: Store 1 has 7928 total rentals and Store 2 has 8121 total rentals

SELECT s.store_id,ad.address,count(r.rental_id)AS rental_count,sum(p.amount) AS total_sale,AVG(p.amount) AS avg_sale 
FROM store s
JOIN address ad ON s.address_id=ad.address_id
JOIN inventory inv ON inv.store_id=s.store_id
JOIN rental r ON r.inventory_id=inv.inventory_id
JOIN payment p ON r.rental_id=p.rental_id
GROUP BY s.store_id,ad.address

-- 16. The top ten film titles by number of rentals 
--     Hint: #1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals

SELECT top 10 f.title,count (r.rental_id)AS rental_count
FROM film f
JOIN inventory inv ON f.film_id=inv.film_id
JOIN rental r ON r.inventory_id=inv.inventory_id
GROUP BY f.title
ORDER BY count (r.rental_id) DESC


-- 17. The top five film categories by number of rentals 
--     Hint: #1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals


SELECT top 5 c.name ,count (r.rental_id)AS rental_count
FROM film f
JOIN film_category fc ON fc.film_id=f.film_id
JOIN category c ON fc.category_id=c.category_id
JOIN inventory inv ON f.film_id=inv.film_id
JOIN rental r ON r.inventory_id=inv.inventory_id
GROUP BY c.name
ORDER BY count (r.rental_id) DESC

-- 18. The top five Action film titles by number of rentals 
--     Hint: #1 should have 30 rentals and #5 should have 28 rentals

SELECT top 5 f.title ,count (r.rental_id)AS rental_count
FROM film f
JOIN film_category fc ON fc.film_id=f.film_id
JOIN category c ON fc.category_id=c.category_id
JOIN inventory inv ON f.film_id=inv.film_id
JOIN rental r ON r.inventory_id=inv.inventory_id
WHERE c.name ='Action'
GROUP BY f.title
ORDER BY count (r.rental_id) DESC


-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
--     Hint: #1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals

SELECT top 10 (a.first_name+' '+a.last_name)as actor_name ,count (r.rental_id)AS rental_count
FROM film f

JOIN film_actor fa ON fa.film_id =f.film_id
JOIN actor a ON a.actor_id=fa.actor_id
JOIN inventory inv ON f.film_id=inv.film_id
JOIN rental r ON r.inventory_id=inv.inventory_id
GROUP BY (a.first_name+' '+a.last_name)
ORDER BY count (r.rental_id) DESC


-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
--     Hint: #1 should have 87 rentals and #5 should have 72 rentals

SELECT top 5 (a.first_name+' '+a.last_name)as actor_name ,count (r.rental_id)AS rental_count
FROM film f
JOIN film_category fc ON fc.film_id=f.film_id
JOIN category c ON fc.category_id=c.category_id
JOIN film_actor fa ON fa.film_id =f.film_id
JOIN actor a ON a.actor_id=fa.actor_id
JOIN inventory inv ON f.film_id=inv.film_id
JOIN rental r ON r.inventory_id=inv.inventory_id
WHERE c.name='Comedy'
GROUP BY (a.first_name+' '+a.last_name)
ORDER BY count (r.rental_id) DESC
