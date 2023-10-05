USE ERX_PROJECT -- database name
GO

IF OBJECT_ID('TB_PRODUCTS') IS NULL 
	BEGIN
		CREATE TABLE TB_PRODUCTS (
		Id UNIQUEIDENTIFIER NOT NULL,
		Code INT NOT NULL,
		Type_Code INT NOT NULL,
		[Type_Name] VARCHAR(255),
		[Name] VARCHAR(255) NOT NULL,
		Full_Name VARCHAR(255),
		Short_Name VARCHAR(255),
		Model VARCHAR(255),
		[Description] VARCHAR(255),
		Size VARCHAR(255),
		Sku VARCHAR(50) NOT NULL,
		Color VARCHAR(25),
		Avg_Cost DECIMAL(10, 2) NOT NULL,
		Cost_Value DECIMAL(10, 2),
		Min_Sale_Value DECIMAL(10, 2),
		Sale_Value DECIMAL(10, 2),
		Height DECIMAL(10, 2),
		Width DECIMAL(10, 2),
		[Weight] DECIMAL(10, 2),
		[Length] DECIMAL(10, 2),
		Manufacturer_Code INT NOT NULL,
		Manufacturer_Name VARCHAR(255) NOT NULL,
		Brand_Code INT NOT NULL,
		Brand_Name VARCHAR(255) NOT NULL,
		Group_Code INT NOT NULL,
		Group_Name VARCHAR(255) NOT NULL,
		Subgroup_Code INT NOT NULL,
		Subgroup_Name VARCHAR(255) NOT NULL,
		Unit_Measurement_Code INT NOT NULL,
		Unit_Measurement_Name VARCHAR(255) NOT NULL,
		Status_Code INT NOT NULL,
		Status_Name VARCHAR(150) NOT NULL,
		Status_Date DATETIME NOT NULL,
		Status_Color VARCHAR(25),
		Status_Note VARCHAR(255),
		Min_Stock INT,
		Max_Stock INT,
		Quantity INT,
		Note VARCHAR(8000)
		)
	END
GO
