CREATE DATABASE [HotelCasadelSol]
GO

USE [HotelCasadelSol]
GO

CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Apellido] [nvarchar](30) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[Contrasenna] [nvarchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
	[UsuarioRol] [tinyint] NOT NULL,
	[ReservacionID] [bigint] NULL,
	[Edad] [tinyint] NOT NULL,
	[UsuarioError] [bigint] NULL,
    [Identificacion] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/*========================================================================================================*/

CREATE TABLE [dbo].[Roles](
	[RoleID] [tinyint] NOT NULL,
	[RoleDescription] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Roles_1] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*========================================================================================================*/

CREATE TABLE [dbo].[Errores](
	[ErrorID] [bigint] IDENTITY(1,1) NOT NULL,
	[MensajeError] [nvarchar](max) NOT NULL,
	[CodigoError] [int] NOT NULL,
	[OrigenError] [nchar](75) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Errores] PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/*========================================================================================================*/



ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Errores] FOREIGN KEY([UsuarioError])
REFERENCES [dbo].[Errores] ([ErrorID])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Errores]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([UsuarioRol])
REFERENCES [dbo].[Roles] ([RoleID])
GO

ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO






/*========================================================================================================*/

INSERT INTO [dbo].[Roles]
           ([RoleID]
           ,[RoleDescription])
     VALUES
           (1
           ,'Admin')
		   ,(2
		   ,'Cliente')
GO

/*========================================================================================================*/

CREATE PROCEDURE ValidarUsuarios 
	@CorreoElectronico nvarchar(50),
	@Contrasena nvarchar(25)
AS
BEGIN
SELECT UsuarioID
      ,Nombre
      ,Correo
	  ,Contrasenna
      ,Estado
      ,UsuarioRol
  FROM dbo.Usuarios
  WHERE Correo = @CorreoElectronico
  AND Contrasenna = @Contrasena
  AND Estado = 1
END
GO

/*========================================================================================================*/

CREATE PROCEDURE ValidarCorreo
	@CorreoElectronico nvarchar(50)
AS
BEGIN
SELECT Correo
	  ,Estado
  FROM dbo.Usuarios
  WHERE Correo = @CorreoElectronico
END
GO

/*========================================================================================================*/

CREATE PROCEDURE InsertarUsuarios
	@Nombre nvarchar(30),
    @Apellido nvarchar(30),
    @Correo nvarchar(50),
    @Telefono nvarchar(10),
    @Contrasenna nvarchar(25),
    @Estado bit,
    @UsuarioRol tinyint,
    @Edad tinyint,
	@Identificacion nvarchar(10)
AS
BEGIN

INSERT INTO [dbo].[Usuarios]
           ([Nombre]
           ,[Apellido]
           ,[Correo]
           ,[Telefono]
           ,[Contrasenna]
           ,[Estado]
           ,[UsuarioRol]
           ,[Edad]
		   ,[Identificacion])
     VALUES
           (@Nombre
           ,@Apellido
           ,@Correo
           ,@Telefono
           ,@Contrasenna
           ,@Estado
           ,@UsuarioRol
           ,@Edad
		   ,@Identificacion)
END
GO

/*========================================================================================================*/

CREATE PROCEDURE RecuperarContrasenna 
	@CorreoElectronico nvarchar(50)
AS
BEGIN

SELECT [Contrasenna]
  FROM [dbo].[Usuarios]
  WHERE Correo = @CorreoElectronico

END
GO

/*========================================================================================================*/

CREATE PROCEDURE InsertarError
	@MensajeError nvarchar(max),
    @CodigoError int,
    @OrigenError nchar(75),
    @FechaHora datetime

AS
BEGIN

INSERT INTO [dbo].[Errores]
           ([MensajeError]
           ,[CodigoError]
           ,[OrigenError]
           ,[FechaHora])
     VALUES
           (@MensajeError
           ,@CodigoError
           ,@OrigenError
           ,@FechaHora)
END
GO

/*========================================================================================================*/


CREATE PROCEDURE ConsultarXUsuarios
	
AS
BEGIN

	SELECT UsuarioID,
	Correo,
	Estado,
	Nombre,
	Identificacion
	FROM dbo.Usuarios
END








/*========================================================================================================*/
SELECT * FROM Roles;
SELECT * FROM Usuarios;
SELECT * FROM Errores;