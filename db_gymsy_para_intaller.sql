USE [master]
GO
CREATE DATABASE gymsy
GO
USE gymsy
GO

-- Creación de la tabla Rol
CREATE TABLE Rol (
    id_rol INT IDENTITY(1,1),
    nombre VARCHAR(20) NOT NULL,
    rol_inactivo BIT DEFAULT 0 NOT NULL,

    CONSTRAINT ROL_PK_ID_ROL PRIMARY KEY (id_rol) 
);
GO
-- Creación de la tabla Usuario con las restricciones adicionales
CREATE TABLE Usuario (
    id_usuario INT  IDENTITY(1,1),
    id_rol INT,
    apodo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(20) NOT NULL,
    apellido VARCHAR(20) NOT NULL,
    avatar_url VARCHAR(100) NOT NULL,
    contrasena VARCHAR(100) NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE() NOT NULL,
    fecha_nacimiento DATETIME NOT NULL,
    numero_telefono VARCHAR(100) NOT NULL,
    sexo CHAR(1)  NOT NULL,
    usuario_inactivo BIT DEFAULT 0 NOT NULL,

    CONSTRAINT USUARIO_PK_ID_USUARIO PRIMARY KEY (id_usuario) ,
    CONSTRAINT USUARIO_FK_USUARIO_ROL FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    CONSTRAINT USUARIO_CHECK_SEXO CHECK (sexo IN ('M', 'F'))
);
GO
-- Creación de la tabla TipoDePago
CREATE TABLE TipoDePago (
    id_tipo_pago INT IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    tipo_pago_inactivo BIT  DEFAULT 0 NOT NULL,

    CONSTRAINT TIPODEPAGO_PK_ID_TIPO_PAGO PRIMARY KEY (id_tipo_pago)
);
GO
-- Creación de la tabla Pago
CREATE TABLE Pago (
    id_pago INT IDENTITY(1,1),
    id_usuario INT NOT NULL, -- Debería haber una tabla Usuario con id_usuario
    id_tipo_pago INT NOT NULL, -- Referencia a la tabla TipoDePago
    cbu_destino VARCHAR(22) NOT NULL,
    cbu_origen VARCHAR(22) NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE() NOT NULL,
    monto DECIMAL(10, 2) NOT NULL,
    inactivo_pago BIT DEFAULT 0 NOT NULL,

    CONSTRAINT PAGO_PK_ID_PAGO PRIMARY KEY (id_pago),
    CONSTRAINT PAGO_FK_PAGO_USUARIO FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT PAGO_FK_PAGO_TIPOPAGO FOREIGN KEY (id_tipo_pago) REFERENCES TipoDePago(id_tipo_pago)
);
GO

