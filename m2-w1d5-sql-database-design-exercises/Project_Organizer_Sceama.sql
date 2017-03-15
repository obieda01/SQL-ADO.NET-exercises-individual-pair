-- CREATE DATABASE ProjectOrganizer;

BEGIN TRANSACTION


-- Create Department Table

CREATE TABLE department
(
	departmentNumber int not null unique,
	name VARCHAR(50) not NULL,
	constraint pk_departmentNumber_ primary key (departmentNumber)
);






-- Create Project Table

CREATE TABLE project
(
	projectNumber int not null unique,
	name VARCHAR(50) not NULL,
	startDate datetime not null,

	constraint pk_projectNumber_ primary key (projectNumber)
);




-- Create Employee Table

CREATE TABLE employee
(
	employeeNumber int not null unique,
	job_Title VARCHAR(50) not NULL,
	lastName VARCHAR(50) not NULL,
	firstName VARCHAR(50) not NULL,
	gender  VARCHAR(1) not NULL,
	birthday datetime  ,
	hiredate datetime,
	departmentNumber int not null ,
	projectNumber int not null,
	constraint pk_employeeNumber_ primary key (employeeNumber),
	constraint fk_departmentNumber_ foreign key (departmentNumber) references department(departmentNumber),
	constraint fk_projectNumber_ foreign key (projectNumber) references project(projectNumber),
    CONSTRAINT ck_employee CHECK (gender = 'M' OR gender='F'),

);



COMMIT;