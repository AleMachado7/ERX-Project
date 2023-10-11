namespace ERXProject.Core.Products
{
    public class ProductParams
    {
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
    }
}