-- Creación de la tabla PlanEntrenamiento
CREATE TABLE PlanEntrenamiento (
    id_plan_entrenamiento INT  IDENTITY(1,1),
    id_entrenador INT NOT NULL, -- El usuario tipo instructor encargado del plan de entrenamiento
    precio DECIMAL(10, 2) NOT NULL,
    descripcion VARCHAR(MAX) NOT NULL,
    plan_entrenamiento_inactivo BIT DEFAULT 0 NOT NULL,

    CONSTRAINT PLANENTRENAMIENTO_PK_ID_PLAN_ENTRENAMIENTO PRIMARY KEY (id_plan_entrenamiento),
    CONSTRAINT FK_PLANENTRENAMIENTO_INSTRUCTOR FOREIGN KEY (id_entrenador) REFERENCES Usuario(id_usuario)
);
GO
-- Creación de la tabla AlumnoSuscripcion
CREATE TABLE AlumnoSuscripcion (
    id_alumno_suscripcion INT IDENTITY(1,1),
    id_alumno INT NOT NULL, 
    id_plan_entrenamiento INT NOT NULL, 
    fecha_expiracion DATE NOT NULL,

    CONSTRAINT ALUMNOSUSCRIPCION_PK_ID_ALUMNO_SUSCRIPCION PRIMARY KEY (id_alumno_suscripcion),
    CONSTRAINT ALUMNOSUSCRIPCION_FK_AlumnoSuscripcion_Usuario FOREIGN KEY (id_alumno) REFERENCES Usuario(id_usuario),
    CONSTRAINT ALUMNOSUSCRIPCION_FK_AlumnoSuscripcion_PlanEntrenamiento FOREIGN KEY (id_plan_entrenamiento) REFERENCES PlanEntrenamiento(id_plan_entrenamiento)
);
GO
-- Creación de la tabla EstadoFisico
CREATE TABLE EstadoFisico (
    id_estado_fisico INT IDENTITY(1,1),
    titulo VARCHAR(100) NOT NULL,
    peso DECIMAL(5, 2) NOT NULL,
    altura DECIMAL(5, 2) NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE() NOT NULL,
    notas VARCHAR(MAX) NOt NULL,
    estado_fisico_inactivo BIT DEFAULT 0 NOT NULL,
    id_alumno_suscripcion INT NOT NULL,
    imagen_url VARCHAR(100) NOT  NULL,

    CONSTRAINT ESTADOFISICO_PK_ID_ESTADO_FISICO PRIMARY KEY (id_estado_fisico),
    CONSTRAINT ESTADOFISICO_FK_EstadoFisico_AlumnoSuscripcion FOREIGN KEY (id_alumno_suscripcion) REFERENCES AlumnoSuscripcion(id_alumno_suscripcion)
);
GO
CREATE TABLE Rol_Audit (
    audit_id INT IDENTITY(1,1),
    id_rol INT,
    nombre VARCHAR(20),
    rol_inactivo BIT,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT ROL_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);

GO
CREATE TABLE Usuario_Audit (
    audit_id INT IDENTITY(1,1),
    id_usuario INT,
    id_rol INT,
    apodo VARCHAR(20),
    nombre VARCHAR(20),
    apellido VARCHAR(20),
    avatar_url VARCHAR(100),
    contrasena VARCHAR(100),
    fecha_creacion DATETIME,
    fecha_nacimiento DATETIME,
    numero_telefono VARCHAR(100),
    sexo CHAR(1),
    usuario_inactivo BIT,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT USUARIO_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);
GO
CREATE TABLE TipoDePago_Audit (
    audit_id INT IDENTITY(1,1),
    id_tipo_pago INT,
    nombre VARCHAR(50),
    tipo_pago_inactivo BIT,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT TIPODEPAGO_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);

CREATE TABLE Pago_Audit (
    audit_id INT IDENTITY(1,1),
    id_pago INT,
    id_usuario INT,
    id_tipo_pago INT,
    cbu_destino VARCHAR(22),
    cbu_origen VARCHAR(22),
    fecha_creacion DATETIME,
    monto DECIMAL(10, 2),
    inactivo_pago BIT,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT PAGO_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);
GO
CREATE TABLE PlanEntrenamiento_Audit (
    audit_id INT IDENTITY(1,1),
    id_plan_entrenamiento INT,
    id_entrenador INT,
    precio DECIMAL(10, 2),
    descripcion VARCHAR(MAX),
    plan_entrenamiento_inactivo BIT,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT PLANENTRENAMIENTO_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);
GO
CREATE TABLE AlumnoSuscripcion_Audit (
    audit_id INT IDENTITY(1,1),
    id_alumno_suscripcion INT,
    id_alumno INT,
    id_plan_entrenamiento INT,
    fecha_expiracion DATE,
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT ALUMNOSUSCRIPCION_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);

