using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class BusinessAccount : Account 
    {
        static readonly double interestRate = .20;
        public double overdraft { get; set; }
        public double overdraftCost { get; set; }
        public double overdraftDueDate { get; set; }

        public BusinessAccount(int ownerId, double amount)
        {
            this.ownerId = ownerId;
            this.amount = amount;
            this.overdraft = 0;
        }

        public override void Deposit(double amount)
        {
            this.amount = this.amount + amount;
        }

        public override void Withdraw(double amount) 
        {
            this.amount = this.amount - amount;

            if(this.amount < 0)
            {
                var temp = this.amount;
                this.overdraft = Math.Abs(temp);
                this.amount = 0;
            }
        }

        public override void DisplayAccount()
        {
            Console.WriteLine(this.id + " " + this.GetType().Name + " " + this.amount);
        }
    }
}
