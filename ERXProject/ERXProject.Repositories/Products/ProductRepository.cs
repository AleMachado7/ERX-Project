using ERXProject.Core.Products;
using OpenERX.Repositories.Shared.Sql;
using System.Data.SqlClient;
using System.Text;

namespace ERXProject.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnectionProvider _connection;
        private readonly IProductImagesRepository _imagesRepository;
        private readonly IProductBarCodesRepository _barCodesRepository;

        public ProductRepository(SqlConnectionProvider connection, IProductImagesRepository imagesRepository, IProductBarCodesRepository barCodesRepository)
        {
            this._connection = connection;
            this._imagesRepository = imagesRepository;
            this._barCodesRepository = barCodesRepository;
        }

        public async Task<Product> InsertAsync(Product product)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine("INSERT INTO [TB_PRODUCTS]")
                .AppendLine(" (")
                .AppendLine("[Id],")
                .AppendLine("[Code],")
                .AppendLine("[Type_Code],")
                .AppendLine("[Type_Name],")
                .AppendLine("[Name],")
                .AppendLine("[Full_Name],")
                .AppendLine("[Short_Name],")
                .AppendLine("[Model],")
                .AppendLine("[Description],")
                .AppendLine("[Size],")
                .AppendLine("[Sku],")
                .AppendLine("[Color],")
                .AppendLine("[Avg_Cost],")
                .AppendLine("[Cost_Value],")
                .AppendLine("[Min_Sale_Value],")
                .AppendLine("[Sale_Value],")
                .AppendLine("[Height],")
                .AppendLine("[Width],")
                .AppendLine("[Weight],")
                .AppendLine("[Length],")
                .AppendLine("[Manufacturer_Code],")
                .AppendLine("[Manufacturer_Name],")
                .AppendLine("[Brand_Code],")
                .AppendLine("[Brand_Name],")
                .AppendLine("[Group_Code],")
                .AppendLine("[Group_Name],")
                .AppendLine("[Subgroup_Code],")
                .AppendLine("[Subgroup_Name],")
                .AppendLine("[Unit_Measurement_Code],")
                .AppendLine("[Unit_Measurement_Name],")
                .AppendLine("[Status_Code],")
                .AppendLine("[Status_Name],")
                .AppendLine("[Status_Date],")
                .AppendLine("[Status_Color],")
                .AppendLine("[Status_Note],")
                .AppendLine("[Min_Stock],")
                .AppendLine("[Max_Stock],")
                .AppendLine("[Quantity],")
                .AppendLine("[Note]")
                .AppendLine(" )")
                .AppendLine(" VALUES")
                .AppendLine(" (")
                .AppendLine("@Id,")
                .AppendLine("@Code,")
                .AppendLine("@Type_Code,")
                .AppendLine("@Type_Name,")
                .AppendLine("@Name,")
                .AppendLine("@Full_Name,")
                .AppendLine("@Short_Name,")
                .AppendLine("@Model,")
                .AppendLine("@Description,")
                .AppendLine("@Size,")
                .AppendLine("@Sku,")
                .AppendLine("@Color,")
                .AppendLine("@Avg_Cost,")
                .AppendLine("@Cost_Value,")
                .AppendLine("@Min_Sale_Value,")
                .AppendLine("@Sale_Value,")
                .AppendLine("@Height,")
                .AppendLine("@Width,")
                .AppendLine("@Weight,")
                .AppendLine("@Length,")
                .AppendLine("@Manufacturer_Code,")
                .AppendLine("@Manufacturer_Name,")
                .AppendLine("@Brand_Code,")
                .AppendLine("@Brand_Name,")
                .AppendLine("@Group_Code,")
                .AppendLine("@Group_Name,")
                .AppendLine("@Subgroup_Code,")
                .AppendLine("@Subgroup_Name,")
                .AppendLine("@Unit_Measurement_Code,")
                .AppendLine("@Unit_Measurement_Name,")
                .AppendLine("@Status_Code,")
                .AppendLine("@Status_Name,")
                .AppendLine("@Status_Date,")
                .AppendLine("@Status_Color,")
                .AppendLine("@Status_Note,")
                .AppendLine("@Min_Stock,")
                .AppendLine("@Max_Stock,")
                .AppendLine("@Quantity,")
                .AppendLine("@Note")
                .AppendLine(" )");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                this.SetParameters(product, query);
                product.Code = await this.GetInsertCodeAsync();
                query.Parameters.Add(new SqlParameter("@code", product.Code));

                await query.ExecuteNonQueryAsync();

                if (product.Images.Count > 0)
                {
                    await this._imagesRepository.InsertImagesAsync(product.Id, product.Images);
                }

                if (product.BarCodes.Count > 0)
                {
                    await this._barCodesRepository.InsertBarCodesAsync(product.Id, product.BarCodes);
                }

                return product;
            }
            catch (Exception e)
            {
                return null;
            };
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var products = new List<Product>();

                var queryString = new StringBuilder()
                .AppendLine(" SELECT * FROM [TB_PRODUCTS]");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                var dataReader = await query.ExecuteReaderAsync();

                while (dataReader.Read())
                {
                    var product = LoadDataReader(dataReader);
                    products.Add(product);
                }

                return products;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Product> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine(" SELECT * FROM [TB_PRODUCTS]")
                .AppendLine(" WHERE Id = @Product_Id");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@Product_Id", id));

                var dataReader = await query.ExecuteReaderAsync();

                Product product = null;

                while (dataReader.Read())
                {
                    product = LoadDataReader(dataReader);
                }

                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Product> GetByCodeAsync(int code)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine(" SELECT * FROM [TB_PRODUCTS]")
                .AppendLine(" WHERE Code = @Product_Code");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@Product_Code", code));

                var dataReader = await query.ExecuteReaderAsync();

                Product product = null;

                while (dataReader.Read())
                {
                    product = LoadDataReader(dataReader);
                }

                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine("UPDATE [TB_PRODUCTS]")
                .AppendLine("SET")
                .AppendLine("[Type_Code] = @Type_Code,")
                .AppendLine("[Type_Name] = @Type_Name,")
                .AppendLine("[Name] = @Name,")
                .AppendLine("[Full_Name] = @Full_Name,")
                .AppendLine("[Short_Name] = @Short_Name,")
                .AppendLine("[Model] = @Model,")
                .AppendLine("[Description] = @Description,")
                .AppendLine("[Size] = @Size,")
                .AppendLine("[Sku] = @Sku,")
                .AppendLine("[Color] = @Color,")
                .AppendLine("[Avg_Cost] = @Avg_Cost,")
                .AppendLine("[Cost_Value] = @Cost_Value,")
                .AppendLine("[Min_Sale_Value] = @Min_Sale_Value,")
                .AppendLine("[Sale_Value] = @Sale_Value,")
                .AppendLine("[Height] = @Height,")
                .AppendLine("[Width] = @Width,")
                .AppendLine("[Weight] = @Weight,")
                .AppendLine("[Length] = @Length,")
                .AppendLine("[Manufacturer_Code] = @Manufacturer_Code,")
                .AppendLine("[Manufacturer_Name] = @Manufacturer_Name,")
                .AppendLine("[Brand_Code] = @Brand_Code,")
                .AppendLine("[Brand_Name] = @Brand_Name,")
                .AppendLine("[Group_Code] = @Group_Code,")
                .AppendLine("[Group_Name] = @Group_Name,")
                .AppendLine("[Subgroup_Code] = @Subgroup_Code,")
                .AppendLine("[Subgroup_Name] = @Subgroup_Name,")
                .AppendLine("[Unit_Measurement_Code] = @Unit_Measurement_Code,")
                .AppendLine("[Unit_Measurement_Name] = @Unit_Measurement_Name,")
                .AppendLine("[Status_Code] = @Status_Code,")
                .AppendLine("[Status_Name] = @Status_Name,")
                .AppendLine("[Status_Date] = @Status_Date,")
                .AppendLine("[Status_Color] = @Status_Color,")
                .AppendLine("[Status_Note] = @Status_Note,")
                .AppendLine("[Min_Stock] = @Min_Stock,")
                .AppendLine("[Max_Stock] = @Max_Stock,")
                .AppendLine("[Quantity] = @Quantity,")
                .AppendLine("[Note] = @Note")
                .AppendLine("WHERE Id = @Product_Id");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                this.SetParameters(product, query);
                query.Parameters.Add(new SqlParameter("@Product_Id", product.Id)); ;

                await query.ExecuteNonQueryAsync();

                return product;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void SetParameters(Product product, SqlCommand query)
        {
            query.Parameters.Add(new SqlParameter("@Id", product.Id.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Type_Code", product.TypeCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Type_Name", product.TypeName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Name", product.Name.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Full_Name", product.FullName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Short_Name", product.ShortName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Model", product.Model.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Description", product.Description.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Size", product.Size.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Sku", product.Sku.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Color", product.Color.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Avg_Cost", product.AvgCost.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Cost_Value", product.CostValue.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Min_Sale_Value", product.MinSaleValue.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Sale_Value", product.SaleValue.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Height", product.Height.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Width", product.Width.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Weight", product.Weight.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Length", product.Length.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Manufacturer_Code", product.ManufacturerCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Manufacturer_Name", product.ManufacturerName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Brand_Code", product.BrandCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Brand_Name", product.BrandName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Group_Code", product.GroupCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Group_Name", product.GroupName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Subgroup_Code", product.SubgroupCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Subgroup_Name", product.SubgroupName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Unit_Measurement_Code", product.UnitMeasurementCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Unit_Measurement_Name", product.UnitMeasurementName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Status_Code", product.StatusCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Status_Name", product.StatusName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Status_Date", product.StatusDate.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Status_Color", product.StatusColor.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Status_Note", product.StatusNote.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Min_Stock", product.MinStock.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Max_Stock", product.MaxStock.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Quantity", product.Quantity.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@Note", product.Note.GetDbValue()));
        }

        private static Product LoadDataReader(SqlDataReader dataReader)
        {
            var product = new Product();

            product.Id = dataReader.GetGuid("id");
            product.Code = dataReader.GetInt32("code");
            product.TypeCode = dataReader.GetInt32("type_code");
            product.TypeName = dataReader.GetString("type_name");
            product.Name = dataReader.GetString("name");
            product.FullName = dataReader.GetString("full_name");
            product.ShortName = dataReader.GetString("short_name");
            product.Model = dataReader.GetString("model");
            product.Description = dataReader.GetString("description");
            product.Size = dataReader.GetString("size");
            product.Sku = dataReader.GetString("sku");
            product.Color = dataReader.GetString("color");
            product.AvgCost = dataReader.GetDouble("avg_cost");
            product.CostValue = dataReader.GetDouble("cost_value");
            product.MinSaleValue = dataReader.GetDouble("min_sale_value");
            product.SaleValue = dataReader.GetDouble("sale_value");
            product.Height = dataReader.GetDouble("height");
            product.Width = dataReader.GetDouble("width");
            product.Weight = dataReader.GetDouble("weight");
            product.Length = dataReader.GetDouble("length");
            product.ManufacturerCode = dataReader.GetInt32("manufacturer_code");
            product.ManufacturerName = dataReader.GetString("manufacturer_name");
            product.BrandCode = dataReader.GetInt32("brand_code");
            product.BrandName = dataReader.GetString("brand_name");
            product.GroupCode = dataReader.GetInt32("group_code");
            product.GroupName = dataReader.GetString("group_name");
            product.SubgroupCode = dataReader.GetInt32("subgroup_code");
            product.SubgroupName = dataReader.GetString("subgroup_name");
            product.UnitMeasurementCode = dataReader.GetInt32("unit_measurement_code");
            product.UnitMeasurementName = dataReader.GetString("unit_measurement_name");
            product.StatusCode = dataReader.GetInt32("status_code");
            product.StatusName = dataReader.GetString("status_name");
            product.StatusDate = dataReader.GetDateTime("status_date");
            product.StatusColor = dataReader.GetString("status_color");
            product.StatusNote = dataReader.GetString("status_note");
            product.MinStock = dataReader.GetInt32("min_stock");
            product.MaxStock = dataReader.GetInt32("max_stock");
            product.Quantity = dataReader.GetInt32("quantity");
            product.Note = dataReader.GetString("note");

            return product;
        }

        private async Task<int> GetInsertCodeAsync()
        {
            var queryString = new StringBuilder()
                .AppendLine(" SELECT COUNT(*)")
                .AppendLine(" FROM TB_PRODUCTS");

            var connection = await this._connection.CreateConnectionAsync();
            var query = connection.CreateCommand();

            query.CommandText = queryString.ToString();

            var code = Convert.ToInt32(await query.ExecuteScalarAsync());

            code++;

            return code;
        }
    }
}