GO
CREATE TABLE EstadoFisico_Audit (
    audit_id INT IDENTITY(1,1),
    id_estado_fisico INT,
    titulo VARCHAR(100),
    peso DECIMAL(5, 2),
    altura DECIMAL(5, 2),
    fecha_creacion DATETIME,
    notas VARCHAR(MAX),
    estado_fisico_inactivo BIT,
    id_alumno_suscripcion INT,
    imagen_url VARCHAR(100),
    operation_type CHAR(1), -- I=Insert, U=Update, D=Delete
    operation_date DATETIME DEFAULT GETDATE(),
    CONSTRAINT ESTADOFISICO_AUDIT_PK_AUDIT_ID PRIMARY KEY (audit_id)
);
GO
/*
CREATE TRIGGER TR_Usuario_Audit
ON Usuario
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO Usuario_Audit (id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, operation_type)
        SELECT id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion, fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Usuario_Audit (id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, operation_type)
        SELECT id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Usuario_Audit (id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, operation_type)
        SELECT id_usuario, id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo, usuario_inactivo, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_Rol_Audit
ON Rol
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO Rol_Audit (id_rol, nombre, rol_inactivo, operation_type)
        SELECT id_rol, nombre, rol_inactivo, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Rol_Audit (id_rol, nombre, rol_inactivo, operation_type)
        SELECT id_rol, nombre, rol_inactivo, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Rol_Audit (id_rol, nombre, rol_inactivo, operation_type)
        SELECT id_rol, nombre, rol_inactivo, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_PlanEntrenamiento_Audit
ON PlanEntrenamiento
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO PlanEntrenamiento_Audit (id_plan_entrenamiento, id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, operation_type)
        SELECT id_plan_entrenamiento,id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO PlanEntrenamiento_Audit (id_plan_entrenamiento, id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, operation_type)
        SELECT id_plan_entrenamiento, id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO PlanEntrenamiento_Audit (id_plan_entrenamiento, id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, operation_type)
        SELECT id_plan_entrenamiento, id_entrenador, precio, descripcion, plan_entrenamiento_inactivo, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_Pago_Audit
ON Pago
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO Pago_Audit (id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, operation_type)
        SELECT id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Pago_Audit (id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, operation_type)
        SELECT id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO Pago_Audit (id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, operation_type)
        SELECT id_pago, id_usuario, id_tipo_pago, cbu_destino, cbu_origen, fecha_creacion, monto, inactivo_pago, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_EstadoFisico_Audit
ON EstadoFisico
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO EstadoFisico_Audit (id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, operation_type)
        SELECT id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO EstadoFisico_Audit (id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, operation_type)
        SELECT id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO EstadoFisico_Audit (id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, operation_type)
        SELECT id_estado_fisico, titulo, peso, altura, fecha_creacion, notas, estado_fisico_inactivo, id_alumno_suscripcion, imagen_url, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_AlumnoSuscripcion_Audit
ON AlumnoSuscripcion
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO AlumnoSuscripcion_Audit (id_alumno_suscripcion,id_alumno, id_plan_entrenamiento, fecha_expiracion, operation_type)
        SELECT id_alumno_suscripcion, id_alumno, id_plan_entrenamiento, fecha_expiracion, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AlumnoSuscripcion_Audit (id_alumno_suscripcion, id_alumno, id_plan_entrenamiento, fecha_expiracion, operation_type)
        SELECT id_alumno_suscripcion, id_alumno, id_plan_entrenamiento, fecha_expiracion, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO AlumnoSuscripcion_Audit (id_alumno_suscripcion,id_alumno, id_plan_entrenamiento, fecha_expiracion, operation_type)
        SELECT id_alumno_suscripcion, id_alumno, id_plan_entrenamiento, fecha_expiracion, 'U'
        FROM inserted;
    END
END;
GO
CREATE TRIGGER TR_TipoDePago_Audit
ON TipoDePago
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO TipoDePago_Audit (id_tipo_pago, nombre, tipo_pago_inactivo, operation_type)
        SELECT id_tipo_pago, nombre, tipo_pago_inactivo, 'I'
        FROM inserted;
    END

    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO TipoDePago_Audit (id_tipo_pago, nombre, tipo_pago_inactivo, operation_type)
        SELECT id_tipo_pago, nombre, tipo_pago_inactivo, 'D'
        FROM deleted;
    END

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO TipoDePago_Audit (id_tipo_pago, nombre, tipo_pago_inactivo, operation_type)
        SELECT id_tipo_pago, nombre, tipo_pago_inactivo, 'U'
        FROM inserted;
    END
END;
*/
GO

