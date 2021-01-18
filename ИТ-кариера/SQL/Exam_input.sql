create database TripService;
use TripService;

create table Cities
(
Id int not null auto_increment unique primary key,
Name nvarchar (20) not null ,
CountryCode nvarchar (2) not null
);

create table Hotels
(
Id int not null auto_increment unique primary key,
Name nvarchar(30) not null,
CityId int not null ,
constraint fk_hotels_CityId
foreign key (CityId)
references Cities(Id),

EmployeeCount int not null,
BaseRate decimal(2)
);

create table Rooms
(
Id int not null auto_increment unique primary key,
Price decimal(2) not null,
Type nvarchar(20) not null,
Beds int not null,
HotelId int not null,
constraint fk_rooms_HotelId
foreign key (HotelId)
references Hotels(Id)
);

create table Trips
(
Id int not null auto_increment unique primary key,
RoomId int not null,
constraint fk_trips_RoomId
foreign key (RoomId)
references Rooms(Id),

BookDate date not null,
ArrivalDate date not null,
ReturnDate date not null,
CancelDate date
);

create table Accounts
(
Id int not null auto_increment unique primary key,
FirstName nvarchar(50) not null,
MiddleName nvarchar(20),
LastName nvarchar(50) not null,
CityId int not null ,
constraint fk_accounts_CityId
foreign key (CityId)
references Cities(Id),

BirthDate date not null,
Email nvarchar(100) not null unique
);

create table AccountsTrips
(
AccountId int not null,
TripId int not null,
primary key(AccountId,TripId),

constraint fk_accountsTrips_accountId
foreign key(AccountId)
references Accounts(Id),

constraint fk_accountsTrips_tripId
foreign key(TripId)
references Trips(Id),

Luggage int not null
);

