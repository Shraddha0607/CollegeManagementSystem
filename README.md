# College Management System

This is a **College Management System** developed using **.NET Core** for the backend and **React** for the frontend. The application manages various aspects of a college system, including departments, students, staff, and more.

## Backend
- **Technology Used**: .NET Core API, Entity Framework, SQL Server
- The backend is built using **.NET Core** to expose RESTful API endpoints for managing the data.
- **Entity Framework** is used for database interactions, making it easier to manage models and perform CRUD operations.
- **SQL Server** is used as the database to store all the necessary data related to departments, staff, students, and more.
  
## Frontend
- **Technology Used**: React, JavaScript, HTML, CSS
- The frontend is built using **React**, with functional components and React Router for navigation between pages.
- The **Home Page** provides general information about the college and serves as a landing page.
- The **Admin Page** allows an administrator to manage departments, staff, and students using the backend API.

## Features
- **Admin Panel**: Admin can manage departments and staff.
- **User Interface**: A user-friendly UI created with React, allowing smooth navigation and interaction.
- **CRUD Operations**: Full CRUD functionality for managing departments and staff data.

## Setup and Installation

### Backend
1. Clone the repository for the backend code.
2. Open the project in **Visual Studio**.
3. Ensure **SQL Server** is set up on your local machine.
4. Update the connection string in the `appsettings.json` file to match your local SQL Server setup.
5. Run the **migrations** to create the necessary database tables using **Entity Framework**.
6. Start the application, and the API should be live.

### Frontend
1. Clone the repository for the frontend code.
2. Navigate to the frontend folder in the terminal.
3. Run `npm install` to install all dependencies.
4. Run `npm start` to start the development server.
5. The frontend should be live at `http://localhost:3000`.

## Knowledge Demonstration
- The backend uses **.NET Core API** with **Entity Framework** for smooth data access and **SQL Server** for efficient data storage.
- The frontend is developed using **React**, ensuring an interactive and modern user experience.
- I successfully connected the frontend to the backend, enabling the app to retrieve data, perform CRUD operations, and display it dynamically.
- Implemented routing in **React** using **React Router** to manage different pages like the home and admin page.
- Integrated both backend and frontend seamlessly to demonstrate full-stack web development skills.

---
