Create table Usuarios (
UsuarioId int identity(1,1) primary key,
Nombres varchar(80),
NombreUsuario varchar(80),
Clave Varchar(15),
TipoUsuario int
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
Cantidad int
);

Create table Ventas(
VentaId int identity(1,1) primary key,
TipoVentaId int,
Medicina varchar(80),
Cantidad int,
FechaVenta date,
Total money
);

insert into TipoVentas(Descripcion) values ('Contado')
insert into TipoVentas(Descripcion) values ('Credito')

select * from Ventas

