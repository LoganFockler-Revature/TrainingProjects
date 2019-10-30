using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class CheckingAccount : Account
    {
        public CheckingAccount(int ownerId, double amount)
        {
            this.ownerId = ownerId;
            this.amount = amount;
        }

        public override void Deposit(double amount) 
        {
            this.amount = this.amount + amount;
        }

        public override void Withdraw(double amount) 
        {
            this.amount = this.amount - amount;
        }

        public override void DisplayAccount()
        {
            Console.WriteLine(this.id + " " + this.GetType().Name + " " + this.amount);
        }
    }
}
