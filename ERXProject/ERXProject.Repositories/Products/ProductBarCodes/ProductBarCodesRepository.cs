using ERXProject.Core.Products;
using OpenERX.Repositories.Shared.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ERXProject.Repositories.Products.ProductBarCodes
{
    public class ProductBarCodesRepository : IProductBarCodesRepository
    {
        private readonly SqlConnectionProvider _connection;

        public ProductBarCodesRepository(SqlConnectionProvider connection)
        {
            this._connection = connection;
        }

        public async Task<bool> InsertBarCodesAsync(Guid productId, List<string> barCodes)
        {
            try
            {
                using var connection = await this._connection.CreateConnectionAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Product_Id", typeof(Guid)));
                dt.Columns.Add(new DataColumn("Bar_Code_URL", typeof(string)));

                foreach (var barCode in barCodes)
                {
                    dt.Rows.Add(new string[] { productId.ToString(), barCode });
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(connection))
                {
                    bc.DestinationTableName = "TB_PRODUCTS_BAR_CODES";
                    bc.ColumnMappings.Add("Product_Id", "Product_Id");
                    bc.ColumnMappings.Add("Bar_Code_URL", "Bar_Code_URL");

                    await bc.WriteToServerAsync(dt);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            };
        }

        public async Task<bool> DeleteBarCodesAsync(Guid productId)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine(" DELETE FROM [TB_PRODUCTS_BAR_CODES]")
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

        public async Task<List<string>> GetBarCodesAsync(Guid productId)
        {
            try
            {
                var barCodes = new List<string>();

                var queryString = new StringBuilder()
                .AppendLine(" SELECT Bar_Code_URL FROM TB_PRODUCTS_BAR_CODES")
                .AppendLine(" WHERE Product_Id = @Product_Id");

                var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();

                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@Product_Id", productId));

                var dataReader = await query.ExecuteReaderAsync();

                while (dataReader.Read())
                {
                    barCodes.Add(dataReader.GetString("Bar_Code_URL"));
                }

                return barCodes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
