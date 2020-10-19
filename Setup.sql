/* SCHEMA using 'CREATE TABLE', this is only done manually at the very start of the application or if you need a "fresh" database */

/* DANGER THIS WILL DESTROY THE TABLE AND ALL ITS DATA PERMENANTLY */
/* DROP TABLE products; */

-- CREATE TABLE products
-- ( 
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   price DECIMAL(6, 2) NOT NULL,

--   PRIMARY KEY (id)
-- );

/* POST */
INSERT INTO products (title, description, price) VALUES ("Squatty Potty", "Helps you loo", 34.92);
INSERT INTO products (title, description, price) VALUES ("Back Scratcher", "Gets that Itch", 1.01);
INSERT INTO products (title, description, price) VALUES ("Plumbus X", "Helps you", 1334.92);
INSERT INTO products (title, description, price) VALUES ("Plumbus", "Helps you", 134.92);
INSERT INTO products (title, description, price) VALUES ("Snozberry", "Tastes Like Snozberries", 12.12);

/* GET ALL */
/* SELECT * FROM products; */

/* GET BY _____ */
/* SELECT * FROM products WHERE id = 2; */
/* SELECT * FROM products WHERE title LIKE "Plum%"; */


/* PUT */
/* UPDATE products
SET
  title = "Squatty Potty Deluxe",
  description = "Helps you loo",
  price = 34.92
WHERE id = 1; */

/* SELECT * from products; */

/* DELETE */
/* DELETE FROM products WHERE title LIKE "Plum%";
SELECT * FROM products; */