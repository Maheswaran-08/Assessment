Role-Based Access Control (RBAC) - E-Commerce App
This is a full-stack web application built using:

Backend: ASP.NET Core + Identity

Frontend: React.js

Database: MySQL

It manages user access to categories and products based on their group and premium status.


Features

Login system using ASP.NET Core Identity

Role-based access to categories/products

Premium users get access to exclusive category

Frontend displays allowed data only

SQL-based group/category/product mapping


Project Structure

RBACWebAPI/            ← .NET backend
rbac-app/              ← React frontend

Prerequisites
.NET SDK 6.0 or later

Node.js

MySQL Server

MySQL Workbench (optional, for DB access)
Setup Instructions
Backend Setup (ASP.NET Core API)


Run the backend:

Swagger will open at:


https://localhost:7202/swagger

Frontend Setup (React)

Run frontend:

npm start

http://localhost:3000


User Roles Logic
There are three types of users in the application, and access to categories and products is determined based on their group membership and premium status:

Normal User:
A normal user is not assigned to any group and does not have premium status. When such a user logs in, they should not be able to access any categories. Instead, the application will display a message saying "No data."

Group User (Non-Premium):
This type of user is assigned to one or more groups but is not marked as a premium user. These users can access only the categories that are mapped to the groups they belong to. However, they cannot view or access the premium category "Mobile Phones."

Premium Group User:
These users are assigned to one or more groups and are also marked as premium users. In addition to accessing the categories associated with their groups, they are also allowed to view the exclusive premium category called "Mobile Phones."


Test Data (SQL Inserts)

Categories
INSERT INTO Categories (Name) VALUES
('Men’s Clothing'), ('Women’s Clothing'), ('Jewelry'), ('Electronics'), ('Mobile Phones');

Groups
INSERT INTO `Groupss` (Name) VALUES ('Group A'), ('Group B'), ('Group C');

Group → Category mapping
INSERT INTO GroupCategories (GroupId, CategoryId)
VALUES
(1, 1), (1, 2),  -- Group A
(2, 1), (2, 3),  -- Group B
(3, 3), (3, 4);  -- Group C

Products
INSERT INTO Products (Name, Price, Description, CategoryId)
VALUES
('Shirt', 1200, 'Men cotton shirt', 1),
('Dress', 1500, 'Women summer dress', 2),
('Necklace', 3000, 'Gold plated', 3),
('Headphones', 2500, 'Noise-cancelling', 4),
('iPhone 14', 75000, 'Premium phone', 5),
('Samsung Galaxy S22', 70000, 'Flagship Android', 5);

User Insert Example (Email: admin@example.com, Password: Admin@123)
Instead of inserting manually, use ASP.NET Identity to register users or generate the password hash using C# as mentioned before.

How Access Works
User logs in with email/password

Backend checks:

If user is in any group

If user is premium

Categories are fetched:

Group-only categories

+Mobile Phones if user is premium

Frontend shows allowed categories and products only


