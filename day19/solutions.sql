CREATE PROCEDURE proc_get_books_by_author(@first_name VARCHAR(50))
AS
BEGIN
    SELECT t.title AS book_title, p.pub_name AS publisher
    FROM titles t
    INNER JOIN titleauthor ta ON t.title_id = ta.title_id
    INNER JOIN authors a ON ta.au_id = a.au_id
    INNER JOIN publishers p ON t.pub_id = p.pub_id
    WHERE a.au_fname = @first_name;
END

CREATE PROCEDURE proc_get_titles_sold_by_employees(@first_name VARCHAR(20))
AS
BEGIN
    SELECT t.title, s.qty, t.price, s.qty * t.price AS cost
    FROM sales s
    INNER JOIN titles t ON s.title_id = t.title_id
    INNER JOIN employee e ON t.pub_id = e.pub_id
    WHERE e.fname = @first_name;
END

SELECT au_fname AS first_name, au_lname AS last_name FROM authors
UNION
SELECT fname, lname  FROM employee;

SELECT TOP 5
    t.title AS title,
    p.pub_name AS publisher,
    CONCAT(a.au_fname, ' ', a.au_lname) AS full_name,
    s.qty AS quantity_ordered,
    t.price AS price
FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id
INNER JOIN publishers p ON t.pub_id = p.pub_id
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id;