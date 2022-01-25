/* Users */
CREATE PROCEDURE GetUsers
AS BEGIN
	Select u.UserId,u.[Address],u.[Name],u.PhoneNumber,c.[Name] as CityName, s.[Name] as StateName, co.[Name] as CountryName
	from Users u join Cities c on u.CityId = c.CityId join States s on s.StateId = c.StateId join Countries co on co.CountryId = s.CountryId
END
GO

CREATE PROCEDURE PostUser
	@UserId integer,
	@Name nvarchar(max),
	@PhoneNumber nvarchar(max),
	@Address nvarchar(max),
	@CityId integer
AS BEGIN

INSERT INTO [dbo].[Users]
           ([UserId]
           ,[Name]
           ,[PhoneNumber]
           ,[Address]
           ,[CityId])
     VALUES
           (
			@UserId
           ,@Name
           ,@PhoneNumber
           ,@Address
           ,@CityId)

Select u.UserId,u.[Address],u.[Name],u.PhoneNumber,c.[Name] as CityName, s.[Name] as StateName, co.[Name] as CountryName
from Users u join Cities c on u.CityId = c.CityId join States s on s.StateId = c.StateId join Countries co on co.CountryId = s.CountryId where UserId=@UserId
END
GO

CREATE PROCEDURE DeleteUserById
	@UserId int
AS BEGIN
	Delete from Users where UserId = @UserId
	Select * from Users where UserId=@UserId
END
GO

/* Cities */

CREATE PROCEDURE GetCities
AS BEGIN
	Select * from Cities
END
GO

CREATE PROCEDURE PostCity
	@CityId integer,
	@Code nvarchar(max),
	@Name nvarchar(max),
	@StateId integer
AS BEGIN

INSERT INTO [dbo].[Cities]
           ([CityId]
           ,[Code]
           ,[Name]
           ,[StateId])
     VALUES
           (@CityId
           ,@Code
           ,@Name
           ,@StateId)
Select * from Cities where CityId=@CityId
END
GO

CREATE PROCEDURE DeleteCityById
	@CityId int
AS BEGIN
	Delete from Cities where CityId = @CityId
	Select * from Cities where CityId=@CityId
END
GO

/* Countries */

CREATE PROCEDURE GetCountries
AS BEGIN
	Select * from Countries
END
GO

CREATE PROCEDURE PostCountry
	@CountryId integer,
	@Code nvarchar(max),
	@Name nvarchar(max)
AS BEGIN

INSERT INTO [dbo].[Countries]
           ([CountryId]
           ,[Code]
           ,[Name])
     VALUES
           (@CountryId
           ,@Code
           ,@Name)
Select * from Countries where CountryId=@CountryId
END
GO

CREATE PROCEDURE DeleteCountryById
	@CountryId int
AS BEGIN
	Delete from Countries where CountryId = @CountryId
	Select * from Countries where CountryId=@CountryId
END
GO


/* States */

CREATE PROCEDURE GetStates
AS BEGIN
	Select * from States
END
GO

CREATE PROCEDURE PostState
	@StateId integer,
	@Code nvarchar(max),
	@Name nvarchar(max),
	@CountryId integer
AS BEGIN

INSERT INTO [dbo].[States]
           ([StateId]
           ,[Code]
           ,[Name]
		   ,[CountryId])
     VALUES
           (@StateId
           ,@Code
           ,@Name
		   ,@CountryId)
Select * from States where StateId=@StateId
END
GO

CREATE PROCEDURE DeleteStateById
	@StateId int
AS BEGIN
	Delete from States where StateId = @StateId
	Select * from States where StateId=@StateId
END
GO