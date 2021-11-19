create database Studenti

create table Studente(
IdStudente int constraint PK_Stud primary key,
Nome nvarchar(20) not null,
Cognome nvarchar(20) not null
);