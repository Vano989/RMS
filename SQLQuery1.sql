create table users
(
	ID int primary key identity,
	username varchar(50) not null unique, 
	pass varchar(10) not null,
	fullName varchar(50) not null,
	phoneNumber varchar(15),
)

