# ﻿Library Management System

## Project Overview
The **Library Management System** is a console-based application developed in C# using Object-Oriented Programming (OOP) principles and LINQ. It provides separate functionalities for both **admin** and **customer** roles. The admin can manage the library’s collection and members, while customers can browse and borrow books.

## Features

### 1. Admin Section
Admins have access to a variety of features to manage the library effectively, including:

- **Add Book**: Add new books to the library's collection by providing details such as title, author, ISBN, and quantity.
- **Delete Book**: Remove books from the library's collection using the ISBN or title.
- **Add Member**: Register new members by entering their name and contact information.
- **Delete Member**: Remove existing members from the library database using their membership ID.
- **View All Books**: Display a list of all available books in the library, including their titles, authors, and availability status.
- **View All Members**: Display a list of all registered members, including their membership ID and contact information.
- **Search about Book**: Give the admin permission to use the book's name to look it up.

### 2. Customer Section
Customers have access to the following features to interact with the library:

- **View All Books**: Browse the library's collection to see the list of available books.
- **Borrow Book**: Borrow a book by selecting it from the list of available books. The system checks the availability and updates the records accordingly.
- **Return Book**: Return a borrowed book to the library. The system updates the book's status to available and records the return.

## Technologies Used
- **C#**: The project is built using C# to implement OOP concepts such as classes, inheritance, and polymorphism.
- **LINQ**: Used for data manipulation and querying the in-memory collections of books and members efficiently.

## How to Run the Project
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the project to ensure there are no compilation errors.
4. Run the application, and use the command-line interface to navigate through the admin and customer functionalities.

## Future Enhancements
- Implement a graphical user interface (GUI) using Windows Forms or WPF.
- Add more functionalities like  filter, and sort for books and members.
- Implement a database to store books and members information persistently.
