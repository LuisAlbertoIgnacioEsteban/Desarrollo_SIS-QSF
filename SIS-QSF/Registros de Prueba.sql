insert into administrador(Nombre_usuario,Clave_usuario)
values
('Calidadrifa',sha1('cali2020'));

insert into usuarios(ClaveUsuario,NoControl,Nombre,EsAlumno,Telefono,Correo)
values
(null,'S16120302','José Luis González Ruiz','Si','4453232434','Chelis@gmail.com'),
(null,'S16120301','Christian Benigno Morales Morales','Si','4455483592','beni@gmail.com'),
(null,'S16120307','Ignacio Esteban Nacho','Si','4456789080','Nacho@gmail.com'),
(null,'S16120310','Alexis Guillermo Hernandez','Si','-','-'),
(null,'-','Diego Escutia Olvera','No','-','Escutia@gmail.com');

insert into qsf(ClaveQSF,Fecha,Prioridad,Estatus,Tipo_Servicio,Departamento,Descripcion,Observaciones,UsuarioSolicitante)
values
(null,20190628,'Baja','Rechazada','Queja','Calidad','No hay clases por el COVID-19', 'No es valida tu queja',1),
(null,20201107,'Alta','En proceso','Queja','Vinculacion','Hay un ventilador al que le faltan varios tornillos en el salon B6', 'Se dirigio tu queja al departamento correspondiente, espera respuesta',1),
(null,20190528,'Baja','Rechazada','Sugerencia','Calidad','Hay que hacer una carnita asada por el dia del estudiante', 'No es valida tu sugerencia',2),
(null,20190328,'Baja','Finalizada','Queja','Academico','No funciona el proyector del aula AT5 ', 'Tu queja fue atendida, esperamos haber resuelto el problema',3),
(null,20190528,'Baja','En proceso','Felicitacion','Academico','Queria felicitar al conserje por mantener la escuela limpia', 'El destinatario agradece tu felicitacion',4),
(null,20190528,'Media','En proceso','Queja','Administracion','En el aula de cisco no existen los suficientes routers para realizar nuestras practicas', 'Se dirigio tu queja al departamento correspondiente, espera respuesta',5);