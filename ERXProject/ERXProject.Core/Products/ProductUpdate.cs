namespace ERXProject.Core.Products
{
    public static class ProductUpdate
    {
        public static async Task<Product> Update(this Product _this, ProductParams updateParams)
        {
            if (updateParams.TypeCode != null)
            {
                _this.TypeCode = updateParams.TypeCode;
            }

            if (updateParams.TypeCode != null)
            {
                _this.TypeCode = updateParams.TypeCode;
            }

            if (updateParams.Name != null)
            {
                _this.Name = updateParams.Name;
            }

            if (updateParams.FullName != null)
            {
                _this.FullName = updateParams.FullName;
            }

            if (updateParams.ShortName != null)
            {
                _this.ShortName = updateParams.ShortName;
            }

            if (updateParams.Model != null)
            {
                _this.Model = updateParams.Model;
            }

            if (updateParams.Description != null)
            {
                _this.Description = updateParams.Description;
            }

            if (updateParams.Size != null)
            {
                _this.Size = updateParams.Size;
            }

            if (updateParams.Sku != null)
            {
                _this.Sku = updateParams.Sku;
            }

            if (updateParams.Color != null)
            {
                _this.Color = updateParams.Color;
            }

            if (updateParams.AvgCost != null)
            {
                _this.AvgCost = updateParams.AvgCost;
            }

            if (updateParams.CostValue != null)
            {
                _this.CostValue = updateParams.CostValue;
            }

            if (updateParams.MinSaleValue != null)
            {
                _this.MinSaleValue = updateParams.MinSaleValue;
            }

            if (updateParams.SaleValue != null)
            {
                _this.SaleValue = updateParams.SaleValue;
            }

            if (updateParams.Height != null)
            {
                _this.Height = updateParams.Height;
            }

            if (updateParams.Width != null)
            {
                _this.Width = updateParams.Width;
            }

            if (updateParams.Weight != null)
            {
                _this.Weight = updateParams.Weight;
            }

            if (updateParams.Length != null)
            {
                _this.Length = updateParams.Length;
            }

            if (updateParams.Images != null)
            {
                _this.Images = updateParams.Images;
            }

            if (updateParams.ManufacturerCode != null)
            {
                _this.ManufacturerCode = updateParams.ManufacturerCode;
            }

            if (updateParams.ManufacturerName != null)
            {
                _this.ManufacturerName = updateParams.ManufacturerName;
            }

            if (updateParams.BarCodes != null)
            {
                _this.BarCodes = updateParams.BarCodes;
            }

            if (updateParams.BrandCode != null)
            {
                _this.BrandCode = updateParams.BrandCode;
            }

            if (updateParams.BrandName != null)
            {
                _this.BrandName = updateParams.BrandName;
            }

            if (updateParams.GroupCode != null)
            {
                _this.GroupCode = updateParams.GroupCode;
            }

            if (updateParams.GroupName != null)
            {
                _this.GroupName = updateParams.GroupName;
            }

            if (updateParams.SubgroupCode != null)
            {
                _this.SubgroupCode = updateParams.SubgroupCode;
            }

            if (updateParams.SubgroupName != null)
            {
                _this.SubgroupName = updateParams.SubgroupName;
            }

            if (updateParams.UnitMeasurementCode != null)
            {
                _this.UnitMeasurementCode = updateParams.UnitMeasurementCode;
            }

            if (updateParams.UnitMeasurementName != null)
            {
                _this.UnitMeasurementName = updateParams.UnitMeasurementName;
            }

            if (updateParams.StatusCode != null)
            {
                _this.StatusCode = updateParams.StatusCode;
            }

            if (updateParams.StatusName != null)
            {
                _this.StatusName = updateParams.StatusName;
            }

            if (updateParams.StatusDate != null)
            {
                _this.StatusDate = updateParams.StatusDate;
            }

            if (updateParams.StatusColor != null)
            {
                _this.StatusColor = updateParams.StatusColor;
            }

            if (updateParams.StatusNote != null)
            {
                _this.StatusNote = updateParams.StatusNote;
            }

            if (updateParams.MinStock != null)
            {
                _this.MinStock = updateParams.MinStock;
            }

            if (updateParams.MaxStock != null)
            {
                _this.MaxStock = updateParams.MaxStock;
            }

            if (updateParams.Quantity != null)
            {
                _this.Quantity = updateParams.Quantity;
            }

            if (updateParams.Note != null)
            {
                _this.Note = updateParams.Note;
            }

            return _this;
        }
    }
}
