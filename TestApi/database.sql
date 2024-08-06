
CREATE DATABASE TestDB;

CREATE TABLE TestDB.dbo.tarea (
                                  id int IDENTITY(1,1) NOT NULL,
                                  titulo varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
                                  detalle varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
                                  fecha_hora datetime2(0) DEFAULT getdate() NOT NULL,
                                  estado bit DEFAULT 1 NOT NULL,
                                  CONSTRAINT PK__tarea__3213E83F4BB45456 PRIMARY KEY (id)
);


CREATE PROCEDURE dbo.SP_TAREA_SELECT
    AS
SELECT
    id [Id],
    titulo [Titulo],
    detalle [Detalle],
    fecha_hora [FechaHora],
    estado [Estado]
from tarea;

CREATE PROCEDURE dbo.SP_TAREA_INSERT
    @titulo VARCHAR(100),
	@detalle VARCHAR(500),
	@fecha_hora DATETIME2(0)
AS 
INSERT INTO tarea(titulo, detalle, fecha_hora, estado)
VALUES (@titulo, @detalle, @fecha_hora, 1);

CREATE PROCEDURE dbo.SP_TAREA_UPDATE
    @id INT,
	@titulo VARCHAR(100),
	@detalle VARCHAR(500),
	@fecha_hora DATETIME2(0),
	@estado BIT
AS
UPDATE tarea SET
                 titulo = @titulo,
                 detalle = @detalle,
                 fecha_hora = @fecha_hora,
                 estado = @estado
WHERE id = @id
;

CREATE PROCEDURE dbo.SP_TAREA_SELECT_BY_ID
    @id INT
AS
SELECT
    id [Id],
    titulo [Titulo],
    detalle [Detalle],
    fecha_hora [FechaHora],
    estado [Estado]
FROM tarea WHERE id = @id;