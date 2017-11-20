using BillingApp.BillingApp.Program;
using System;
using System.Collections.Generic;

namespace BillingApp
{
    class Process
    {
        static void Main(string[] args)
        {
            List<List<string>> input = new List<List<string>>()
            {
                new List<string>() {
                    "1 book at 12.49 ",
                    "1 book at 12.49 ",
                    "1 music CD at 14.99",
                    "1 chocolate bar at 0.85 "
                },

                new List<string>() {
                    "1 imported box of chocolates at 10.00",
                    "1 imported bottle of perfume at 47.50",
                },

                new List<string>() {
                    "1 imported bottle of perfume at 27.99",
                    "1 bottle of perfume at 18.99",
                    "1 packet of headache pills at 9.75",
                    "1 box of imported chocolates at 11.25",
                    "1 box of imported chocolates at 11.25",
                }
            };

            ITax salesTax = new CodingTestTax();
            salesTax.Percentage = (float)10;
            salesTax.Name = "sales";
            salesTax.ExemptedItemTypes = new HashSet<ItemTypeEnum>();
            salesTax.ExemptedItemTypes.Add(ItemTypeEnum.Book);
            salesTax.ExemptedItemTypes.Add(ItemTypeEnum.Food);
            salesTax.ExemptedItemTypes.Add(ItemTypeEnum.Medical);

            ITax importTax = new CodingTestTax();
            importTax.Percentage = (float)5;
            importTax.Name = "import";

            List<ITax> taxes = new List<ITax>
            {
                salesTax,
                importTax
            };

            IBill bill = new BillingApp.Bill("DealerOnTestFormat", taxes);

            foreach (List<string> b in input)
            {
                var o = bill.Generate(b);
                o.PrintBill();
            }


            Console.ReadLine();
        }
    }
}
