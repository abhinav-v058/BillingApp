using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    interface IOutput
    {
        IBill Bill { get; set; }
        void PrintBill();
    }
}
