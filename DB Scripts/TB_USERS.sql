USE ERX_PROJECT -- database name
GO

IF OBJECT_ID('TB_USERS') IS NULL
	BEGIN
		CREATE TABLE TB_USERS (
		Id UNIQUEIDENTIFIER NOT NULL,
		Code INT NOT NULL,
		Name VARCHAR(255) NOT NULL,
		Access_Key VARCHAR(150) NOT NULL,
		[Password] VARCHAR(150) NOT NULL,
		Email VARCHAR(255),
		Phone VARCHAR(20),
		Type_Code INT NOT NULL,
		[Type_Name] VARCHAR(255),
		Profile_Code INT NOT NULL,
		Profile_Name VARCHAR(255),
		Status_Code INT NOT NULL,
		Status_Name VARCHAR(255),
		Last_Access DATETIME,
		Access_Count INT NOT NULL,
		Enabled BIT NOT NULL,
		Avatar VARCHAR(8000),
		Note VARCHAR(8000),
		)
	END
GO