CREATE PROCEDURE ObtenerAlumnosActivosPorEntrenador
    @id_entrenador INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        U.id_usuario AS id_alumno,
        U.apodo,
        U.nombre,
        U.apellido,
        U.avatar_url,
        U.fecha_nacimiento,
        U.numero_telefono,
        U.sexo,
        U.usuario_inactivo
    FROM 
        AlumnoSuscripcion AS ASuscripcion
    JOIN 
        PlanEntrenamiento AS PEntrenamiento ON ASuscripcion.id_plan_entrenamiento = PEntrenamiento.id_plan_entrenamiento
    JOIN 
        Usuario AS U ON ASuscripcion.id_alumno = U.id_usuario
    WHERE 
        PEntrenamiento.id_entrenador = @id_entrenador
        AND ASuscripcion.fecha_expiracion >= GETDATE()
    ORDER BY 
        U.apellido, U.nombre;
END;
GO
CREATE PROCEDURE ObtenerClientesNoExpirados
    @id_entrenador INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        COUNT(*) AS CantidadClientesNoExpirados
    FROM 
        AlumnoSuscripcion AS ASuscripcion
    JOIN 
        PlanEntrenamiento AS PEntrenamiento ON ASuscripcion.id_plan_entrenamiento = PEntrenamiento.id_plan_entrenamiento
    WHERE 
        PEntrenamiento.id_entrenador = @id_entrenador
        AND ASuscripcion.fecha_expiracion >= GETDATE();
END;

GO
CREATE PROCEDURE LoginUsuario
    @apodo VARCHAR(20),
    @contrasena VARCHAR(100)
AS
BEGIN
    -- Declaración de variables
    DECLARE @id_usuario INT;
    DECLARE @usuario_inactivo BIT;

    -- Verificar las credenciales del usuario
    SELECT @id_usuario = id_usuario,
           @usuario_inactivo = usuario_inactivo
    FROM Usuario
    WHERE apodo = @apodo AND contrasena = @contrasena;

    -- Si las credenciales son correctas y el usuario no está inactivo
    IF @id_usuario IS NOT NULL AND @usuario_inactivo = 0
    BEGIN
        -- Devolver los datos del usuario excepto la contraseña
        SELECT id_usuario,
               id_rol,
               apodo,
               nombre,
               apellido,
               avatar_url,
               fecha_creacion,
               fecha_nacimiento,
               numero_telefono,
               sexo,
               usuario_inactivo
        FROM Usuario
        WHERE id_usuario = @id_usuario;
    END
    ELSE
    BEGIN
        -- Devolver un mensaje de error
        SELECT 'Credenciales inválidas o usuario inactivo' AS mensaje_error;
    END
END;
GO
CREATE PROCEDURE CrearPlanEntrenamiento
    @id_entrenador INT,
    @precio DECIMAL(10, 2),
    @descripcion TEXT
AS
BEGIN
    INSERT INTO PlanEntrenamiento (id_entrenador, precio, descripcion)
    VALUES (@id_entrenador, @precio, @descripcion);
END;
GO
CREATE PROCEDURE CrearPago
    @id_usuario INT,
    @id_tipo_pago INT,
    @cbu_destino VARCHAR(22),
    @cbu_origen VARCHAR(22),
    @monto DECIMAL(10, 2),
    @inactivo_pago BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar el nuevo pago en la tabla Pago
    INSERT INTO Pago (
        id_usuario, 
        id_tipo_pago, 
        cbu_destino, 
        cbu_origen, 
        fecha_creacion, 
        monto, 
        inactivo_pago
    )
    VALUES (
        @id_usuario, 
        @id_tipo_pago, 
        @cbu_destino, 
        @cbu_origen, 
        GETDATE(), 
        @monto, 
        @inactivo_pago
    );

    -- Devolver el ID del pago recién creado
    SELECT SCOPE_IDENTITY() AS id_pago;
