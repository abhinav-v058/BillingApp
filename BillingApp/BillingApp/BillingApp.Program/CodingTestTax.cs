using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    public class CodingTestTax:ITax
    {
        float ITax.Percentage { get; set; }        
        string ITax.Name { get; set; }        
        HashSet<ItemTypeEnum> ITax.ExemptedItemTypes { get; set; }        
    }
}
