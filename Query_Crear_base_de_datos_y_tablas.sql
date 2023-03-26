/*
DROP database ProyectoI
GO
*/
/*
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
	PRIMARY KEY (Identificacion_Profesional)
);
GO
INSERT INTO dbo.credenciales(idProfesional,codigo_profesional,clinicaProfesional) VALUES (1,1,NULL);
*/