namespace ERXProject.Core.Products
{
    public class ProductResult
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
        public IList<string> Images { get; set; }
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public IList<string> BarCodes { get; set; }
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

        public ProductResult(Product product)
        {
            this.Id = product.Id;
            this.Code = product.Code;
            this.TypeCode = product.TypeCode;
            this.TypeName = product.TypeName;
            this.Name = product.Name;
            this.FullName = product.FullName;
            this.ShortName = product.ShortName;
            this.Model = product.Model;
            this.Description = product.Description;
            this.Size = product.Size;
            this.Sku = product.Sku;
            this.Color = product.Color;
            this.AvgCost = product.AvgCost;
            this.CostValue = product.CostValue;
            this.MinSaleValue = product.MinSaleValue;
            this.SaleValue = product.SaleValue;
            this.Height = product.Height;
            this.Width = product.Width;
            this.Weight = product.Weight;
            this.Length = product.Length;
            this.Images = product.Images;
            this.ManufacturerCode = product.ManufacturerCode;
            this.ManufacturerName = product.ManufacturerName;
            this.BarCodes = product.BarCodes;
            this.BrandCode = product.BrandCode;
            this.BrandName = product.BrandName;
            this.GroupCode = product.GroupCode;
            this.GroupName = product.GroupName;
            this.SubgroupCode = product.SubgroupCode;
            this.SubgroupName = product.SubgroupName;
            this.UnitMeasurementCode = product.UnitMeasurementCode;
            this.UnitMeasurementName = product.UnitMeasurementName;
            this.StatusCode = product.StatusCode;
            this.StatusName = product.StatusName;
            this.StatusDate = product.StatusDate;
            this.StatusColor = product.StatusColor;
            this.StatusNote = product.StatusNote;
            this.MinStock = product.MinStock;
            this.MaxStock = product.MaxStock;
            this.Quantity = product.Quantity;
            this.Note = product.Note;
        }
    }
}
