CREATE DATABASE VehicleBase  
GO  
USE VehicleBase
GO

  DROP table dbo.VehicleMake
  GO
  DROP table dbo.VehicleModel
  GO

Create table dbo.VehicleMake
(
    ID int PRIMARY KEY identity ,
	Name varchar(50),
	Abrv varchar(50)
)

Create table dbo.VehicleModel
(
     ID int primary key identity ,
	MakeId int foreign key references VehicleMake(id),
	Name varchar(50),
	Abrv varchar(50)
)
GO 
Insert into VehicleMake values ( 'BMW','BMV')
Insert into VehicleMake values ( 'Ford','Ford')
Insert into VehicleMake values ( 'Volswagen','VW')
GO

Insert into VehicleModel values ( 1,'X1','BMW')
Insert into VehicleModel values ( 1,'X2','BMW')
Insert into VehicleModel values ( 1,'X3','BMW')
Insert into VehicleModel values ( 1,'318','BMW')
Insert into VehicleModel values ( 1,'320','BMW')
Insert into VehicleModel values ( 2,'Focus','Ford')
Insert into VehicleModel values ( 2,'EcoSport','Ford')
Insert into VehicleModel values ( 3,'Golf','VW')
Insert into VehicleModel values ( 3,'Polo','VW')
GO 