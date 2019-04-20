# Software-Guild-Work
This contains all assignments that I turned in as work to the Software Guild. There are numerous subprojects, and as I get the time to, I will add explanations of each individual purpose.

# First Half: C# OOP
## Hello Guild & Hello World
Both of these projects were used as introductions to committing on Git, using Bitbucket and Crucible, and tying commits to Jira issues.

## Warmups
###### Week 1
These were a number of exercises given early in the course to help practice core programming concepts, such as dealing with loops and arrays. The entire Tests project and BLL documentation and framework were prewritten. 
The task was to get at least half of the tests to pass, with the goal of each method written in the corresponding txt file in the BLL Docs folder, and to do more as time permitted.
At some point, I may finish these for completion's sake.

## RockPaperScissors
###### Week 1
This project was to create a relatively basic console application for a player to face the computer in Rock Paper Scissors.
This was one of the earliest projects.

## Factorizor2
###### Week 2
This project was a relatively simple calculator to determine a given number's factors, and whether or not it was a prime number or a perfect number.
This project was used as an introduction to unit testing, as well as having separate projects and layers in applications.

## Battleship
###### Week 2
This project was considered by many to be a very difficult project. The entire BLL and Test projects were prewritten, and the instructions were to finish writing the game without modifying existing code.
This was an exercise in working with others' code, and determining the purpose of unknown code by looking at tests, then being able to build on top of said code.
Additionally, this was further practice in writing unit tests.

## LINQExercises
###### Week 3
This project was my first proper introduction to LINQ. Similarly to Warmups, a list of specifications for each method was given, and the task was to use LINQ to complete the given task. Foreach loops were only to be used in printing data, and not in operations. Everything other than Program.cs was prewritten.

## SGBank
###### Week 4
This project was what I would consider the first major undertaking. It represented an introduction to dependency injection, interfaces, and mocking. 
It represented a banking application, and the code for a basic account that could only be deposited into, as well as the start of the UI, was prewritten. I was tasked with creating 2 other account types from specifications, adding more features to the UI, making all accounts able to withdraw with specific guidelines, and write unit tests for all of it. The specs were broken down into very specific numbered tasks, making it quite easy to plan what needed to be done at what time, similar to being a junior developer continuing a senior developer's already-planned work.

## FlooringMastery
###### Weeks 5 & 6
This represented the final project of the solely OOP-focused half of the course.
It is a console-based application made to handle orders for a fictional flooring company, using multiple implementations of an order repository with CRUD functionality, as well as a layered application structure.
Unfortunately, I feel as though I could have done much better in my layering, and making sure that my code is single-purposed. If I get the chance, I want to rewrite portions of it. That being said, it is fully functional and unit-tested.

# Second Half: C# DDWA
## (Not Uploaded) Hotel Reservation System
###### Week 7
I do not currently have this file uploaded to GitHub, which may change in the future, but this week was an introduction to SQL, both DDL and DML. The goal of this project was to set up the schema (and some mock data) for a fictional hotel, including means of storing rooms, reservations, customers, amenities, and so on.

## VendingMachine
###### Week 8
This project was both a refresher on HTML, CSS (especially Bootstrap), and JS, as well as an introduction to jQuery, AJAX, and getting data from a REST API. The specs and wireframes of the desired website (which was set up to simulate a vending machine with money entry, change return, and item selection) were provided. The API was a closed box, and only the compiled `.jar` and documentation on how to use it were provided.

Additionally, during this week, we were given a challenge of working with a public weather API and creating our own web-based weather app, which I may upload to GitHub in the future. If I do so, I will link that here.

## MVC-SIS (Student Information System)
###### Week 9
This project was an introduction to ASP .NET MVC Applications. It was structured somewhat akin to the SGBank project, where the application was partially completed, and detailed specifications were provided on what still needed to be added. The backend of the application represents a standard CRUD repository structure.
This project was also an introduction to Razor, and to server-side validation methods, such as `ModelState` and `ValidationAttribute`.

## DvdLibraryAPI
###### Week 10
This project is a full-fledged RESTful API that uses factory classes and dependency injection to switch methods of storing and retrieving data, including EntityFramework, ADO, and a mock repository. A working front-end website from a previous assignment was to be used as the front end, and this API was to replace the old one. I also built the SQL database used in the program.

## CarDealership
###### Weeks 10-12
This was the final individual project for the course. It represents a full-stack web application that acts as the website for a car dealership, with sections for both customers, sales staff, and admins (managers). I built the application to be mostly separable (loosely coupled Data and UI layers), so the majority of data access is done through AJAX calls to an API that runs within the application, but due to time constraints and some logistical issues, not all of the project was created separably. Time permitting, I would like to work further on this project as well.
The full commit history is in the separate repository I used while coding, which can be found [here](https://github.com/Flutterdashie/CarDealership)
