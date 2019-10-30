using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Customer
    {
        public int id { get; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int pin { get; set; }
        private List<Account> accounts = new List<Account>();
        private List<Transaction> transactions = new List<Transaction>();
        private int idCount = 0;
        private int transactionCount = 0;

        public Customer(int id, String fName, String lName, int pin)
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.pin = pin;
        }

        public void AddAcount(Account a)
        {
            idCount++;
            a.id = idCount;
            accounts.Add(a);
        }

        public void AddTransaction(Transaction t)
        {
            transactionCount++;
            t.id = transactionCount;
            transactions.Add(t);
        }

        public void CloseAcount(int id)
        {
            for(int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id.Equals(id))
                {
                    accounts.RemoveAt(i);
                }
            }
        }

        public void Withdraw(int id, double amount )
        {
            Account temp = GetAccount(id);
            temp.Withdraw(amount);
        }
        public void Deposit(int id, double amount )
        {
            Account temp = GetAccount(id);
            temp.Deposit(amount);
        }
        //transfer amount from the acount with id1 to the acount with id2
        public void TransferFunds(int id1, int id2, double amount)
        {
            Account withdraw = GetAccount(id1);
            Account deposit = GetAccount(id2);

            withdraw.Withdraw(amount);
            deposit.Deposit(amount);
        }
        public void DisplayAcounts()
        {
            foreach(Account a in accounts)
            {
                a.DisplayAccount();
            }
        }
        public void DisplayTransactions()
        {
            foreach(Transaction t in transactions)
            {
                t.DisplayTransaction();
            }
        }

        public Account GetAccount(int id)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id.Equals(id))
                {
                    return accounts[i];
                }
            }

            return null;
        }
    }
}
