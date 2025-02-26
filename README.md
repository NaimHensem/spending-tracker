# Spending Tracker Web Application

## Overview
The **Spending Tracker Web Application** is a personal finance management tool built using **.NET MVC, Bootstrap, jQuery, and AJAX** in **Visual Studio 2022**. This web application allows users to log, track, and analyze their spending habits efficiently. It uses **Entity Framework** with **SQL Server** to store transactions and dynamically updates spending records on the homepage without requiring page refreshes. Users can **add, edit, and delete expenses**, view total spending, and switch to a **spending limit mode** for better budgeting.

## Features
- **Add Spending Records**: Users can log their spending with descriptions and amounts.
- **Edit and Delete Transactions**: Modify or remove records easily.
- **AJAX-powered Interactions**: Dynamic updates without refreshing the page.
- **Total Spending Calculation**: Displays the total amount spent.
- **Spending Limit Mode**: Allows users to set a budget mode.
- **Responsive UI**: Built with Bootstrap for a clean and accessible design.

## Technologies Used
- **.NET MVC (C#)** – Backend framework
- **Entity Framework** – Database integration
- **SQL Server** – Data storage
- **Bootstrap** – Frontend styling
- **jQuery & AJAX** – Dynamic content updates
- **Visual Studio 2022** – Development environment

## Setup Instructions
### Prerequisites
- **Visual Studio 2022** (with .NET MVC installed)
- **SQL Server (LocalDB or full version)**
- **Entity Framework**

### Installation Steps
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/your-username/spending-tracker.git
   cd spending-tracker
   ```
2. **Open in Visual Studio 2022.**
3. **Set up the database:**
   - Check the `Web.config` file and ensure the connection string points to your SQL Server instance.
   - Open **Package Manager Console** and run:
     ```sh
     Enable-Migrations
     Add-Migration InitialCreate
     Update-Database
     ```
4. **Run the Application:**
   - Press **F5** in Visual Studio or use the IIS Express button.

## Usage
1. Open the browser and navigate to `http://localhost:XXXX/Spending` (replace `XXXX` with the actual port number).
2. Start adding spending records using the form.
3. View and manage records dynamically with AJAX updates.
4. Use the Spending Limit Mode to track your budget.

## Troubleshooting
- **Database Issues**: If migration errors occur, try running:
  ```sh
  Update-Database -Force
  ```
- **AJAX Not Updating**: Ensure jQuery is properly included in the `_Layout.cshtml` file.
- **Visual Studio Build Errors**: Clean and rebuild the solution before running.

## License
This project is licensed under the **MIT License**.

---

### Author
Created by **[Naim Mahyuddin]** – feel free to contribute and improve the application!
