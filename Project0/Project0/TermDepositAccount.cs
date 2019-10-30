using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class TermDepositAccount : Account
    {
        

        public DateTime maturity { get; set; }

        public TermDepositAccount(int ownerId, double amount, DateTime maturity)
        {
            this.ownerId = ownerId;
            this.amount = amount;
            this.maturity = maturity;
        }

        public override void Withdraw(double amount)
        {
            this.amount = this.amount - amount;
        }
        public override void DisplayAccount()
        {
            Console.WriteLine(this.id + " " + this.GetType().Name + " " + this.amount + " " + this.maturity.Year +"/" + 
                this.maturity.Month + "/" + this.maturity.Day);
        }

    }
}
