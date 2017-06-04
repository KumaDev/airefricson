use AirWeb

--Menu_Items
DELETE FROM Menu_Items

INSERT INTO Menu_Items VALUES (1, 'Departamentos', 1, 1, '', 'Departamentos.aspx')
INSERT INTO Menu_Items VALUES (2, 'Usuarios', 1, 2, '', 'Abm_Usuarios.aspx')
INSERT INTO Menu_Items VALUES (99, 'Salir', 99, 99, '', 'login.aspx')

SELECT * FROM Menu_Items
--Menu_Items

--Menu_Tipos
DELETE FROM Menu_Tipos

INSERT INTO Menu_Tipos VALUES(1, 1, 1)
INSERT INTO Menu_Tipos VALUES(1, 2, 0)
INSERT INTO Menu_Tipos VALUES(1, 99, 0)

SELECT * FROM Menu_Tipos
--Menu_Tipos

--Departamentos
DELETE FROM Departamentos

INSERT INTO Departamentos VALUES (1, 'N/A', 'Sin Departamento', 1, 1, 0)
INSERT INTO Departamentos VALUES (2, 'BT', 'Business Technology', 1, 0, 0)
INSERT INTO Departamentos VALUES (3, 'EHS', 'EHS', 1, 0, 0)
INSERT INTO Departamentos VALUES (4, 'ING', 'Ingenieria', 1, 0, 0)
INSERT INTO Departamentos VALUES (5, 'FIN', 'Costos', 1, 0, 0)

SELECT * FROM Departamentos
--Departamentos

--Usuarios
DELETE FROM Usuarios

INSERT INTO Usuarios VALUES(1, 'malaise', '', 'Mariano', 'Laiseca', 'mariano.a.laiseca@pfizer.com','',1,0,1,1,2,0)

SELECT * FROM Usuarios
--Usuarios

--Causas
DELETE FROM Causas

INSERT INTO Causas VALUES (1, 'N/A', 'Sin Causa', 1, 1, 0)
INSERT INTO Causas VALUES (2, 'FDP', 'Falta de Procedimiento', 1, 0, 0)
INSERT INTO Causas VALUES (2, 'FDE', 'Falta de Entrenamiento', 1, 0, 0)
	
SELECT * FROM Causas
--Causas

--Areas
DELETE FROM Areas

INSERT INTO Areas VALUES (1, 'N/A', 'Sin Area', 1, 1, 0)
INSERT INTO Areas VALUES (2, 'BT', 'BT General/Mgr/CC', 1, 0, 0)
INSERT INTO Areas VALUES (3, 'FIN', 'Costos', 1, 0, 0)
INSERT INTO Areas VALUES (4, 'PUR', 'Compras', 1, 0, 0)
INSERT INTO Areas VALUES (5, 'ING', 'Ingenieria', 1, 0, 0)

SELECT * FROM Areas
--Areas

--Clases
DELETE FROM Clases

INSERT INTO Clases VALUES (0, 'N/A', 'Sin Clase', 1, 1, 0)
INSERT INTO Clases VALUES (1, 'ACT', 'Accidente Contratista', 1, 0, 1)
INSERT INTO Clases VALUES (2, 'ACR', 'Accidente Reportable', 1, 0, 2)
INSERT INTO Clases VALUES (3, 'CAP', 'Casi Accidente Personal', 1, 0, 3)
INSERT INTO Clases VALUES (4, 'DRC', 'Derrame Reportable Corporate', 1, 0, 4)
INSERT INTO Clases VALUES (5, 'DNR', 'Derrame No Reportable', 1, 0, 5)

SELECT * FROM Clases
--Clases

--Estados
DELETE FROM Estados

INSERT INTO Estados VALUES (1, 'EJE', 'En Ejecucion', 1, 0, 1, 3)
INSERT INTO Estados VALUES (2, 'COM', 'Tarea Terminada', 0, 0, 1, 0)
INSERT INTO Estados VALUES (3, 'VER', 'Verificada EHS', 0, 1, 1, 0)
INSERT INTO Estados VALUES (3, 'PRO', 'Programada', 0, 0, 1, 10)
INSERT INTO Estados VALUES (3, 'CPA', 'Proyecto CPA', 0, 0, 1, 0)

SELECT * FROM Estados
--Estados

--Grupos Seguimiento
DELETE FROM GruposSeguimiento
DELETE FROM GruposSeguimientoUsuarios

INSERT INTO GruposSeguimiento VALUES (1, 'MAN', 'Mantenimiento', 1, 1, 0)
INSERT INTO GruposSeguimientoUsuarios VALUES (1, 1, 1, 1)
INSERT INTO GruposSeguimiento VALUES (2, 'EHS', 'EHS', 1, 1, 0)
INSERT INTO GruposSeguimientoUsuarios VALUES (2, 2, 1, 1)

