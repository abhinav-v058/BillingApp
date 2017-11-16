using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    public class Tax
    {
        public float Percentage { get; set; }
        public string Name { get; set; }
        public HashSet<ItemTypeEnum> ExemptedItemTypes { get; set; }
    }
}
