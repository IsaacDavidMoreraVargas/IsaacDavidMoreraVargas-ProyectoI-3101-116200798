/*
DROP database ProyectoI
GO
*/


Create database ProyectoI
GO
Use ProyectoI
GO
Create table credenciales(
	idProfesional int NOT NULL,
	codigo_profesional int NOT NULL,
	clinicaProfesional varchar(300),
	PRIMARY KEY (idProfesional)
);

Create table datosProfesional(
	Identificacion_Profesional int NOT NULL,
	Codigo_Profesional int NOT NULL,
	Nombre_Completo_Profesional varchar(300) NOT NULL,
	Correo_Electronico_Profesional varchar(300) NOT NULL,
	Pais_Residencia_Profesional varchar(300) NOT NULL,
	Estado_Provincia_Residencia_Profesional varchar(300) NOT NULL,
	Numero_Registro_Unico int NOT NULL,
	PRIMARY KEY (Identificacion_Profesional)
);

Create table datosClinica(
	Cedula_Juridica_Clinica int NOT NULL,
	Nombre_Clinica varchar(300) NOT NULL,
	Telefono_Administracion_Clinica int NOT NULL,
	Correo_Electronico_Administracion varchar(300) NOT NULL,
	Pais_Clinica varchar(300) NOT NULL,
	Estado_Provincia_Clinica varchar(300) NOT NULL,
	Distrito_Clinica varchar(300),
	Sitio_Web varchar(300),
	PRIMARY KEY (Cedula_Juridica_Clinica)
);

Create table datosPaciente(
	Identificacion_Paciente int NOT NULL,
    Nombre_Paciente varchar(300) NOT NULL,
    Primer_Apellido_Paciente varchar(300) NOT NULL,
    Segundo_Apellido_Paciente varchar(300) NOT NULL,
    Fecha_Nacimiento_Paciente varchar(300) NOT NULL,
    Telefono_Contacto_Paciente int NOT NULL,
    Correo_Electronico_Paciente varchar(300) NOT NULL,
    Fecha_Registro varchar(300) NOT NULL,
    Ocupacion_Paciente varchar(300) NOT NULL,
    Pais_Paciente varchar(300) NOT NULL,
    Estado_Provincia_Paciente varchar(300) NOT NULL,
    Distrito_Paciente varchar(300) NOT NULL,
    Genero_Paciente varchar(1) NOT NULL,
    Estado_Civil_Paciente varchar(300) NOT NULL,
	PRIMARY KEY (Identificacion_Paciente)
);

Create table datosInyecciones(
	Identificacion_Paciente int NOT NULL,
    Sarampión_Rubeola_Parotiditis varchar(40) NOT NULL,
    Tetano_Hepatitis_A_B_Influenza varchar(40) NOT NULL,
    Vacuna_Covid varchar(300) NOT NULL,
    Cuantas_Dosis int,
    Razon_Covid varchar(300),
	PRIMARY KEY (Identificacion_Paciente)
);

Create table datosSintomas(
	Identificacion_Paciente int NOT NULL,
	C0 bit,
	C1 bit,
	C2 bit,
	C3 bit,
	C4 bit,
	C5 bit,
	C6 bit,
	C7 bit,
	C8 bit,
	C9 bit,
	T0 varchar(300),
	C10 bit,
	C11 bit,
	C12 bit,
	C13 bit,
	C14 bit,
	C15 bit,
	C16 bit,
	C17 bit,
	C18 bit,
	C19 bit,
	C20 bit,
	C21 bit,
	C22 bit,
	C23 bit,
	C24 bit,
	C25 bit,
	C26 bit,
	C27 bit,
	C28 bit,
	C29 bit,
	C30 bit,
	C31 bit,
	C32 bit,
	C33 bit,
	C34 bit,
	C35 bit,
	C36 bit,
	C37 bit,
	C38 bit,
	C39 bit,
	C40 bit,
	C41 bit,
	C42 bit,
	C43 bit,
	C44 bit,
	C45 bit,
	C46 bit,
	C47 bit,
	C48 bit,
	C49 bit,
	C50 bit,
	C51 bit,
	C52 bit,
	C53 bit,
	C54 bit,
	C55 bit,
	C56 bit,
	C57 bit,
	C58 bit,
	C59 bit,
	C60 bit,
	T1 varchar(300),
	T2 varchar(300),
	C61 bit,
	C62 bit,
	C63 bit,
	C64 bit,
	C65 bit,
	C66 bit,
	C67 bit,
	C68 bit,
	C69 bit,
	C70 bit,
	C71 bit,
	C72 bit,
	C73 bit,
	C74 bit,
	C75 bit,
	C76 bit,
	C77 bit,
	C78 bit,
	C79 bit,
	C80 bit,
	C81 bit,
	C82 bit,
	C83 varchar(300),
	PRIMARY KEY (Identificacion_Paciente)
);

GO
INSERT INTO dbo.credenciales(idProfesional,codigo_profesional,clinicaProfesional) VALUES (1,1,NULL);
