# Flight Center Demo
Demo application using .Net Core, Angular 6, CQRS, EF Core 2. A test application developed illustrate .Net tools

## Design and Architecture
* Client side - Angular 6
* IDE - Visual studio - 2017
* Framework - Dot net core 2.0
* Application design - The application design is utilizing the CQRS (Command Query Responsibility Segregation)
* Data storage and accessing data - Reading is isolated from data writing; utilizing two different technologies. EF Core 2.0 and Fluent NHibernate. This approach is to better use of the CQRS deign pattern. 
* *  Write data to data storage - Entity Framework Core 2.0
* * Read data from data storage - Light weight Fluent NHibernate is used to retrieve data from the data storage.
* Database SQL Server
* Testing - Unit testing using NUnit 3.0

## How to run the application
* Download the solution from the GitHub
* Edit the connection string _Srikaran.ARFlights.Web -> appsettings.json_. This will pre-fill the database with sample records
