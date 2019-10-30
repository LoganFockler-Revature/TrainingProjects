using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Transaction
    {
        public int id { get; set; }

        public string type { get; set; }

        public double amount { get; set; }

        private List<int> acountIds = new List<int>();

        public Transaction(String type, int id, double amount)
        {
            this.type = type;
            this.amount = amount;
            this.acountIds.Add(id);
        }

        public Transaction(String type, int id1, int id2, double amount)
        {
            this.type = type;
            this.amount = amount;
            this.acountIds.Add(id1);
            this.acountIds.Add(id2);
        }

        public void DisplayTransaction()
        {
            Console.Write(this.id + " " + this.type + " ");

            foreach(int i in acountIds)
            {
                Console.Write(i + " ");
            }

            Console.Write(this.amount + "\n");
        }
}
}
