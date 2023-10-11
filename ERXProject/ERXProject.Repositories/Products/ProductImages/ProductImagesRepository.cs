using ERXProject.Core.Products;
using OpenERX.Repositories.Shared.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERXProject.Repositories.Products.ProductImages
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly SqlConnectionProvider _connection;

        public ProductImagesRepository(SqlConnectionProvider connection)
        {
            this._connection = connection;
        }

        public async Task<bool> InsertImagesAsync(Guid productId, List<string> images)
        {
            try
            {
                using var connection = await this._connection.CreateConnectionAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Product_Id", typeof(Guid)));
                dt.Columns.Add(new DataColumn("Image_URL", typeof(string)));

                foreach (var image in images)
                {
                    dt.Rows.Add(new string[] { productId.ToString(), image });
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(connection))
                {
                    bc.DestinationTableName = "TB_PRODUCTS_IMAGES";
                    bc.ColumnMappings.Add("Product_Id", "Product_Id");
                    bc.ColumnMappings.Add("Image_URL", "Image_URL");

                    await bc.WriteToServerAsync(dt);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            };
        }

        public async Task<bool> DeleteImagesAsync(Guid productId)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine(" DELETE FROM [TB_PRODUCTS_IMAGES]")
                .AppendLine(" WHERE Product_Id = @Product_Id");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@Product_Id", productId));

                await query.ExecuteNonQueryAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            };
        }

        public async Task<List<string>> GetImagesAsync(Guid productId)
        {
            try
            {
                var images = new List<string>();

                var queryString = new StringBuilder()
                .AppendLine(" SELECT Image_URL FROM TB_PRODUCTS_IMAGES")
                .AppendLine(" WHERE Product_Id = @Product_Id");

                var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();

                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@Product_Id", productId));

                var dataReader = await query.ExecuteReaderAsync();

                while (dataReader.Read())
                {
                    images.Add(dataReader.GetString("Image_URL"));
                }

                return images;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
