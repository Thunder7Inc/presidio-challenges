SELECT * FROM cd.facilities;

SELECT name, membercost FROM cd.facilities;

SELECT * FROM cd.facilities where membercost > 0;

SELECT facid, 'name', membercost, monthlymaintenance
FROM cd.facilities
WHERE membercost > 0 AND membercost < monthlymaintenance / 50;

SELECT *
FROM cd.facilities
WHERE 'name' LIKE '%tennis%';

SELECT *
FROM cd.facilities
WHERE facid IN (1, 5);

SELECT "name",
CASE WHEN monthlymaintenance > 100 THEN 'expensive' ELSE 'cheap' END AS 'cost'
FROM cd.facilities;

SELECT memid, surname, firstname, joindate
FROM cd.members
WHERE joindate >= '2012-09-01';

SELECT DISTINCT surname
FROM cd.members
ORDER BY surname
LIMIT 10;

SELECT surname FROM cd.members
UNION DISTINCT
SELECT name FROM cd.facilities;

SELECT MAX(joindate) AS latest
FROM cd.members;

SELECT firstname, surname, joindate
FROM cd.members
WHERE joindate = (SELECT MAX(joindate) FROM cd.members);

-- solutions2

SELECT title FROM titles;

SELECT * FROM titles WHERE pub_id = '1389';

SELECT * FROM titles WHERE price BETWEEN 10 AND 15;

SELECT * FROM titles WHERE price IS NULL;

SELECT * FROM titles WHERE title LIKE 'the%';

SELECT * FROM titles WHERE title NOT LIKE '%v%';

SELECT * FROM titles ORDER BY royalty;

SELECT *
FROM titles
ORDER BY pub_id DESC, type ASC, price DESC;

SELECT type, AVG(price) AS avg_price
FROM titles
GROUP BY type;

SELECT DISTINCT type FROM titles;

SELECT type FROM titles GROUP BY type;

SELECT TOP 2 * FROM titles ORDER BY price DESC;

SELECT title
FROM titles
WHERE type = 'business' AND price < 20 AND advance > 7000;

SELECT pub_id, COUNT(title_id)
FROM titles
WHERE price BETWEEN 15 AND 25
AND title LIKE '%it%'
GROUP BY pub_id
HAVING COUNT(title_id) > 2
ORDER BY COUNT(title_id) ASC;

SELECT *
FROM authors
WHERE state = 'CA';

SELECT state, COUNT(*) AS num_authors
FROM authors
GROUP BY state;