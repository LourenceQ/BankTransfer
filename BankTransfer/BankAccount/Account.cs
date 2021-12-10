using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTransfer.Enum;

namespace BankTransfer.BankAccount
{
    public class Account
    {
           // tipo-conta nome saldo credito
        public Account(AccountType accountType, string name, decimal balance, decimal credit)
        {
            
            this.AccountType = accountType;
            this.Name = name;
            this.Balance = balance;
            this.Credit = credit;
        }

        private string Name { get; set; }
        private decimal Balance { get; set; }
        private decimal Credit { get; set; }
        private AccountType AccountType { get; set; }

        public bool WithDraw(decimal withDrawAmount)
        {
            if (this.Balance - withDrawAmount < (this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Balance -= withDrawAmount;
            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(decimal depositAmount)
        {
            this.Balance += depositAmount;

            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
        }

        public void Transfer(decimal transferValue, Account destinationAccount)
        {
            if (this.WithDraw(transferValue))
            {
                destinationAccount.Deposit(transferValue);
            }
        }
        
        public override string ToString()
        {
            string accountToString ="";
            accountToString += "AccountType: " + this.AccountType + " | ";  
            accountToString += "Name: " + this.Name + " | "; 
            accountToString += "Balance: " + this.Balance + " | "; 
            accountToString += "Credit: " + this.Credit + " | "; 

            return accountToString;
        }
    }
}