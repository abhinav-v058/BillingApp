
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    public class Item
    {
        public string Name { get; set; }
        public float unitPrice { get; set; }
        public ItemTypeEnum Type { get; set; }
    }
}
