using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace _06RadChartViewDrillDown.Models
{
    public class Company : ViewModelBase
    {
        public string CompanyName { get; set; }
        public List<Product> Products { get; set; }
        public double Revenue { get { return this.Products.Sum(p => p.CurrentPrice); } }
    }
}
