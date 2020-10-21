/* SCHEMA using 'CREATE TABLE', this is only done manually at the very start of the application or if you need a "fresh" database */

/* DANGER THIS WILL DESTROY THE TABLE AND ALL ITS DATA PERMENANTLY */

/* DROP TABLE wishlistproducts;
DROP TABLE reviews;
DROP TABLE products;
DROP TABLE wishlists; */

/* CREATE TABLE profiles
(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),
  PRIMARY KEY (id)
);

CREATE TABLE products
( 
  id INT NOT NULL AUTO_INCREMENT,
  title VARCHAR(255) NOT NULL,
  description VARCHAR(255),
  price DECIMAL(6, 2) NOT NULL,
  creatorId VARCHAR(255) NOT NULL, 
  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
   REFERENCES profiles (id)
   ON DELETE CASCADE
);

CREATE TABLE wishlists 
( 
  id INT NOT NULL AUTO_INCREMENT, 
  title VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL, 
  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
   REFERENCES profiles (id)
   ON DELETE CASCADE
);

CREATE TABLE reviews
(
  id INT AUTO_INCREMENT, 
  title VARCHAR(255) NOT NULL,
  body VARCHAR(255) NOT NULL,
  rating INT,
  CHECK (rating > 0 AND rating < 6),
  productId INT,
  creatorId VARCHAR(255) NOT NULL, 
  PRIMARY KEY (id),
  
  INDEX (productId),

  FOREIGN KEY (creatorId)
   REFERENCES profiles (id)
   ON DELETE CASCADE,

  FOREIGN KEY (productId) 
    REFERENCES products (id)
    ON DELETE CASCADE
);
CREATE TABLE wishlistproducts
(
  id INT AUTO_INCREMENT,
  productId INT,
  wishlistId INT,
  PRIMARY KEY (id),

  FOREIGN KEY (productId) 
    REFERENCES products (id) 
    ON DELETE CASCADE,

  FOREIGN KEY (wishlistId) 
    REFERENCES wishlists (id)
    ON DELETE CASCADE
); */








/* POST */
/* INSERT INTO products (title, description, price) VALUES ("Squatty Potty", "Helps you loo", 34.92);
INSERT INTO products (title, description, price) VALUES ("Back Scratcher", "Gets that Itch", 1.01);
INSERT INTO products (title, description, price) VALUES ("Plumbus X", "Helps you", 1334.92);
INSERT INTO products (title, description, price) VALUES ("Plumbus", "Helps you", 134.92);
INSERT INTO products (title, description, price) VALUES ("Snozberry", "Tastes Like Snozberries", 12.12); */

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