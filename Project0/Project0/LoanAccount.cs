using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class LoanAccount : Account
    {
        public double monthlyDue { get; set; }

        public LoanAccount(int ownerId, double amount)
        {
            this.ownerId = ownerId;
            this.amount = amount;
            this.monthlyDue = CalculateMonthlyDue();
        }

        public override void Deposit(double amount) 
        {
            this.amount = this.amount - amount;
        }

        public override void DisplayAccount()
        {
            Console.WriteLine(this.id + " " + this.GetType().Name + " " + this.amount);
        }

        private double CalculateMonthlyDue()
        {
            Double startAmount = this.amount;
            double due = Math.Truncate(startAmount / 12);

            return due;
        }

    }
}
