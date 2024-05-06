SELECT s.stor_id, COUNT(*) AS num_orders
FROM sales s
JOIN stores st ON s.stor_id = st.stor_id
GROUP BY s.stor_id;

SELECT t.title, COUNT(s.title_id) AS num_orders
FROM titles t
JOIN sales s ON t.title_id = s.title_id
GROUP BY t.title;

SELECT p.pub_name, t.title
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id;

SELECT CONCAT(au_fname, ' ', au_lname) AS full_name
FROM authors;

SELECT title, price, price + (price * 12.36 / 100) AS price_including_tax
FROM titles;

SELECT CONCAT(a.au_fname, ' ', a.au_lname) AS author_name, t.title
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id;

SELECT CONCAT(a.au_fname, ' ', a.au_lname) AS author_name, t.title, p.pub_name AS publisher_name
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id;

SELECT p.pub_name, AVG(t.price) AS average_price
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id
GROUP BY p.pub_name;

SELECT DISTINCT t.title
FROM titles t
JOIN titleauthor ta ON t.title_id = ta.title_id
JOIN authors a ON ta.au_id = a.au_id
WHERE a.au_fname = 'Marjorie' OR a.au_lname = 'Marjorie';

SELECT s.ord_num
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
WHERE p.pub_name = 'New Moon Books';

SELECT p.pub_name, COUNT(*) AS num_orders
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
GROUP BY p.pub_name;

SELECT s.ord_num, t.title, s.qty, t.price, s.qty * t.price AS total_price
FROM sales s
JOIN titles t ON s.title_id = t.title_id;

SELECT t.title, SUM(s.qty) AS total_quantity
FROM sales s
JOIN titles t ON s.title_id = t.title_id
GROUP BY t.title;

SELECT t.title, SUM(s.qty * t.price) AS total_order_value
FROM sales s
JOIN titles t ON s.title_id = t.title_id
GROUP BY t.title;

SELECT orders.order_id
FROM orders
JOIN titles ON orders.title_id = titles.title_id
JOIN publishers ON titles.pub_id = publishers.pub_id
JOIN authors ON publishers.pub_id = authors.pub_id
WHERE authors.au_fname = 'Paolo';