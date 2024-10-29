CREATE DATABASE country_AshritaDb;
USE country_AshritaDb;
CREATE TABLE tbl_country (
    country_id INT PRIMARY KEY,
    country_name VARCHAR(50),
    country_capital VARCHAR(50),
    country_currency VARCHAR(50),
    country_continent VARCHAR(50)
);

INSERT INTO tbl_country (country_id, country_name, country_capital, country_currency, country_continent)
VALUES
    (1, 'United States', 'Washington, D.C.', 'US Dollar', 'North America'),
    (2, 'Canada', 'Ottawa', 'Canadian Dollar', 'North America'),
    (3, 'United Kingdom', 'London', 'Pound Sterling', 'Europe'),
    (4, 'Australia', 'Canberra', 'Australian Dollar', 'Oceania'),
    (6, 'India', 'New Delhi', 'Indian Rupee', 'Asia');

SELECT * FROM tbl_country;