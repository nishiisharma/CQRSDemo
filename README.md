
# ⚽ CQRSPlayerDemo – ASP.NET Core Web App

**CQRSPlayerDemo** is a clean and modular ASP.NET Core 8.0 web application built using the **CQRS (Command Query Responsibility Segregation)** pattern. It demonstrates CRUD operations for managing football players with features like validation, search, and pagination.

---

## ✨ Features

- ✅ **CQRS Pattern** – Clean separation of read and write operations using commands and queries.
- ✅ **Create Player with Image Upload** – Upload and display player profile images.
- ✅ **Validation** – Server-side (Data Annotations) and client-side (jQuery) validation.
- ✅ **Search Functionality** – Search players by Name or Goals.
- ✅ **Pagination** – Paginated player list with configurable page size.

---

## 🧪 Validations

| Field  | Rule                                  |
|--------|---------------------------------------|
| Name   | Required, minimum length              |
| Age    | Must be between 18 and 40             |
| Goals  | Must be a positive integer            |

---

## 📁 Project Structure

```
CQRSPlayerDemo/
├── Controllers/               # PlayerController (handles HTTP requests)
├── Data/                      # AppDbContext for EF Core
├── Features/Players/          # CQRS structure for Player entity
│   ├── Commands/              # Write operations
│   │   ├── CreatePlayerCommand.cs
│   │   ├── DeletePlayerCommand.cs
│   │   └── UpdatePlayerCommand.cs
│   └── Queries/               # Read operations
│       ├── GetAllPlayerQuery.cs
│       ├── GetPlayerByIdQuery.cs
│       └── GetPlayersWithPaginationQuery.cs
├── Migrations/                # EF Core migrations
├── Models/                    # Entity models (e.g., Player.cs)
├── Services/                  # Interfaces and implementations for player logic
├── Views/
│   ├── Player/
│   │   ├── Index.cshtml       # List players with search + pagination
│   │   ├── Create.cshtml      # Player creation with image upload
│   │   └── Details.cshtml     # Player details
│   └── Shared/                # Layout and validation partials
├── wwwroot/                   # Static assets (CSS, JS, images)
└── Program.cs                 # App startup and middleware config
```

---

## 🛠️ Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core (Code First)
- MediatR-like CQRS architecture
- Razor Pages / MVC Views
- Bootstrap 5
- JavaScript / jQuery

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Web-Dev-Kombee/CQRSPlayerDemo.git
cd CQRSPlayerDemo
```

### 2. Configure Database

Update the `appsettings.json` file with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CQRSPlayerDb;Trusted_Connection=True;"
}
```

### 3. Apply Migrations

```bash
dotnet ef migrations add FinalCreate
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

Then navigate to `https://localhost:5001` in your browser.

---

## 📸 Output

## Add Player :
![image](https://github.com/user-attachments/assets/821e3fab-0bed-4f35-a2ad-e484c9966412)

## Dashboard:
![image](https://github.com/user-attachments/assets/315d2958-d4ee-4c08-89ea-b53d470cc64c)

## Detail Of Player
![image](https://github.com/user-attachments/assets/5571415f-4013-4bf8-a7f9-e41fcca9a62b)

## Search
![image](https://github.com/user-attachments/assets/202dc448-5705-411c-855c-07d2d78b8a70)

## Edit
![image](https://github.com/user-attachments/assets/3d3331c2-63a6-4bf8-9ca9-808e102126a9)

---

## 🤝 Contributions

Contributions are welcome!  Follow these steps to contribute:

1. Fork the repository.
2. Create a new branch for your feature/fix.
3. Commit changes and open a **Pull Request**.
   
---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👨‍💻 **Author**

**Kombee Technologies**

- 🌐 [Portfolio](https://github.com/kombee-technologies)
- 💼 [LinkedIn](https://in.linkedin.com/company/kombee-global)
- 🌍 [Website](https://www.kombee.com/)

---

<p align="center">
Enjoy building with ❤️ clean architecture and CQRS!
</p>

---
