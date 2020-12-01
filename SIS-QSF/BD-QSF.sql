create database sisqsf;
use sisqsf;

create table usuarios
(
ClaveUsuario int auto_increment primary key,
NoControl varchar(50) null,
Nombre varchar(100) not null,
EsAlumno enum('Si','No') not null,
Telefono varchar(50) null,
Correo varchar(100) not null
);

create table administrador
(
Nombre_usuario varchar(100) primary key,
Clave_usuario varchar(50) not null
);

create table qsf
(
ClaveQSF int auto_increment,
Fecha date not null,
Prioridad enum('Alta','Media','Baja') not null,
Estatus	enum('No iniciada','En proceso','Finalizada','Rechazada') not null,
Tipo_Servicio enum('Queja','Sugerencia','Felicitacion') not null,
Departamento enum('Academico','Vinculacion','Planeacion','Calidad','Administracion') not null,
Descripcion longtext not null,
Observaciones longtext null,
UsuarioSolicitante int not null,
primary key(ClaveQSF, UsuarioSolicitante),
constraint foreign key(UsuarioSolicitante) 
references usuarios(ClaveUsuario)
on update cascade on delete cascade
);