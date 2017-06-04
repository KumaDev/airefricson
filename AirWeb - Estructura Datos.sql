USE [AirWeb]
GO
/****** Object:  Table [dbo].[Auditoria_Tablas]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Auditoria_Tablas](
	[IdAuditoria] [int] IDENTITY(1,1) NOT NULL,
	[Tabla] [varchar](100) NULL,
	[Campo] [varchar](100) NULL,
	[Anterior] [varchar](3000) NULL,
	[Nuevo] [varchar](3000) NULL,
	[Usuario] [varchar](100) NULL,
	[Proceso] [varchar](20) NULL,
	[Fecha] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu_Items]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu_Items](
	[IdItemMenu] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Idhead] [int] NULL,
	[Posicion] [int] NULL,
	[Icono] [varchar](50) NULL,
	[Url] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu_Tipos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Tipos](
	[IdMenu] [int] NOT NULL,
	[IdItemMenu] [int] NOT NULL,
	[PorDefecto] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamentos](
	[IdDepartamento] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Departamento] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL 
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Idusuario] [int] NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Mail] [varchar](500) NULL,
	[Telefono] [varchar](100) NULL,
	[Activo] [int] NULL,
	[Bloqueado] [int] NULL,
	[ActiveDirectory] [int] NULL,
	[IdMenu] [int] NULL,
	[IdDepartamento] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Causas]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Causas](
	[IdCausa] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Causa] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL 
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Areas](
	[IdArea] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Area] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL 
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clases](
	[IdClase] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Clase] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL 
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[IdEstado] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Estado] [varchar](100) NULL,
	[EstadoIni] [int] NULL,
	[EstadoFin] [int] NULL,
	[Activo] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Motivos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Motivos](
	[IdMotivo] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Motivo] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GruposSeguimiento]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GruposSeguimiento](
	[IdGrupoSeguimiento] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[GrupoSeguimiento] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GruposSeguimientoUsuarios]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GruposSeguimientoUsuarios](
	[IdGrupoSeguimientoUsuario] [int] NOT NULL,
	[IdGrupoSeguimiento] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrigenTipos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrigenTipos](
	[IdOrigenTipo] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[OrigenTipo] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Origenes]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Origenes](
	[IdOrigen] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Origen] [varchar](100) NULL,
	[idOrigenTipo] [int] NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PartesCuerpo]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PartesCuerpo](
	[IdParteCuerpo] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[ParteCuerpo] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prioridades]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prioridades](
	[IdPrioridad] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Prioridad] [varchar](100) NULL,
	[DiasVto] [int] NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Propositos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Propositos](
	[IdProoposito] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[Proposito] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiposLesion]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposLesion](
	[IdTipoLesion] [int] NOT NULL,
	[Codigo] [varchar](5) NULL,
	[TipoLesion] [varchar](100) NULL,
	[Activo] [int] NULL,
	[PorDefecto] [int] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Eventos](
	[IdEvento] [int] NOT NULL,
	[NroEvento] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[Titulo] [varchar](350) NOT NULL,
	[Descripcion] [varchar](1500) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdOrigen] [int] NOT NULL,
	[IdArea] [int] NOT NULL,
	[AreaDetalle] [varchar](500) NOT NULL,
	[IdClase] [int] NULL,
	[IdMotivo] [int] NULL,
	[DMLAplica] [int] NULL,
	[DMLEstado] [int] NULL,
	[DMLDescripcion] [varchar](1000) NULL,
	[EHSInvestigacion] [varchar](1000) NULL,
	[EHSRecomendacion] [varchar](1000) NULL,
	[IdCausa] [int] NULL,
	[CausaDetalle] [varchar](500) NULL,
	[Activo] [int] NULL,
	[InactivoCausa] [varchar](500) NULL,
	[FechaCierre] [datetime] NULL,
	[IDAnterior] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventoAdjuntos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventoAdjuntos](
	[IdEventoAdjunto] [int] NOT NULL,
	[IdEvento] [int] NOT NULL,
	[FechaAdjuntado] [datetime] NOT NULL,
	[Archivo] [varchar](1000) NOT NULL,
	[Comentarios] [varchar](1000) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventoPersonasAfectadas]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventoPersonasAfectadas](
	[IdEventoPersona] [int] NOT NULL,
	[IdEvento] [int] NOT NULL,
	[IdUsuarioAfectado] [int] NOT NULL,
	[FechaAgregado] [datetime] NOT NULL,
	[Persona] [varchar](1000) NOT NULL,
	[Comentarios] [varchar](1000) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventoPersonasLesiones]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventoPersonasLesiones](
	[IdEventoPersonaLesion] [int] NOT NULL,
	[IdEventoPersona] [int] NOT NULL,
	[IdTipoLesion] [int] NOT NULL,
	[IdParteCuerpo] [int] NOT NULL,
	[FechaAgregado] [datetime] NOT NULL,
	[Comentarios] [varchar](1000) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Acciones]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Acciones](
	[IdAccion] [int] NOT NULL,
	[NroAccion] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[Titulo] [varchar](350) NOT NULL,
	[Descripcion] [varchar](1500) NOT NULL,
	[FechaCreada] [datetime] NOT NULL,
	[FechaInicio] [datetime] NULL,
	[FechaUltRev] [datetime] NULL,
	[FechaAcordada] [datetime] NOT NULL,
	[FechaFinalizada] [datetime] NULL,
	[FechaVerEHS] [datetime] NOT NULL,
	[IdArea] [int] NOT NULL,
	[AreaDetalle] [varchar](500) NOT NULL,
	[IdPrioridad] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdGrupoSeguimiento] [int] NOT NULL,
	[IdProoposito] [int] NOT NULL,
	[Costo] [int] NULL,
	[Realizador] [varchar](500) NULL,
	[DetalleTareaRealizada] [varchar](500) NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccionAdjuntos]    Script Date: 06/01/2017 10:48:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccionAdjuntos](
	[IdAccionAdjunto] [int] NOT NULL,
	[IdAccion] [int] NOT NULL,
	[FechaAdjuntado] [datetime] NOT NULL,
	[Archivo] [varchar](1000) NOT NULL,
	[Comentarios] [varchar](1000) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Activo] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO