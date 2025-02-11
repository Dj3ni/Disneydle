/*
Script de déploiement pour DB_Disneydle

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_Disneydle"
:setvar DefaultFilePrefix "DB_Disneydle"
:setvar DefaultDataPath "C:\Users\jf_bl\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\jf_bl\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Création de Table [dbo].[Character]...';


GO
CREATE TABLE [dbo].[Character] (
    [Character_Id]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (150) NOT NULL,
    [ClothingColor] NVARCHAR (150) NOT NULL,
    [Role]          NVARCHAR (50)  NOT NULL,
    [ParutionYear]  SMALLINT       NOT NULL,
    [Gender]        NVARCHAR (50)  NOT NULL,
    [HairColor]     NVARCHAR (100) NOT NULL,
    [Type]          NVARCHAR (100) NOT NULL,
    [Continent]     NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Character_Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Quote]...';


GO
CREATE TABLE [dbo].[Quote] (
    [Quote_Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Content]      NVARCHAR (MAX) NOT NULL,
    [Character_Id] INT            NULL,
    [Clip]         NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Quote_Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Song]...';


GO
CREATE TABLE [dbo].[Song] (
    [Song_Id] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Song_Id] ASC)
);


GO
PRINT N'Création de Table [dbo].[SongCharacter]...';


GO
CREATE TABLE [dbo].[SongCharacter] (
    [Song_Id]      INT NOT NULL,
    [Character_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Song_Id] ASC, [Character_Id] ASC)
);


GO
PRINT N'Création de Contrainte par défaut contrainte sans nom sur [dbo].[Character]...';


GO
ALTER TABLE [dbo].[Character]
    ADD DEFAULT 'none' FOR [HairColor];


GO
PRINT N'Création de Clé étrangère contrainte sans nom sur [dbo].[Quote]...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD FOREIGN KEY ([Character_Id]) REFERENCES [dbo].[Character] ([Character_Id]);


GO
PRINT N'Création de Clé étrangère contrainte sans nom sur [dbo].[SongCharacter]...';


GO
ALTER TABLE [dbo].[SongCharacter] WITH NOCHECK
    ADD FOREIGN KEY ([Song_Id]) REFERENCES [dbo].[Song] ([Song_Id]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère contrainte sans nom sur [dbo].[SongCharacter]...';


GO
ALTER TABLE [dbo].[SongCharacter] WITH NOCHECK
    ADD FOREIGN KEY ([Character_Id]) REFERENCES [dbo].[Character] ([Character_Id]) ON DELETE CASCADE;


GO
PRINT N'Création de Contrainte de validation contrainte sans nom sur [dbo].[Character]...';


GO
ALTER TABLE [dbo].[Character] WITH NOCHECK
    ADD CHECK ([ParutionYear] Between 1900 and 2100);


GO
PRINT N'Création de Contrainte de validation contrainte sans nom sur [dbo].[Character]...';


GO
ALTER TABLE [dbo].[Character] WITH NOCHECK
    ADD CHECK ([Gender] in ('Male','Female','Other'));


GO
PRINT N'Création de Contrainte de validation contrainte sans nom sur [dbo].[Character]...';


GO
ALTER TABLE [dbo].[Character] WITH NOCHECK
    ADD CHECK ([Continent] in ('Asia','Africa','Europe','Océania','North America','South America'));


GO
PRINT N'Création de Contrainte de validation contrainte sans nom sur [dbo].[Quote]...';


GO
ALTER TABLE [dbo].[Quote] WITH NOCHECK
    ADD CHECK (Len([Content])>=2);


GO
PRINT N'Création de Procédure [dbo].[SP_Character_Insert]...';


GO
CREATE PROCEDURE [dbo].[SP_Character_Insert]
	@name Nvarchar(150),
	@clothingColor Nvarchar(150),
	@role Nvarchar(50),
	@parutionYear smallInt,
	@gender varchar(50),
	@hairColor varchar(100),
	@type varchar(100),
	@continent varchar(20)

AS
BEGIN
	Insert Into [Character]([Name], [ClothingColor],[Role],[ParutionYear],[Gender],[HairColor],[Type],[Continent])
		Output [Inserted] [Character_Id]
		Values
			(@name, @clothingColor, @role, @parutionYear,@gender,@hairColor,@type,@continent)
END
GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/* Variables pour les tables*/

Declare @CharacterJson NVARCHAR(Max)

Set @CharacterJson ='[
    {
    "name": "Mickey Mouse",
    "clothingColor": "Red",
    "role": "Protagonist",
    "parutionYear": 1928,
    "gender": "Male",
    "hairColor": "None",
    "type":"Mouse",
    "continent": "North America"
    },
    {
    "name": "Donald Duck",
    "clothingColor": "Blue",
    "role": "Sidekick",
    "parutionYear": 1934,
    "gender": "Male",
    "hairColor": "White",
    "type": "Bird",
    "continent": "North America"
    },
    {
    "name": "Cinderella",
    "clothingColor": "Blue",
    "role": "Protagonist",
    "parutionYear": 1950,
    "gender": "Female",
    "hairColor": "Blonde",
    "type": "Human",
    "continent": "Europe"
    },
    {
    "name": "Maleficent",
    "clothingColor": "Black and Purple",
    "role": "Antagonist",
    "parutionYear": 1959,
    "gender": "Female",
    "hairColor": "Black",
    "type": "Dark Fairy",
    "continent": "Europe"
    },
    {
    "name": "Mulan",
    "clothingColor": "Green and Blue",
    "role": "Protagonist",
    "parutionYear": 1998,
    "gender": "Female",
    "hairColor": "Black",
    "type": "Human",
    "continent": "Asia"
    },
    {
    "name": "Simba",
    "clothingColor": "Golden",
    "role": "Protagonist",
    "parutionYear": 1994,
    "gender": "Male",
    "hairColor": "Golden",
    "type": "Lion",
    "continent": "Africa"
    }]'

	-- Déclaration de la table variable pour stocker les IDs insérés
DECLARE @InsertedCharacterIds TABLE (Character_Id int);
Declare @InsertedQuoteIds Table (Quote_Id int)

/* Insert 5 Charcters into Table Character */

-- Mickey
INSERT INTO @InsertedCharacterIds (Character_Id)
EXEC SP_Character_Insert 
    @name = 'Mickey Mouse', 
    @clothingColor = 'Red', 
    @role = 'Protagonist',
    @parutionYear = 1928,
    @gender = 'Male',
    @hairColor = 'None',
    @type = 'Mouse',
    @continent = 'North America';

DECLARE @Char1Id INT;
SELECT @Char1Id = Character_Id FROM @InsertedCharacterIds;

-- Donald
INSERT INTO @InsertedCharacterIds (Character_Id)
EXEC SP_Character_Insert 
    @name = 'Donald Duck', 
    @clothingColor = 'Blue', 
    @role = 'Sidekick',
    @parutionYear = 1934,
    @gender = 'Male',
    @hairColor = 'White',
    @type = 'Bird',
    @continent = 'North America';

DECLARE @Char2Id INT;
SELECT @Char2Id = Character_Id FROM @InsertedCharacterIds;

-- Mulan
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Mulan', 
	@clothingColor = 'Green and Blue', 
	@role= 'Protagonist',
	@parutionYear = 1998,
	@gender ='Female',
	@hairColor = 'Black',
	@type = 'Human',
	@continent='Asia'
	/* On va chercher l'id attribué par la table*/
Declare @Char3Id int;
Select @Char3Id = Character_Id From @InsertedCharacterIds

-- Cinderella
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Cinderella', 
	@clothingColor = 'Blue', 
	@role= 'Protagonist',
	@parutionYear = 1950,
	@gender ='Female',
	@hairColor = 'Blonde',
	@type = 'Human',
	@continent='Europe'
	/* On va chercher l'id attribué par la table*/
Declare @Char4Id int;
Select @Char4Id = Character_Id From @InsertedCharacterIds

-- Maleficent
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Maleficent', 
	@clothingColor = 'Black and Purple', 
	@role= 'Antagonist',
	@parutionYear = 1959,
	@gender ='Female',
	@hairColor = 'Black',
	@type = 'Dark Fairy',
	@continent='Europe'
	/* On va chercher l'id attribué par la table*/
Declare @Char5Id int;
Select @Char5Id = Character_Id From @InsertedCharacterIds

-- Pascal
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Pascal', 
	@clothingColor = 'Green', 
	@role= 'Companion',
	@parutionYear = 2010,
	@gender ='Male',
	@hairColor = '',
	@type = 'Chameleon',
	@continent='Europe'
	/* On va chercher l'id attribué par la table*/
Declare @Char6Id int;
Select @Char6Id = Character_Id From @InsertedCharacterIds

/* Insertion de citations */
GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Quote'), OBJECT_ID(N'dbo.SongCharacter'), OBJECT_ID(N'dbo.Character'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Vérification de la contrainte : ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Échec de vérification de la contrainte :' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'Une erreur s''est produite lors de la vérification des contraintes', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Mise à jour terminée.';


GO
