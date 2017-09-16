create database empleados;
use database empleados;

create table Empleado(
	Id_Empleado int primary key identity(1,1),
	nombre varchar(250),
	apellido varchar(250),
	sueldo float

);