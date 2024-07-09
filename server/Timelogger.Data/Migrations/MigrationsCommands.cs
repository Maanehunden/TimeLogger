using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timelogger.Data.Migrations
{
    public static class MigrationsCommands
    {
        public static string InserStartData => @"
            -- Insert initial data into Customers table
            INSERT INTO Customers (Name, Email) VALUES ('Acme Corp', 'contact@acme.com');
            INSERT INTO Customers (Name, Email) VALUES ('Globex Corporation', 'info@globex.com');

            -- Insert initial data into Projects table
            INSERT INTO Projects (Name, Deadline, CustomerId) VALUES ('Website Redesign', '2024-12-31', 1);
            INSERT INTO Projects (Name, Deadline, CustomerId) VALUES ('Mobile App Development', '2025-03-15', 2);

            -- Insert initial data into TimeRegistrations table
            INSERT INTO TimeRegistrations (ProjectId, Date, Hours) VALUES (1, '2024-07-01', 5.5);
            INSERT INTO TimeRegistrations (ProjectId, Date, Hours) VALUES (1, '2024-07-02', 3.0);
            INSERT INTO TimeRegistrations (ProjectId, Date, Hours) VALUES (2, '2024-07-01', 4.0);
         ";

        public static string InitCreate => @"
            -- Create Customers table
            CREATE TABLE Customers (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL
            );

            -- Create Projects table
            CREATE TABLE Projects (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Deadline DATETIME NOT NULL,
                CustomerId INTEGER NOT NULL,
                FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
            );

            -- Create TimeRegistrations table
            CREATE TABLE TimeRegistrations (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                ProjectId INTEGER NOT NULL,
                Date DATETIME NOT NULL,
                Hours REAL NOT NULL,
                FOREIGN KEY (ProjectId) REFERENCES Projects (Id)
            );";
    }
}
