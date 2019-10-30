using System;
using System.Collections.Generic;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            int customerIdCount = 0;
            String input;
            String userId;
            String pin;
            bool exit = false;
            int result;

            while (!exit)
            {
                Console.WriteLine("Welcome to Bank of nowhere. Please select an option. Login (1), Create an Acount(2), or Exit(3) ");
                input = Console.ReadLine();

                if(!int.TryParse(input, out result))
                {
                    Console.WriteLine("Input was not a number.");
                }
                else
                {
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine("Please enter your user ID.");
                            userId = Console.ReadLine();

                            Console.WriteLine("Please enter your pin number.");
                            pin = Console.ReadLine();

                            if(!CheckCredentials(userId, pin, customers))
                            {
                                Console.WriteLine("Invalid userId or password. Please make sure all feilds are correct and try again or register.");
                            }
                            else
                            {
                                // toDo in proj1
                            }
                            break;
                        case 2:
                            Customer newCust;
                            String fName = "";
                            String lName = "";
                            String acountPin = "";
                            int numPin = -1;
                            bool validPin = false;

                            Console.WriteLine("Please enter your first name.");
                            fName = Console.ReadLine();

                            Console.WriteLine("please enter your last name.");
                            lName = Console.ReadLine();

                            while (!validPin)
                            {
                                Console.WriteLine("Please pick a 4 digit numeric pin for your acount");
                                acountPin = Console.ReadLine();

                                if (!int.TryParse(acountPin, out numPin))
                                {
                                    Console.WriteLine("Input was not a number.");
                                }
                                else
                                {
                                    validPin = true;
                                }
                            }

                            customerIdCount++;

                            newCust = new Customer(customerIdCount, fName, lName, numPin);

                            DateTime stageDate = new DateTime(2019, 1, 1);

                            TermDepositAccount stagedTDAcount = new TermDepositAccount(newCust.id, 200, stageDate);

                            newCust.AddAcount(stagedTDAcount);

                            customers.Add(newCust);

                            CustomerHandler(newCust);

                            break;
                        case 3:
                            Console.WriteLine("Thank you for choosing bank of nowhere. Goodbye. ");
                            exit = true;
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }
        }

        private static void LoginUI()
        {
            //toDo in proj1
        }

        private static bool CheckCredentials(string id, string pin, List<Customer> customers)
        {
            bool found = false;

            for(int i = 0; i < customers.Count; i++)
            {
                if(customers[i].id == int.Parse(id) && customers[i].pin == int.Parse(pin))
                {
                    found = true;
                }
            }
            return found;
        }

        private static void CustomerHandler(Customer c )
        {
            bool logOut = false;
            String input = "";
            int selection;

            while (!logOut)
            {
                Console.WriteLine(" "); 
                Console.WriteLine("Hello " + c.fName + ".");
                Console.WriteLine("Please select an option.");
                Console.WriteLine("Create a new acount (1)");
                Console.WriteLine("Close an existing acount (2)");
                Console.WriteLine("Withdraw from an acount (3)");
                Console.WriteLine("Deposit into an acount (4)");
                Console.WriteLine("Transfer money between acounts (5)");
                Console.WriteLine("Pay on a loan (6)");
                Console.WriteLine("View all acounts (7)");
                Console.WriteLine("View transactions across all acounts (8)");
                Console.WriteLine("Log out (9)");

                input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    Console.WriteLine("Input was not a number.");
                }
                else
                {
                    switch (selection)
                    {
                        case 1:
                            {
                                bool correctInput = false;
                                double amount = 0;

                                while (!correctInput)
                                {
                                    Console.WriteLine("What type of account would you like to create?");
                                    Console.WriteLine("Checking account (1)");
                                    Console.WriteLine("Business account (2)");
                                    Console.WriteLine("Loan account (3)");
                                    Console.WriteLine("Term deposit account (4)");
                                    Console.WriteLine("Cancle (5)");

                                    input = Console.ReadLine();

                                    if (!int.TryParse(input, out selection))
                                    {
                                        Console.WriteLine("Input was not a number.");
                                    }
                                    else
                                    {
                                        correctInput = true;

                                        switch (selection)
                                        {
                                            case 1:
                                                {
                                                    bool validAmount = false;

                                                    while (!validAmount)
                                                    {
                                                        Console.WriteLine("How much would you like to deposit in your new account?");
                                                        input = Console.ReadLine();

                                                        if (!double.TryParse(input, out amount))
                                                        {
                                                            Console.WriteLine("Input was not a number.");
                                                        }
                                                        else if (amount <= 0)
                                                        {
                                                            Console.WriteLine("Amount must be grater than zero");
                                                        }
                                                        else
                                                        {
                                                            validAmount = true;
                                                            CheckingAccount tempCA = new CheckingAccount(c.id, amount);
                                                            c.AddAcount(tempCA);
                                                            Transaction tempTrans = new Transaction("Create", tempCA.id, amount);
                                                            c.AddTransaction(tempTrans);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    bool validAmount = false;

                                                    while (!validAmount)
                                                    {
                                                        Console.WriteLine("How much would you like to deposit in your new account?");
                                                        input = Console.ReadLine();

                                                        if (!double.TryParse(input, out amount))
                                                        {
                                                            Console.WriteLine("Input was not a number.");
                                                        }
                                                        else if (amount <= 0)
                                                        {
                                                            Console.WriteLine("Amount must be grater than zero");
                                                        }
                                                        else
                                                        {
                                                            validAmount = true;
                                                            BusinessAccount tempCA = new BusinessAccount(c.id, amount);
                                                            c.AddAcount(tempCA);
                                                            Transaction tempTrans = new Transaction("Create", tempCA.id, amount);
                                                            c.AddTransaction(tempTrans);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 3:
                                                {
                                                    bool validAmount = false;

                                                    while (!validAmount)
                                                    {
                                                        Console.WriteLine("How much would you like to borrow for your loan?");
                                                        input = Console.ReadLine();

                                                        if (!double.TryParse(input, out amount))
                                                        {
                                                            Console.WriteLine("Input was not a number.");
                                                        }
                                                        else if (amount <= 0)
                                                        {
                                                            Console.WriteLine("Amount must be grater than zero");
                                                        }
                                                        else
                                                        {
                                                            validAmount = true;
                                                            LoanAccount tempCA = new LoanAccount(c.id, amount);
                                                            c.AddAcount(tempCA);
                                                            Transaction tempTrans = new Transaction("Create", tempCA.id, amount);
                                                            c.AddTransaction(tempTrans);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 4:
                                                {
                                                    bool validAmount = false;

                                                    while (!validAmount)
                                                    {
                                                        Console.WriteLine("How much would you like to deposit in your new account?");
                                                        input = Console.ReadLine();

                                                        if (!double.TryParse(input, out amount))
                                                        {
                                                            Console.WriteLine("Input was not a number.");
                                                        }
                                                        else if (amount <= 0)
                                                        {
                                                            Console.WriteLine("Amount must be grater than zero");
                                                        }
                                                        else
                                                        {
                                                            

                                                            Console.WriteLine("Please select a (1) 0r (5) year account.");
                                                            input = Console.ReadLine();

                                                            int year;

                                                            if (!int.TryParse(input, out year))
                                                            {
                                                                Console.WriteLine("Input was not a number.");
                                                            }
                                                            else if (year == 1 || year == 5)
                                                            {
                                                                validAmount = true;
                                                                DateTime tempDate;
                                                                DateTime today = DateTime.Today;

                                                                if (year == 1)
                                                                {
                                                                    tempDate = new DateTime((today.Year + 1), today.Month, today.Day);
                                                                }
                                                                else
                                                                {
                                                                    tempDate = new DateTime((today.Year + 5), today.Month, today.Day);
                                                                }

                                                                TermDepositAccount tempCA = new TermDepositAccount(c.id, amount, tempDate);
                                                                c.AddAcount(tempCA);
                                                                Transaction tempTrans = new Transaction("Create", tempCA.id, amount);
                                                                c.AddTransaction(tempTrans);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("input was not a valid option");
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                            case 5:
                                                {
                                                    Console.WriteLine("Acount creation cancled");
                                                }
                                                
                                                break;
                                        }
                                    }
                                }
                               
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Please enter the id of the acount you would like to  close.");
                                input = Console.ReadLine();

                                if (!int.TryParse(input, out selection))
                                {
                                    Console.WriteLine("Input was not a number.");
                                }
                                else
                                {
                                    var tempAcount = c.GetAccount(selection);

                                    if (tempAcount != null)
                                    {
                                        if(tempAcount is LoanAccount)
                                        {
                                            Console.WriteLine("Loan accounts will be closed aoutomaticly when they are paid off and can not be closed manually");
                                        }
                                        else if (tempAcount is TermDepositAccount)
                                        {
                                            TermDepositAccount tempTD = (TermDepositAccount) tempAcount;

                                            if(tempTD.maturity < DateTime.Today)
                                            {
                                                c.CloseAcount(selection);
                                                Console.WriteLine("THe account has been closed and a check of " + tempTD.amount + " has ben issued to you.");
                                                Transaction tempTrans = new Transaction("Close", tempTD.id, tempTD.amount);
                                                c.AddTransaction(tempTrans);
                                            }
                                            else
                                            {
                                                Console.WriteLine("A term deposit acount can not be closed untill after the mature date");
                                            }
                                        }
                                        else
                                        {
                                            c.CloseAcount(selection);
                                            Console.WriteLine("The Acount has been closed and a check of " + tempAcount.amount + " has ben issued to you.");
                                            Transaction tempTrans = new Transaction("Close", tempAcount.id, tempAcount.amount);
                                            c.AddTransaction(tempTrans);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Acount was not found please check the id and try again.");
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                double amount;
                                Console.WriteLine("Please enter the id of the acount you would like to withdraw from.");
                                input = Console.ReadLine();

                                if (!int.TryParse(input, out selection))
                                {
                                    Console.WriteLine("Input was not a number.");
                                }
                                else
                                {
                                    var tempAcount = c.GetAccount(selection);

                                    if (tempAcount != null)
                                    {

                                        if (tempAcount is LoanAccount)
                                        {
                                            Console.WriteLine("Money cannot be withdrawn from a Loan account.");
                                        }
                                        else if (tempAcount is TermDepositAccount)
                                        {
                                            TermDepositAccount tempTD = (TermDepositAccount)tempAcount;

                                            if (tempTD.maturity < DateTime.Today)
                                            {
                                                Console.WriteLine("Please enter the amount you would like to withdraw.");
                                                input = Console.ReadLine();

                                                if (!double.TryParse(input, out amount))
                                                {
                                                    Console.WriteLine("Input was not a number.");
                                                }
                                                else if (amount > 0)
                                                {
                                                    if (tempAcount is CheckingAccount && tempAcount.amount < amount)
                                                    {
                                                        Console.WriteLine("Could not withdraw " + amount + " from checking acount becase the balance is too low.");
                                                    }
                                                    else
                                                    {
                                                        c.Withdraw(selection, amount);
                                                        Transaction tempTrans = new Transaction("Withdraw", tempTD.id, amount);
                                                        c.AddTransaction(tempTrans);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Money can not be withdrawn from  a term deposit account untill the maturity date.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter the amount you would like to withdraw.");
                                            input = Console.ReadLine();

                                            if (!double.TryParse(input, out amount))
                                            {
                                                Console.WriteLine("Input was not a number.");
                                            }
                                            else if (amount > 0)
                                            {
                                                if(tempAcount is CheckingAccount && tempAcount.amount <amount)
                                                {
                                                    Console.WriteLine("Could not withdraw " + amount + " from checking acount becase the balance is too low.");
                                                }
                                                else
                                                {
                                                    c.Withdraw(selection, amount);
                                                    Transaction tempTrans = new Transaction("Withdraw", tempAcount.id, amount);
                                                    c.AddTransaction(tempTrans);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Input must be grater than zero");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Acount was not found please check the id and try again.");
                                    }
                                }

                                break;
                            }
                        case 4:
                            {
                                double amount;

                                Console.WriteLine("Pleaseenter the id of the account you would like to deposit into.");
                                input = Console.ReadLine();

                                if (!int.TryParse(input, out selection))
                                {
                                    Console.WriteLine("Input was not a number.");
                                }
                                else
                                {
                                    var tempAcount = c.GetAccount(selection);

                                    if(tempAcount != null)
                                    {
                                        if(tempAcount is LoanAccount)
                                        {
                                            Console.WriteLine("Money can not be deposited into a loan account. if you want t o pay on a loan select pay loan instalment.");
                                        }
                                        else if(tempAcount is TermDepositAccount)
                                        {
                                            Console.WriteLine("Money can not be added to a term deposit account.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Plese enter the amount you would like to deposit.");
                                            input = Console.ReadLine();

                                            if (!double.TryParse(input, out amount))
                                            {
                                                Console.WriteLine("Input was not a number.");
                                            }
                                            else if (amount > 0)
                                            {
                                                c.Deposit(selection, amount);
                                                Transaction tempTrans = new Transaction("Deposit", tempAcount.id, amount);
                                                c.AddTransaction(tempTrans);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Input must be grater than zero");
                                            }

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Acount was not found please check the id and try again.");
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                double amount;
                                int withdrawAccountId;
                                int depositAccountId;

                                Console.WriteLine("Enter the id of the acount you would like to withdraw money from.");
                                input = Console.ReadLine();

                                if(!int.TryParse(input, out selection))
                                {
                                    Console.WriteLine("Input was not a number");
                                }
                                else
                                {
                                    var tempAcount = c.GetAccount(selection);

                                    if(tempAcount != null)
                                    {
                                        if(tempAcount is LoanAccount)
                                        {
                                            Console.WriteLine("Money can not be withdrawn from a loan account.");
                                            break;
                                        }
                                        
                                        else
                                        {
                                            if (tempAcount is TermDepositAccount)
                                            {
                                                TermDepositAccount tempTD = (TermDepositAccount)tempAcount;

                                                if (tempTD.maturity < DateTime.Today)
                                                {
                                                    withdrawAccountId = selection;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Money can not be withdrawn from a term deposit acount before the maturity date.");
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                withdrawAccountId = selection;
                                            }

                                            Console.WriteLine("Enter the id of the account you would like to deposit to");
                                            input = Console.ReadLine();

                                            if (!int.TryParse(input, out selection))
                                            {
                                                Console.WriteLine("Input was not a number");
                                            }
                                            else
                                            {
                                                tempAcount = c.GetAccount(selection);

                                                if (tempAcount != null)
                                                {
                                                    if (tempAcount is LoanAccount)
                                                    {
                                                        Console.WriteLine("Money can not be deposited to a loan account.");
                                                    }
                                                    else if (tempAcount is TermDepositAccount)
                                                    {
                                                        Console.WriteLine("Money can not be  deposited to a term deposit account.");
                                                    }
                                                    else
                                                    {
                                                        depositAccountId = selection;

                                                        Console.WriteLine("Enter the amount you would like totransfer.");
                                                        input = Console.ReadLine();

                                                        if(!double.TryParse(input, out amount))
                                                        {
                                                            Console.WriteLine("Input was not a number");
                                                        }
                                                        else if(amount <= 0)
                                                        {
                                                            Console.WriteLine("Amount must be grater than zero");
                                                        }
                                                        else
                                                        {
                                                            c.TransferFunds(withdrawAccountId, depositAccountId, amount);
                                                            Transaction tempTrans = new Transaction("Transfer", withdrawAccountId, depositAccountId, amount);
                                                            c.AddTransaction(tempTrans);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Acount was not found please check the id and try again");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Acount was not found please check the id and try again");
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                double amount;

                                Console.WriteLine("Ender the id of a loan account.");
                                input = Console.ReadLine();

                                if (!int.TryParse(input, out selection))
                                {
                                    Console.WriteLine("Input was not a number.");
                                }
                                else
                                {
                                    var tempAcount = c.GetAccount(selection);

                                    if (tempAcount != null)
                                    {
                                        if(tempAcount is LoanAccount)
                                        {
                                            LoanAccount lc = (LoanAccount)tempAcount;

                                            Console.WriteLine("Enter a payment amout of the minimum " + lc.monthlyDue + " or more.");
                                            input = Console.ReadLine();

                                            if (!double.TryParse(input, out amount))
                                            {
                                                Console.WriteLine("Input was not a number.");
                                            }
                                            else if(amount < lc.monthlyDue)
                                            {
                                                Console.WriteLine("Payment must be above the minimum " + lc.monthlyDue + ".");
                                            }
                                            else
                                            {
                                                c.Deposit(selection, amount);
                                                Transaction tempTrans = new Transaction("Loan Payment", tempAcount.id, amount);
                                                c.AddTransaction(tempTrans);
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Given id was not for a loan account");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Acount was not found please check the id and try again.");
                                    }
                                }

                                    break;
                            }
                        case 7:
                            {
                                Console.WriteLine(" ");
                                c.DisplayAcounts();
                                Console.WriteLine(" ");
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine(" ");
                                c.DisplayTransactions();
                                Console.WriteLine(" ");
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("Thank you for using bank of nowhere. Have a nice day");
                                logOut = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Input was not a valid option");
                                break;
                            }
                    }
                }
            }
        }

        private static void GetCustomer(Customer c)
        {

        }
    }
}
