using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06RadChartViewDrillDown.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public double CurrentPrice { get; set; }

        public List<PriceInfo> PricesInfo { get; set; }
    }
}
