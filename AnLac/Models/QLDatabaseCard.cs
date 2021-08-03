using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnLac.Models
{
    public class QLDatabaseCard
    {
        DataClassesDoAnDataContext db = new DataClassesDoAnDataContext();

        public int iproductCode { set; get; }

        public string sproductName { set; get; }

        public string sproductImage { set; get; }

        public double dorderDetailsPriceEach { set; get; }

        public int iorderDetailsQuantity { set; get; }

        public double dTotal
        {
            get { return dorderDetailsPriceEach * iorderDetailsQuantity; }
        }

        public QLDatabaseCard(int productCode)
        {
            iproductCode = productCode;
            Product products = db.Products.Single(n => n.productCode == iproductCode);
            sproductName = products.productName;
            sproductImage = products.productImage;
            dorderDetailsPriceEach = double.Parse(products.productBuyPrice.ToString());
            iorderDetailsQuantity = 1;
        }
    }
}