SELECT * FROM GruposSeguimiento
SELECT * FROM GruposSeguimientoUsuarios
--Grupos Seguimiento

--Motivos
DELETE FROM Motivos

INSERT INTO Motivos VALUES (0, 'N/A', 'Sin Motivo', 1, 1, 0)
INSERT INTO Motivos VALUES (1, 'FPR', 'Falla Procedimiento', 1, 0, 1)
INSERT INTO Motivos VALUES (2, 'SEN', 'Falta Entrenamiento', 1, 0, 2)
INSERT INTO Motivos VALUES (3, 'SPR', 'Falta Procedimiento', 1, 0, 3)
INSERT INTO Motivos VALUES (4, 'SEQ', 'Falta Equipamiento', 1, 0, 4)
INSERT INTO Motivos VALUES (5, 'OTR', 'Otros', 1, 0, 5)

SELECT * FROM Motivos
--Motivos

--Origen Tipos
DELETE FROM OrigenTipos

INSERT INTO OrigenTipos VALUES (1, 'GES', 'Gestion', 1, 1, 0)
INSERT INTO OrigenTipos VALUES (2, 'INC', 'Incidente', 1, 0, 0)

SELECT * FROM OrigenTipos
--Origen Tipos

--Origenes
DELETE FROM Origenes

INSERT INTO Origenes VALUES (1, 'N/A', 'Sin Origen', 1, 1, 1, 0)
INSERT INTO Origenes VALUES (2, 'ACC', 'Accidente', 2, 1, 0, 1)
INSERT INTO Origenes VALUES (3, 'PAU', 'Primeros Auxilios', 2, 1, 0, 5)
INSERT INTO Origenes VALUES (4, 'AUC', 'Auditoria Corporativa', 1, 1, 0, 6)


SELECT * FROM Origenes
--Origenes

--PartesCuerpo
DELETE FROM PartesCuerpo

INSERT INTO PartesCuerpo VALUES (0, 'N/A', 'Sin Parte del Cuerpo', 1, 1, 0)
INSERT INTO PartesCuerpo VALUES (1, 'ABD', 'Abdomen', 1, 0, 1)
INSERT INTO PartesCuerpo VALUES (2, 'DIG', 'Aparato Digestivo', 1, 0, 4)
INSERT INTO PartesCuerpo VALUES (3, 'NER', 'Aparato Nervioso', 1, 0, 5)
INSERT INTO PartesCuerpo VALUES (4, 'BOC', 'Boca', 1, 0, 7)
INSERT INTO PartesCuerpo VALUES (5, 'ESP', 'Espalda', 1, 0, 18)

SELECT * FROM PartesCuerpo
--PartesCuerpo

--Prioridades
DELETE FROM Prioridades

INSERT INTO Prioridades VALUES (1, 'A', 'Alta', 1, 1, 0, 1)
INSERT INTO Prioridades VALUES (2, 'M', 'Media', 7, 1, 0, 2)
INSERT INTO Prioridades VALUES (3, 'B', 'Baja', 30, 1, 0, 3)

SELECT * FROM Prioridades
--Prioridades

--Propositos
DELETE FROM Propositos

INSERT INTO Propositos VALUES (0, 'N/A', 'Sin Proposito', 1, 1, 0)
INSERT INTO Propositos VALUES (1, 'C', 'Accion Correctiva', 1, 0, 1)
INSERT INTO Propositos VALUES (2, 'E', 'Evitar Recurrencia', 1, 0, 2)
INSERT INTO Propositos VALUES (3, 'M', 'Medida Contingencia', 1, 0, 3)
INSERT INTO Propositos VALUES (4, 'O', 'Otros', 1, 0, 4)
INSERT INTO Propositos VALUES (5, 'P', 'Mejorar Actividad/Procedimiento', 1, 0, 5)

SELECT * FROM Propositos
--Propositos

--TiposLesion
DELETE FROM TiposLesion

INSERT INTO TiposLesion VALUES (0, 'N/A', 'Sin Lesion', 1, 1, 0)
INSERT INTO TiposLesion VALUES (1, 'AMP', 'Amputacion', 1, 0, 1)
INSERT INTO TiposLesion VALUES (2, 'APL', 'Aplastamiento', 1, 0, 2)
INSERT INTO TiposLesion VALUES (3, 'ASF', 'Asfixia', 1, 0, 3)
INSERT INTO TiposLesion VALUES (4, 'CON', 'Conmocion', 1, 0, 4)
INSERT INTO TiposLesion VALUES (5, 'COT', 'Contusion', 1, 0, 5)

SELECT * FROM TiposLesion
--TiposLesion