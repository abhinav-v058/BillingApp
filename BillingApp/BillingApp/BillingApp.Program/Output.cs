using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    class Output:IOutput
    {
        public IBill Bill { get; set; }
        public IList<BillRow> BillData { get; set; }
        public Dictionary<string, float> outputData;

        public Output(IBill bill)
        {
            this.BillData = bill.BillData;
            this.Bill = bill;
            this.outputData = new Dictionary<string, float>();
        }

        public void PrintBill()
        {
            Bill bill = (Bill)this.Bill;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Output:");
            Console.WriteLine("-------------------------------");
            var something = this.BillData.GroupBy(x => x.Name);
            foreach (BillRow row in this.BillData)
            {                
                this.PrintBillRow(row);
            }

            double salesTax = Math.Round(bill.SalesTax * 20) / 20;
            double total = Math.Round(bill.RunningTotal,2);

            Console.WriteLine("Sales Taxes: {0}", salesTax);
            Console.WriteLine("Total: {0}", total);
            Console.WriteLine("-------------------------------");

        }

        private void PrintBillRow(BillRow row)
        {
            string itemName = row.Name;
            double totalPrice = Math.Round((row.totalPrice+row.Tax),2);
            itemName = this.InitCap(itemName);
            if (row.number > 1)
            {
                Console.WriteLine("{0}: {1} ({2} @ {3})", itemName,totalPrice.ToString(),row.number,row.unitPrice);
            }
            else
                Console.WriteLine("{0}: {1}", itemName, totalPrice.ToString());

        }

        private string InitCap(string str)
        {
            if (str.Length > 0)
            {
                str = str.First().ToString().ToUpper() + str.Substring(1);
            }

            return str;
        }        
    }
}
