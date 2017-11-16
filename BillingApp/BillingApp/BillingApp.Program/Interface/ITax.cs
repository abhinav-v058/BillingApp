using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    public interface ITax
    {
         float Percentage { get; set; }
         string Name { get; set; }
         HashSet<ItemTypeEnum> ExemptedItemTypes { get; set; }
    }
}
