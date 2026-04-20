# Personal Budget Tracker

A robust C# application designed to help users manage their finances by tracking income and expenses. This project follows a tiered architecture (N-Tier) to ensure clean code separation and scalability.

## 🚀 Features
- **Transaction Management:** Add, view, and track daily income and expenses.
- **Data Persistence:** Integrated with a SQL database for secure and permanent storage.
- **Tiered Architecture:** Separated into Data Access (DAL), Business Logic (BL), and User Interface (UI) layers.

## 🛠️ Tech Stack
- **Language:** C#
- **Framework:** .NET
- **Database:** Microsoft SQL Server
- **Architecture:** N-Tier (UI, BL, DAL)

## 📁 Project Structure
The repository is organized into the following modules:
- **`UI`**: The presentation layer where users interact with the system.
- **`BL` (Business Logic)**: Contains the core logic and rules for budget calculations.
- **`DAL` (Data Access Layer)**: Handles all database operations (Queries, Inserts, Updates).
- **`TestConsole`**: A sandbox environment for testing backend logic.
- **`Database Script.txt`**: Contains the SQL commands needed to set up your local database.

## ⚙️ Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/EidAlHadidi/Personal-Budget-Tracker.git](https://github.com/EidAlHadidi/Personal-Budget-Tracker.git)
