using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System;
using System.Data.SQLite;
using Dapper;

namespace Homework27
{
    public static class Database
    {

        private static readonly string connectionString = "Data Source=MailingList.db;Version=3;";

        public static void CreateTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                connection.Execute(@"
                    CREATE TABLE IF NOT EXISTS Countries (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS Cities (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        CountryId INTEGER NOT NULL,
                        FOREIGN KEY (CountryId) REFERENCES Countries(Id) ON DELETE CASCADE
                    );

                    CREATE TABLE IF NOT EXISTS Buyers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        BirthDate TEXT NOT NULL,
                        Gender TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        CityId INTEGER NOT NULL,
                        FOREIGN KEY (CityId) REFERENCES Cities(Id) ON DELETE CASCADE
                    );

                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS BuyerCategories (
                        BuyerId INTEGER NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        PRIMARY KEY (BuyerId, CategoryId),
                        FOREIGN KEY (BuyerId) REFERENCES Buyers(Id) ON DELETE CASCADE,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
                    );

                    CREATE TABLE IF NOT EXISTS PromoProducts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        CountryId INTEGER NOT NULL,
                        StartDate TEXT NOT NULL,
                        EndDate TEXT NOT NULL,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE,
                        FOREIGN KEY (CountryId) REFERENCES Countries(Id) ON DELETE CASCADE
                    );
                ");
            }
        }
    }
}
    
