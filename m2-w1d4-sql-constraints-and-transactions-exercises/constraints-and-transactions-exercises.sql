-- Write queries to return the following:
-- The following changes are applied to the "pagila" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
INSERT INTO actor(first_name,last_name)
VALUES('Hampton','Avenue');

INSERT INTO actor(first_name,last_name)
VALUES('Lisa','Byway');
--test
SELECT * FROM actor;


-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
select * from language

INSERT INTO [dbo].[film]
           ([title]
           ,[description]
           ,[release_year]
           ,[language_id]
           ,[original_language_id]
           ,[length])
     VALUES
           ('Euclidean PI',
           'The epic story of Euclid as a pizza delivery boy in
			ancient Greece',
           2008,
           1
           ,1
           ,(3*60)+18
		   );

--test
SELECT * from film
WHERE title='Euclidean PI'

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

INSERT INTO film_actor(film_id,actor_id)
VALUES(1001,201)
INSERT INTO film_actor(film_id,actor_id)
VALUES(1001,202)


--test
SELECT f.film_id,a.actor_id FROM film f
JOIN film_actor fa ON f.film_id=fa.film_id
JOIN actor a ON a.actor_id=fa.actor_id
where f.title='Euclidean PI'

-- 4. Add Mathmagical to the category table.

INSERT INTO category(name) VALUES ('Mathmagical')

-- test
SELECT * FROM category


-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"

UPDATE film_category
	SET category_id=17
from film
join film_category fc ON fc.film_id=film.film_id
WHERE title='Euclidean PI' OR title='EGG IGBY' OR title='KARATE MOON' OR title='RANDOM GO' OR title='YOUNG LANGUAGE'



-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
select rating from film

UPDATE film
	SET rating='PG'
from film_category
JOIN film f ON f.film_id=film_category.film_id
JOIN category c ON c.category_id=film_category.category_id
WHERE c.name='Mathmagical'


-- 7. Add a copy of "Euclidean PI" to all the stores.


INSERT INTO inventory(film_id,store_id)
SELECT 1001,store_id from store

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)

DELETE FROM film WHERE title='Euclidean PI'

-- Considered as a frorgien key for 'actor' table

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)

DELETE FROM category WHERE name='Mathmagical'
-- considered as a forgien Key in film_category table 


-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)

DELETE FROM film_category 
WHERE category_id=17

-- YES, Becuase it's not a reference for a foriegn key

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)

DELETE FROM category WHERE name='Mathmagical' -- yes, It dosen't reference for a foriegn key 

DELETE FROM film WHERE title='Euclidean PI'   -- NO ,

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.

--Step 1
DELETE FROM film_actor 
WHERE film_id=1001

--Step 2
DELETE FROM inventory
WHERE film_id=1001

--Step 3
DELETE FROM film WHERE title='Euclidean PI'   -- NO ,