END;
GO
CREATE PROCEDURE CrearInstructor
    @apodo VARCHAR(20),
    @nombre VARCHAR(20),
    @apellido VARCHAR(20),
    @avatar_url VARCHAR(100),
    @contrasena VARCHAR(100),
    @numero_telefono VARCHAR(100),
    @fecha_nacimiento DATETIME,
    @sexo CHAR(1)
AS
BEGIN
    INSERT INTO Usuario (id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo)
    VALUES (2, @apodo, @nombre, @apellido, @avatar_url, @contrasena, GETDATE(),@fecha_nacimiento, @numero_telefono, @sexo);
END;
GO
--Crear un nuevo estado fisico o avance de progreso
CREATE PROCEDURE CrearEstadoFisico
    @titulo VARCHAR(100),
    @peso DECIMAL(5, 2),
    @altura DECIMAL(5, 2),
    @notas TEXT,
    @id_alumno_suscripcion INT,
    @imagen_url VARCHAR(100)
AS
BEGIN
    INSERT INTO EstadoFisico (titulo, peso, altura, fecha_creacion, notas, id_alumno_suscripcion, imagen_url)
    VALUES (@titulo, @peso, @altura, GETDATE(), @notas, @id_alumno_suscripcion, @imagen_url);
END;
GO
CREATE PROCEDURE CrearCliente
    @apodo VARCHAR(20),
    @nombre VARCHAR(20),
    @apellido VARCHAR(20),
    @avatar_url VARCHAR(100),
    @contrasena VARCHAR(100),
    @numero_telefono VARCHAR(100),
    @fecha_nacimiento DATETIME,
    @sexo CHAR(1)
AS
BEGIN
    -- Crear el usuario con id_rol = 3
    INSERT INTO Usuario (id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_creacion,fecha_nacimiento, numero_telefono, sexo)
    VALUES (3, @apodo, @nombre, @apellido, @avatar_url, @contrasena, GETDATE(),@fecha_nacimiento, @numero_telefono, @sexo);
END;
GO

--Desactiva o activa al usuario depende 
CREATE PROCEDURE CambiarEstadoUsuario
    @id_usuario INT
AS
BEGIN
    UPDATE Usuario
    SET usuario_inactivo = CASE 
                             WHEN usuario_inactivo = 1 THEN 0
                             ELSE 1
                           END
    WHERE id_usuario = @id_usuario;
END;
GO
--Consulta para obtener la cantidad de pagos por mes realizados por los usuarios con id_rol = 3 en un año determinado.
CREATE PROCEDURE ObtenerCantidadPagosPorMes
    @year INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MONTH(P.fecha_creacion) AS Mes,
        COUNT(P.id_pago) AS CantidadPagos
    FROM 
        Pago P
    JOIN 
        Usuario U ON P.id_usuario = U.id_usuario
    WHERE 
        U.id_rol = 3
        AND YEAR(P.fecha_creacion) = @year
    GROUP BY 
        MONTH(P.fecha_creacion)
    ORDER BY 
        Mes;
END;
GO
CREATE PROCEDURE ObtenerClientesExpirados
    @id_entrenador INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        COUNT(*) AS CantidadClientesExpirados
    FROM 
        AlumnoSuscripcion AS ASuscripcion
    JOIN 
        PlanEntrenamiento AS PEntrenamiento ON ASuscripcion.id_plan_entrenamiento = PEntrenamiento.id_plan_entrenamiento
    WHERE 
        PEntrenamiento.id_entrenador = @id_entrenador
        AND ASuscripcion.fecha_expiracion < GETDATE();
END;

GO


--Insertar los roles en el siguiente orden 

