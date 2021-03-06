USE [master]
GO
/****** Object:  Database [API_REST]    Script Date: 06/03/2020 07:41:24 a. m. ******/
CREATE DATABASE [API_REST]
GO
USE [API_REST]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [API_REST]
GO
/****** Object:  Table [dbo].[GPS_DATA]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPS_DATA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateSystem] [datetime] NOT NULL,
	[DateEvent] [datetime] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Battery] [int] NULL,
	[Source] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_GPS_DATA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GPS_DATA_A]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GPS_DATA_A]
@dateEvent DATETIME,
@latitude FLOAT,
@longitude FLOAT,
@battery FLOAT,
@source FLOAT,
@type INT,
@answer INT OUTPUT

AS

BEGIN

INSERT INTO GPS_DATA (DateSystem,DateEvent,Latitude,Longitude,Battery,[Source],Type)
VALUES (GETDATE(),@dateEvent,@latitude,@longitude,@battery,@source,@type)

SET @answer=(SELECT SCOPE_IDENTITY())

END
GO
/****** Object:  StoredProcedure [dbo].[GPS_DATA_D]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GPS_DATA_D]
@Id INT,
@answer INT OUTPUT

AS
BEGIN

DELETE FROM GPS_DATA WHERE id = @Id

SET @answer= (SELECT @@ROWCOUNT)

END
GO
/****** Object:  StoredProcedure [dbo].[GPS_DATA_GA]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[GPS_DATA_GA]
AS
BEGIN 

SELECT Id
      ,DateSystem
      ,DateEvent
      ,Latitude
      ,Longitude
      ,Battery
      ,Source
      ,Type
  FROM GPS_DATA


      
END

GO
/****** Object:  StoredProcedure [dbo].[GPS_DATA_GO]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[GPS_DATA_GO]
@id INT 
AS
BEGIN 

SELECT Id
      ,DateSystem
      ,DateEvent
      ,Latitude
      ,Longitude
      ,Battery
      ,Source
      ,Type
  FROM GPS_DATA WHERE Id=@id


      
END

GO
/****** Object:  StoredProcedure [dbo].[GPS_DATA_U]    Script Date: 06/03/2020 07:41:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GPS_DATA_U]@id int,@dateEvent datetime,@latitude float,@longitude float,@battery int,@source int,@type int,@answer INT OUTPUTASBEGINUPDATE GPS_DATA set  DateSystem = GETDATE(),                      DateEvent = @dateEvent,                      Latitude = @latitude,                      Longitude = @longitude,                      Battery = @battery,                      Source = @source,                      Type= @type                      where Id = @id                      SET @answer=(SELECT @@ROWCOUNT)                      END
GO
USE [master]
GO
ALTER DATABASE [API_REST] SET  READ_WRITE 
GO
