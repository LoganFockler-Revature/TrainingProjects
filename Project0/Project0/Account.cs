using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Account
    {

        public int id { get; set; }
        public int ownerId { get; set; }
        public double amount { get; set; }

        public virtual void Deposit(double amount) 
        {
            Console.WriteLine("Implement me");
        }

        public virtual void Withdraw(double amount) 
        {
            Console.WriteLine("Implement me");
        }

        public virtual void DisplayAccount()
        {
            Console.WriteLine("Implement me");
        }
    }
}
