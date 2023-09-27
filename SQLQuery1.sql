create database SistemadeReservas;

go

use SistemadeReservas;

create table Rol(
Id int not null identity(1,1),
Nombre nvarchar(30) not null,
primary key(Id)
);
go

create table Usuario(
Id int not null identity(1,1),
IdRol int not null,
Nombre nvarchar(30) not null,
Apellido nvarchar(30) not null,
Login nvarchar(30) not null,
Password nvarchar(30) not null,
estatus nvarchar(30) not null,
FechaRegistro datetime not null,
primary key(Id),
foreign key(IdRol) references Rol(Id)
);
go

create table Servicio(
Id int not null identity (1,1), 
Nombre nvarchar(100) not null,
Estado nvarchar(50) not null,
primary key(id)
);
go

create table mesa(
id int not null identity (1,1),
Tipo nvarchar(50) not null,
Estado nvarchar(30) not null,
primary key(id)
);
go


create table Reserva(
Id int not null identity (1,1),
IdMesa int not null,
idServicio int not null,
Cliente nvarchar(200) not null,
Telefono nvarchar (15) not null,
Fecha datetime not null,
Personas int not null,
HorarioEntrada nvarchar(20) not null,
HorarioSalida nvarchar(20) not null,
primary key(Id),
foreign key(IdMesa) references Mesa(Id),
foreign key(IdServicio) references Servicio(Id)

);
go


