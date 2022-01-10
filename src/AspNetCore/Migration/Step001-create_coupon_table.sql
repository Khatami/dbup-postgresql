CREATE TABLE IF NOT EXISTS coupon
(
	id SERIAL PRIMARY KEY NOT NULL,
	productname VARCHAR(24) NOT NULL,
	description Text,
	amount INT
);