-- Insertar el rol de Administrador
INSERT INTO Rol (nombre)
VALUES ('Administrador');
GO
-- Insertar el rol de Instructor
INSERT INTO Rol (nombre)
VALUES ('Instructor');
GO
-- Insertar el rol de Cliente
INSERT INTO Rol (nombre)
VALUES ('Cliente');
GO
INSERT INTO Rol (nombre)
VALUES ('Recepcionista');
GO

--Isertar Usuarios
--Admin
Insert into Usuario(id_rol,apodo,nombre,apellido,avatar_url,contrasena, fecha_nacimiento, numero_telefono,sexo,usuario_inactivo)
values(1,'admin','adminNombre','adminApellido','','$2a$11$netRERtai.UGKsvpsuVmP.oK6LpZlIH9o49yuS0hJjtvGrEh11652', DATEADD(year, -40, GETDATE()),1,'M',0)
GO
-- Insertar un recepcionista
INSERT INTO Usuario(id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_nacimiento,numero_telefono, sexo, usuario_inactivo)
VALUES (4, 'res', 'Juan', 'Perez', '', '$2a$11$netRERtai.UGKsvpsuVmP.oK6LpZlIH9o49yuS0hJjtvGrEh11652', DATEADD(year, -27, GETDATE()), 1234567890, 'M', 0);
GO
-- Insertar tres instructores
INSERT INTO Usuario(id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_nacimiento, numero_telefono, sexo, usuario_inactivo)
VALUES 
(2, 'instruc', 'Ana', 'Gomez', '', '$2a$11$GqikCjTprRXoyo.KYS3d6OWIa9Fa0NCdN6o4HiT3a/lJ3.AURZaim', DATEADD(year, -40, GETDATE()), 2345678901, 'F', 0),
(2, 'instructor2', 'Luis', 'Martinez', '', '$2a$11$GqikCjTprRXoyo.KYS3d6OWIa9Fa0NCdN6o4HiT3a/lJ3.AURZaim', DATEADD(year, -23, GETDATE()),3456789012, 'M', 0),
(2, 'instructor3', 'Maria', 'Lopez', '', '$2a$11$GqikCjTprRXoyo.KYS3d6OWIa9Fa0NCdN6o4HiT3a/lJ3.AURZaim', DATEADD(year, -30, GETDATE()),4567890123, 'F', 0);
GO

-- Insertar clientes
INSERT INTO Usuario (id_rol, apodo, nombre, apellido, avatar_url, contrasena, fecha_nacimiento, numero_telefono, sexo, usuario_inactivo) VALUES 
(4, 'cliente', 'Carlos', 'Fernandez', '', '$2a$11$82xLfp64da9CjjbHT2Kcx.Da7Qk67Hvmj0yiZ3fAbVFn1ZASl7Z9y', DATEADD(year, -20, GETDATE()), 5678901234, 'M', 0),
(4, 'cliente2', 'Elena', 'Rodriguez', '', '$2a$11$82xLfp64da9CjjbHT2Kcx.Da7Qk67Hvmj0yiZ3fAbVFn1ZASl7Z9y', DATEADD(year, -40, GETDATE()), 6789012345, 'F', 0),
(4, 'cliente3', 'Miguel', 'Sanchez', '', '$2a$11$82xLfp64da9CjjbHT2Kcx.Da7Qk67Hvmj0yiZ3fAbVFn1ZASl7Z9y', DATEADD(year, -50, GETDATE()), 7890123456, 'M', 0),
(3, 'jose', 'Jose', 'Argento', '429558e3-f416-4bb5-8c92-95aa3ec5764820240617195142155.png', '$2a$11$6ZoSnYQnoq8hIeHTo.E97ueiWfBQv4YSZ1jt5J8GSQmm4dMDCD6k2', '2023-10-28', 3789654231, 'M', 1),
(2, 'maria', 'Marielena', 'Fuceneco', '4b620d06-054e-4603-a36a-d92650340a9e20240619040845110.png', '$2a$11$qaUymzjF7X4HJhcjBDnYMepmDc8zppO/r9zvCMXJ8a3Oidl7JOJ4S', DATEADD(year, -40, GETDATE()), 3786623455, 'F', 0),
(2, 'a', 'a', 'a', '4c7edcd0-f8fa-4155-b930-726553ed67a220240619041324693.png', '$2a$11$szdk.gYmLuKCtmlodWhBZeyKN3O5sppSB8SF9NJpFWSOlfimdDNVa', '2024-06-15', 'a', 'M', 1),
(2, 'dedc9d44-88be-4331-8', 'sgagshagsh', 'sansahsgahgs', '12', '$2a$11$z.SLCcfL/Lm23t2KIp/JAe7X.icOZVLGnZlDtjD2J3bWDRzifNa4K', GETDATE(), 'sagsghags', 'M', 1),
(2, 'a7db8487-5235-42d6-a', 'aaa', 'aaa', 'aaa', '$2a$11$BguSqYLr5hwATEfgqqmp/uRZHrYnSKhYmG7.guduJo32XCFMwLrra', GETDATE(), 'aaa', 'M', 0),
(2, '36a8353e-bbaa-4e10-a', 'aaa', 'ddd', 'dd', '$2a$11$Ke3s7bBLtGnWp.K9/iCmKefjrc0uqrbWmK.MOB8YYlIpulL36I7ge', DATEADD(year, -50, GETDATE()), 'ddd', 'M', 0);

