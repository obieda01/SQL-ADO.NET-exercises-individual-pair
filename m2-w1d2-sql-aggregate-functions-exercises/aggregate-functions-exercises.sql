-- The following queries utilize the "world" database.
-- Write queries for the following problems.
-- Notes:
--   GNP is expressed in units of one million US Dollars
--   The value immediately after the problem statement is the expected number
--   of rows that should be returned by the query.

-- 1. The name and state plus population of all cities in states that border Ohio
-- (i.e. cities located in Pennsylvania, West Virginia, Kentucky, Indiana, and
-- Michigan).
-- The name and state should be returned as a single column called
-- name_and_state and should contain values such as ‘Detroit, Michigan’.
-- The results should be ordered alphabetically by state name and then by city
-- name.
-- (19 rows)


SELECT (name + ', ' + district) as name_and_state
FROM city
WHERE district='Pennsylvania' OR district='West Virginia' OR district='Michigan'
OR district='Indiana' OR district='Kentucky'
ORDER BY district, name;



-- 2. The name, country code, and region of all countries in Africa.  The name and
-- country code should be returned as a single column named country_and_code
-- and should contain values such as ‘Angola (AGO)’
-- (58 rows)

SELECT (name+' ('+code2+')')AS country_and_code ,region
FROM country
WHERE continent='Africa'

-- 3. The per capita GNP (i.e. GNP divided by population) of all countries in the
-- world sorted from highest to lowest
-- (232 rows)

SELECT (GNP/population) as Per_capita_GNP
FROM country
WHERE  population <> 0
ORDER BY (GNP/population) desc

-- 4. The average life expectancy of countries in South America.
-- (average life expectancy in South America: 70.9461)

select avg(lifeexpectancy)
from country
where continent='South America'

-- 5. The sum of the population of all cities in California.
-- (total population of all cities in California: 16716706)

select sum(population)
from city
where district='California'

-- 6. The sum of the population of all cities in China.
-- (total population of all cities in China: 175953614)

select sum(population)
from city
where countrycode='chn'

-- 7. The maximum population of all countries in the world.
-- (largest country population in world: 1277558000)

select max(population)
from country


-- 8. The maximum population of all cities in the world.
-- (largest city population in world: 10500000)

select max(population) max_city_population
from city


-- 9. The maximum population of all cities in Australia.
-- (largest city population in Australia: 3276207)

select max(population) max_population
from city
where countrycode='AUS'

-- 10. The minimum population of all countries in the world.
-- (smallest_country_population in world: 50)

select min(population) min_population
from country
where population<> 0

-- 11. The average population of cities in the United States.
-- (avgerage city population in USA: 286955.3795)

select avg(population) USA_Avg_population
from city
where countrycode='USA'

-- 12. The average population of cities in China.
-- (average city population in China: 484720.6997 approx.)


select AVG(population) as Chani_cities_population
from city
where countrycode='chn'


-- 13. The surface area of each continent ordered from highest to lowest.
-- (largest continental surface area: 31881000, "Asia")

select continent,sum(surfacearea)
from country
group by continent
order by sum(surfacearea) desc



-- 14. The highest population density (surface area divided by population) of all
-- countries in the world.
-- (highest population density in world: 38.6801)

select (surfacearea/population) as population_dinsity
from country
where population<>0
order by (surfacearea/population) desc

-- 15. The population density and life expectancy of the top ten countries with the
-- highest life expectancies in descending order.
-- (highest life expectancies in world: 83.5, 0.006, "Andorra")

select top 10 name,(surfacearea/population) as population_dinsity, lifeexpectancy
from country
order by lifeexpectancy desc


-- 16. The difference between the previous and current GNP of all the countries in
-- the world ordered by the absolute value of the difference. Display both
-- difference and absolute difference.
-- (smallest difference: 1.00, 1.00, "Ecuador")

select name,(GNP-GNPold)as difference_GNP,ABS(GNP-GNPold)as abs_difference_GNP
from country
where (GNP-GNPold) IS NOT NULL
order by abs_difference_GNP asc

-- 17. The average population of cities in each country (hint: use city.countrycode)
-- ordered from highest to lowest.
-- (highest avg population: 4017733.0000, "SGP")

select avg(population)as avg_pop,countrycode
from city
group by countrycode
order by avg(population) desc

-- 18. The count of cities in each state in the USA, ordered by state name.
-- (45 rows)

select count(name) as cityCount,district
from city
where countrycode='USA'
group by district
order by  district asc


-- 19. The count of countries on each continent, ordered from highest to lowest.
-- (highest count: 58, "Africa")


select count(name)as country_count ,continent
from country
group by continent
order by count(name) desc

-- 20. The count of cities in each country ordered from highest to lowest.
-- (largest number of  cities ib a country: 363, "CHN")

select count(name)as city_count, countrycode
from city
group by countrycode
order by city_count desc


-- 21. The population of the largest city in each country ordered from highest to
-- lowest.
-- (largest city population in world: 10500000, "IND")

select max(population)as max_city_population,countrycode
from city
group by countrycode
order by max_city_population desc

-- 22. The average, minimum, and maximum non-null life expectancy of each continent
-- ordered from lowest to highest average life expectancy.
-- (lowest average life expectancy: 52.5719, 37.2, 76.8, "Africa")

select avg(lifeexpectancy)as avg_lifeexpectancy,MIN(lifeexpectancy)as min_lifeexpectancy,max(lifeexpectancy)as max_lifeexpectancy,continent
from country
where lifeexpectancy IS NOT NULL
group by continent
order by avg(lifeexpectancy) asc
