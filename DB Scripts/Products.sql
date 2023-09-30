USE ERX_PROJECT
GO

IF OBJECT_ID('Products') IS NULL 
	BEGIN
		CREATE TABLE Products (
		Id UNIQUEIDENTIFIER NOT NULL,
		Code INT NOT NULL,
		TypeCode INT NOT NULL,
		TypeName VARCHAR(255),
		Name VARCHAR(255) NOT NULL,
		FullName VARCHAR(255),
		ShortName VARCHAR(255),
		Model VARCHAR(255),
		Description VARCHAR(255),
		Size VARCHAR(255),
		Sku VARCHAR(50) NOT NULL,
		Color VARCHAR(25),
		AvgCost DECIMAL(10, 2) NOT NULL,
		CostValue DECIMAL(10, 2),
		MinSaleValue DECIMAL(10, 2),
		SaleValue DECIMAL(10, 2),
		Height DECIMAL(10, 2),
		Width DECIMAL(10, 2),
		Weight DECIMAL(10, 2),
		Length DECIMAL(10, 2),
		Images VARCHAR(255) NOT NULL,
		ManufacturerCode INT NOT NULL,
		ManufacturerName VARCHAR(255) NOT NULL,
		BarCodes VARCHAR(255),
		BrandCode INT NOT NULL,
		BrandName VARCHAR(255) NOT NULL,
		GroupCode INT NOT NULL,
		GroupName VARCHAR(255) NOT NULL,
		SubgroupCode INT NOT NULL,
		SubgroupName VARCHAR(255) NOT NULL,
		UnitMeasurementCode INT NOT NULL,
		UnitMeasurementName VARCHAR(255) NOT NULL,
		StatusCode INT NOT NULL,
		StatusName VARCHAR(150) NOT NULL,
		StatusDate DATETIME NOT NULL,
		StatusColor VARCHAR(25),
		StatusNote VARCHAR(255),
		MinStock INT,
		MaxStock INT,
		Quantity INT,
		Note VARCHAR(8000)
		)
	END
GO
