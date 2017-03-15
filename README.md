 <p align="center" >
 <img src="http://i.imgur.com/k7ZpbL1.png" height="150" width="130">


</p>
# Normalization Exercises

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
![Build Status](https://travis-ci.org/anfederico/Clairvoyant.svg?branch=master)
![bitHound](https://img.shields.io/bithound/code/github/rexxars/sse-channel.svg)
![Test Coverage](https://img.shields.io/codecov/c/github/codecov/example-python.svg)
![Join the chat at https://gitter.im/github-changelog-generator/chat](https://badges.gitter.im/github-changelog-generator/chat.svg)
![Contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg)
![License](https://img.shields.io/badge/Licence-Ahmad-blue.svg)


# Project Organizer Database Access


## Part 1 (Day 1) - Data Access Layer

**Setup:** Create a SQL Server database using the attached SQL script `projects.sql`. 

Complete the CLI application for the project database by implementing the `DepartmentSqlDAL`, `EmployeeSqlDAL`, and `ProjectSqlDAL`.

## Part 2 (Day 2) - Integration Testing

Create a Unit Test project for the **ProjectDB** application. Implement integration tests for the `DepartmentSqlDAL`, `EmployeeSqlDAL`, and `ProjectSqlDAL` classes.

Be sure to clean up any test data so that the database is returned to its original state after the test is completed.



## Animal Hospital Health History Report

You are helping an animal hospital migrate to a new database platform and part of the work involves
designing the new database that will store animal health data.

The hospital has provided an example health history report that they would like to be able to generate
and you need to design your data model to support this.

Work with your partner to create an ER diagram and ensure that the design supports 1NF, 2NF, and 3NF when
possible. The submission that you provide should include the SQL scripts necessary to create the database
and any additional constraints (primary keys, foreign keys, etc.)

Feel free to make some assumptions about the data model but make sure that they are documented at the top
of the script if they influence your design decision.

![Copy of Animal Health Report](etc/normalization-exercise-1.jpg)  

## Animal Hospital Health Invoice

You are now designing the data needed for issuing animal hospital invoices.

![Copy of Animal Hospital Invoice](etc/normalization-exercise-2.jpg)

Work with your parther to create an ER diagram for this exercise ensuring that it adheres to 1NF, 2NF, and 3NF when possible.
The submission that you provide should be in a separate SQL file and include the script necessary to create the database tables
and any additional constraints (primary keys, foreign keys, etc.)


# Project Organizer Database Access


## Part 1 (Day 1) - Data Access Layer

**Setup:** Create a SQL Server database using the attached SQL script `projects.sql`. 

Complete the CLI application for the project database by implementing the `DepartmentSqlDAL`, `EmployeeSqlDAL`, and `ProjectSqlDAL`.

## Part 2 (Day 2) - Integration Testing

Create a Unit Test project for the **ProjectDB** application. Implement integration tests for the `DepartmentSqlDAL`, `EmployeeSqlDAL`, and `ProjectSqlDAL` classes.

Be sure to clean up any test data so that the database is returned to its original state after the test is completed.




# File I/O Part 1 Exercises

## WordSearch

### Part 1

Write a program that, asks the user for a search string and a filesystem path for a text file. When executing it searches the file for occurrences of the search string and each time it finds the search string, displays the line number and contents of the line it was found in on the console. 

As a special treat, and a break from arrays, line numbers begin with 1.

Use `alices_adventures_in_wonderland.txt` for test input.

The initial output should start with:
```
1) Project Gutenberg's Alice's Adventures in Wonderland, by Lewis Carroll
9) Title: Alice's Adventures in Wonderland
43) [Illustration: "Alice"]
```

### Part 2

Modify the program to ask the user if the search should be case insensitive.

Use `alices_adventures_in_wonderland.txt` for test input.
       
The output should change to:
```
1) Project Gutenberg's Alice's Adventures in Wonderland, by Lewis Carroll
9) Title: Alice's Adventures in Wonderland
41) ALICE'S ADVENTURES IN WONDERLAND
43) [Illustration: "Alice"]
```

<div style="page-break-after: always;"></div>

## QuizMaker (Challenge)

Create a quiz maker program which asks the user a question. They should be presented with the possible multiple choice answers and allowed to specify the correct answer.

The program should read the questions from an input file during startup. The questions and answers in the file will be pipe delimited | and correct answers will be marked with an asterisk in the file.

```
Question-1|answer-1|answer-2|correct-answer*|answer-4
```

Example file

```
What color is the sky?|Yellow|Blue*|Green|Red
What are Cleveland's odds of winning a championship?|Not likely*|Highly likely|Fat chance|Who cares??
```

**Tips**

* Create a class that can hold a quiz question, its available answers, and the correct answer.
* Try holding each quiz question in a list of quiz questions

### Step 1

Ask a single question to the user when the application is opened. Don't show the asterisk in the list of choices.

Example
```
What color is the sky?
1. Yellow
2. Blue
3. Green
4. Red

Your answer: 2

Sorry that isn't correct!
``` 

### Step 2

Go through all of the available quiz questions and ask the user each one sequentially. Record how many answers they got correct and print out the total at the end.

Example
```
What color is the sky?
1. Yellow
2. Blue
3. Green
4. Red

Your answer: 2

Sorry that isn't correct!

What are the Cleveland Browns' odds of winning a championship?
1. Not likely
2. Highly likely
3. Fat chance
4. Who cares??

Your answer: 1

RIGHT!

You got 1 answer(s) correct out of the total 2 questions asked
```.