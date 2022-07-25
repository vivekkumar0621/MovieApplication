create database MovieApplication;

use MovieApplication;

create table Movie(
MID int primary key auto_increment, 
MovieName nvarchar(80),
Plot nvarchar(80),
DateOfRelease nvarchar(80),
PID int,
PosterID int
);

insert into Movie (MovieName,Plot,DateOfRelease,PID,PosterID) values
('Planet Hulk','when the hulk become too dangerous','2010-02-02',1,1),
('Finding Hulk Hogan','One sided examination of fall and rise','2010-11-17',1,2),
('WWE : Hulk Hogan','The best and most memorable match','2006-10-17',1,3);

select * from Movie;

create table Actor(
AID int primary key auto_increment, 
ActorName nvarchar(50),
Bio nvarchar(100),
DOB nvarchar(15),
Gender nvarchar(10)
);

insert into Actor (ActorName,Bio,DOB,Gender) values
('Alphachino','Boss Baby','11-01-1990','Male'),
('Ben Affeck','Killer','11-02-1980','Male'),
('Brad Pit','Handsome Hunk','11-03-1987','Male'),
('Robert Downy','The Iron Man','11-04-1995','Male'),
('Christan Belly','Super Dancer','12-09-1965','Female');

select * from Actor;

create table Producer(
PID int primary key auto_increment, 
ProducerName nvarchar(50),
Bio nvarchar(100),
DOB nvarchar(15),
Company nvarchar(25),
Gender nvarchar(10)
);

insert into Producer (ProducerName,Bio,DOB,Company,Gender) values
('Asim Nath','One of the two russo brother','31-12-1997','Nath Production','Male');

select * from Producer;

create table MovieActor(
MID int,
AID int
);

insert into MovieActor values
(1,1),
(1,2),
(2,3),
(2,4),
(3,1),
(3,5);

select * from MovieActor;

create table Poster(
PosterID int primary key auto_increment,
PosterName nvarchar(100),
PosterLocation nvarchar(255)
);

insert into Poster (PosterName,PosterLocation) values
('Poster1','D:\\Git Project\\Poster'),
('Poster2','D:\\Git Project\\Poster');
('Poster3','D:\\Git Project\\Poster');

select * from Poster;
