using BillingApp.BillingApp.Program;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp
{
    public class BillRow : Item
    {
        public int number { get; set; }        
        public float totalPrice { get; set; }
        public float Tax { get; set; }
        public bool IsImported { get; set; }

        public BillRow(string n, string tPrice, string iName)
        {
            base.Name = iName;
            this.Tax = 0;
            try
            {
                number = Convert.ToInt16(n);                
                totalPrice = (float)Convert.ToDecimal(tPrice);
                base.unitPrice = totalPrice / number;
            }
            catch (Exception e)
            {
                Console.WriteLine("[Error]: {0}", e.Message);
            }

        }
    }
}
