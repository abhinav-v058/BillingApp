using BillingApp.BillingApp.Program;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp
{
    public class Bill : IBill
    {
        protected IList<ITax> BillTaxes { get; set; }
        public string InputType { get; set; }
        public double RunningTotal { get; private set; }
        public double SalesTax { get; private set; }
        public IList<BillRow> OutputRows { get; set; }
        IList<BillRow> IBill.BillData { get; set; }


        public Bill()
        {
            this.RunningTotal = 0;
            OutputRows = new List<BillRow>();
        }

        IOutput IBill.Generate(IList<string> cashierInput)
        {
            foreach (string inputRow in cashierInput)
            {
                BillRow rowItem = InputFactory.GetInputInterpreter(InputType).Interpreter(inputRow);
                this.CalculateTax(rowItem);
                this.RunningTotal += rowItem.totalPrice + rowItem.Tax;
                this.OutputRows.Add(rowItem);
            }

            return new Output(this.OutputRows);
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
