﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPart
{
    public class GetListPartQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartCode { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string PartBrandName { get; set; }
        public string PartModelName { get; set; }
        public int PartModelYear { get; set; }
        public string CategoryName { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public float Vat { get; set; }
        public float VatPaid { get; set; }
        public int Stock { get; set; }
        public float Profit { get; set; }
    }
}