GO

INSERT INTO TipoDePago (nombre) VALUES 
('Tarjeta de Crédito'),
('Transferencia Bancaria'),
('Efectivo');
GO
INSERT INTO Pago (id_usuario, id_tipo_pago, cbu_destino, cbu_origen, monto) VALUES 
(6, 1, '0000000000000000000000', '1111111111111111111111', 1000.00),
(7, 2, '0000000000000000000000', '2222222222222222222222', 1500.00),
(8, 3, '0000000000000000000000', '3333333333333333333333', 2000.00);
GO
INSERT INTO PlanEntrenamiento (id_entrenador, precio, descripcion) VALUES 
(3, 500.00, 'Plan de entrenamiento básico'),
(4, 750.00, 'Plan de entrenamiento intermedio'),
(5, 1000.00, 'Plan de entrenamiento avanzado'),
(9, 750.00, 'King Boxing'),
(9, 50.00, 'King Boxing low cost'),
(9, 212.00, 'King Boxing2'),
(9, 12.00, 'King Boxing7'),
(9, 123.00, 'dawdaw');

GO
INSERT INTO AlumnoSuscripcion (id_alumno, id_plan_entrenamiento, fecha_expiracion) VALUES 
(6, 1, '2025-06-17'),
(7, 2, '2025-06-17'),
(8, 3, '2025-06-17'),
(12, 1, '2025-06-17');

GO
INSERT INTO EstadoFisico (titulo, peso, altura, notas, id_alumno_suscripcion, imagen_url) VALUES 
('Estado inicial Carlos', 70.0, 1.75, 'Estado físico inicial de Carlos', 1, 'img/carlos.png'),
('Estado inicial Elena', 65.0, 1.65, 'Estado físico inicial de Elena', 2, 'img/elena.png'),
('Estado inicial Miguel', 80.0, 1.80, 'Estado físico inicial de Miguel', 3, 'img/miguel.png'),
('Primer dia', 62.0, 1.62, 'No hay notas', 1, 'dfb0620c-04ca-48e3-896d-58564f98c35e.png'),
('Primer año', 65.0, 1.62, 'No hay notas', 1, '6ae24067-5412-457d-8c5e-8283a56a2799.png'),
('a', 1.0, 1.23, 'aa', 1, '4ebdea77-3251-4c76-86b9-85bcb7cceed8.png'),
('aaa', 1.0, 1.0, 'aa', 1, '11102705-41c6-4b28-8aa7-7c55f9c15c61.png'),
('Segundo dia', 86.0, 1.75, 'No hay notas', 1, '1eb4a655-61ca-496a-9909-977abfc9a96f.jpg');

