# BookShop

BookShop is an ASP.NET Core MVC web application for managing a book store. It allows users to browse, add, edit, and delete books, authors, publishers, and genres. Users can also add books to a shopping cart.

## Features

- User authentication and authorization using ASP.NET Core Identity.
- CRUD operations for books, authors, publishers, and genres.
- Filter books by genre.
- Add books to a shopping cart.
- Pagination for book lists.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap 4
- X.PagedList

## Getting Started

### Prerequisites

- .NET 7.0 SDK or later
- SQL Server

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/Ivo-Handzhiyski/BookShop.git
    cd BookShop
    ```

2. Set up the database:

    - Update the connection string in `appsettings.json` to point to your SQL Server instance.
    - Run the following command to create the database and apply migrations:

    ```bash
    dotnet ef database update
    ```

3. Build and run the application:

    ```bash
    dotnet build
    dotnet run
    ```

4. Open your browser and navigate to `https://localhost:5001`.

### Usage

1. Register a new user account.
2. Sign in with the newly created account.
3. Use the navigation menu to access different sections of the application:
    - **Books**: View the list of books, add new books.
    - **Authors**: Add authors.
    - **Publishers**: Add publishers.
    - **Genres**: Add genres.
4. Add books to the shopping cart and view the cart.

## Project Structure

- `Controllers`: Contains the controllers for handling HTTP requests.
- `Models`: Contains the data models and Entity Framework Core configurations.
- `Views`: Contains the Razor views for rendering HTML pages.
- `ViewModels`: Contains the view models used for passing data between controllers and views.

## Acknowledgements
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Bootstrap](https://getbootstrap.com/)
= [PagedList](https://github.com/dncuug/X.PagedList)
