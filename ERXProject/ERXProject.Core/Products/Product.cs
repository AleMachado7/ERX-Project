namespace ERXProject.Core.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Sku { get; set; }
        public string Color { get; set; }
        public double AvgCost { get; set; }
        public double CostValue { get; set; }
        public double MinSaleValue { get; set; }
        public double SaleValue { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public List<string> Images { get; set; }
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public List<string> BarCodes { get; set; }
        public int BrandCode { get; set; }
        public string BrandName { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public int SubgroupCode { get; set; }
        public string SubgroupName { get; set; }
        public int UnitMeasurementCode { get; set; }
        public string UnitMeasurementName { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime StatusDate { get; set; }
        public string StatusColor { get; set; }
        public string StatusNote { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

        public Product()
        {
            this.Id = Guid.NewGuid();
            this.Images = new List<string>();
            this.BarCodes = new List<string>();
        }
        public static async Task<Product> CreateAsync(ProductParams createParams)
        {
            Product model = new Product();

            model.TypeCode = createParams.TypeCode;
            model.TypeName = createParams.TypeName;
            model.Name = createParams.Name;
            model.FullName = createParams.FullName;
            model.ShortName = createParams.ShortName;
            model.Model = createParams.Model;
            model.Description = createParams.Description;
            model.Size = createParams.Size;
            model.Sku = createParams.Sku;
            model.Color = createParams.Color;
            model.AvgCost = createParams.AvgCost;
            model.CostValue = createParams.CostValue;
            model.MinSaleValue = createParams.MinSaleValue;
            model.SaleValue = createParams.SaleValue;
            model.Height = createParams.Height;
            model.Width = createParams.Width;
            model.Weight = createParams.Weight;
            model.Length = createParams.Length;
            model.Images = createParams.Images;
            model.ManufacturerCode = createParams.ManufacturerCode;
            model.ManufacturerName = createParams.ManufacturerName;
            model.BarCodes = createParams.BarCodes;
            model.BrandCode = createParams.BrandCode;
            model.BrandName = createParams.BrandName;
            model.GroupCode = createParams.GroupCode;
            model.GroupName = createParams.GroupName;
            model.SubgroupCode = createParams.SubgroupCode;
            model.SubgroupName = createParams.SubgroupName;
            model.UnitMeasurementCode = createParams.UnitMeasurementCode;
            model.UnitMeasurementName = createParams.UnitMeasurementName;
            model.StatusCode = createParams.StatusCode;
            model.StatusName = createParams.StatusName;
            model.StatusDate = createParams.StatusDate;
            model.StatusColor = createParams.StatusColor;
            model.StatusNote = createParams.StatusNote;
            model.MinStock = createParams.MinStock;
            model.MaxStock = createParams.MaxStock;
            model.Quantity = createParams.Quantity;
            model.Note = createParams.Note;

            return model;
        }
    }
}
