using BillingApp.BillingApp.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingApp.BillingApp
{
    public class Bill : IBill
    {
        protected IList<ITax> BillTaxes { get; set; }
        public IList<BillRow> BillData { get; set; }
        public string InputType { get; set; }
        public double RunningTotal { get; private set; }
        public double SalesTax { get; private set; }
        public IList<BillRow> OutputRows { get; set; }
        private HashSet<string> Items;

        public Bill(string inputType, IList<ITax> taxes)
        {
            this.InputType = inputType;
            this.BillTaxes = taxes;
            this.RunningTotal = 0;            
            OutputRows = new List<BillRow>();            
            this.Items = new HashSet<string>();
        }

        IOutput IBill.Generate(IList<string> cashierInput)
        {
            this.RunningTotal = 0;
            OutputRows = new List<BillRow>();
            this.Items = new HashSet<string>();

            foreach (string inputRow in cashierInput)
            {
                BillRow rowItem = InputFactory.GetInputInterpreter(InputType).Interpreter(inputRow);
                this.CalculateTax(rowItem);
                this.RunningTotal += rowItem.totalPrice + rowItem.Tax;
                if (!Items.Contains(rowItem.Name))
                {
                    this.OutputRows.Add(rowItem);
                    Items.Add(rowItem.Name);
                }
                else
                {
                    var sItem = this.OutputRows.Where(x => x.Name.Equals(rowItem.Name)).FirstOrDefault();
                    sItem.number += rowItem.number;
                    sItem.Tax += rowItem.Tax;
                    sItem.totalPrice += rowItem.totalPrice;
                }
            }

            this.BillData = this.OutputRows;
            return new Output(this);
        }

        private void CalculateTax(BillRow input)
        {
            float tempSalesT = 0;
            foreach (ITax tax in this.BillTaxes)
            {
                switch (tax.Name.ToLower())
                {
                    case "sales":
                        if (!tax.ExemptedItemTypes.Contains(input.Type))
                        {  
                            tempSalesT = input.totalPrice * (tax.Percentage / 100);
                            input.Tax += tempSalesT;
                            this.SalesTax += tempSalesT;
                        }
                        break;
                    case "import":
                        if(input.IsImported)
                            input.Tax += input.totalPrice * (tax.Percentage / 100);
                        break;
                }                
            }
        }
    }
}
