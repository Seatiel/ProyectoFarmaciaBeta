Create table Usuarios (
UsuarioId int identity(1,1) primary key,
Nombre varchar(80),
Apellido varchar(80),
Email varchar(50),
NombreUsuario varchar(30),
Clave Varchar(20),
ConfirmarClave varchar(20),
);

Create table Categorias(
CategoriaId int identity(1,1) primary key,
Descripcion varchar(80)
);

Create table Laboratorios(
LaboratorioId int identity(1,1) primary key,
Nombre varchar(80),
FechaIngreso date
);

Create table Medicinas(
MedicinaId int identity(1,1) primary key,
Nombre varchar(80),
Descripcion varchar(80),
PrecioVenta money,
PrecioCompra money,
FechaVencimiento date,
CantidadExistencia int,
LaboratorioId int,
Especificaciones varchar(100),
CategoriaId int
);


Create table TipoVentas(
TipoVentaId int identity(1,1) primary key,
Descripcion varchar(80)
);

create table VentasDetalle(
DetalleId int identity(1,1) primary key,
VentaId int,
MedicinaId int,
Medicina varchar(80),
Cantidad int,
Precio money,
Monto money,
Descuento money 
);

Create table Ventas(
VentaId int identity(1,1) primary key,
TipoVentaId int,
FechaVenta date,
Cantidad int,
SubTotal money,
ITBIS money,
Total money
);

insert into TipoVentas(Descripcion) values ('Contado')
insert into TipoVentas(Descripcion) values ('Credito')

insert into Categorias(Descripcion) values ('Calmantes')

select * from Categorias


TRUNCATE TABLE Medicinas
