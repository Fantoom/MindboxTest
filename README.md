[![=.NET Test](https://github.com/Fantoom/MindboxTest/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Fantoom/MindboxTest/actions/workflows/dotnet.yml)

```
Вопрос №1
Разместите код на Github и приложите ссылку. Если в задании что-то непонятно, опишите возникшие вопросы и сделанные предположения. Например, в комментариях в коде.
Задание:
- Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным

Вопрос №2
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
По возможности — положите ответ рядом с кодом из первого вопроса.
```

https://www.db-fiddle.com/f/rYUKRcKAm65FmYPWZbajFY/0
```sql
# создание таблицы
CREATE TABLE Products(
id INT PRIMARY KEY, 
name VARCHAR(255) NOT NULL);

CREATE TABLE Category(
id INT PRIMARY KEY,
name VARCHAR(255) NOT NULL);

CREATE TABLE ProductsCategory(
products_id INT NOT NULL,
category_id INT, #без not null, чтобы показать соответствие sql запроса требованию
FOREIGN KEY(products_id) REFERENCES Products(id) ON DELETE CASCADE,
FOREIGN KEY(category_id) REFERENCES Category(id) ON DELETE CASCADE);

INSERT INTO Products VALUES(1, 'Air Jordan 1'), (2, 'Timberland boots'), (3, 'Polo shirt'), (4, 'gloves');
INSERT INTO Category VALUES(1, 'Sneakers'), (2, 'Boots'), (3, 'Shirts');
INSERT INTO ProductsCategory VALUES(1, 1), (2, 2), (3, 3), (4, NULL);

#Запрос
SELECT Products.name AS product, Category.name AS category FROM Products
Left JOIN ProductsCategory ON Products.id = ProductsCategory.products_id
Left JOIN Category ON Category.id = ProductsCategory.category_id
ORDER BY product;
```
