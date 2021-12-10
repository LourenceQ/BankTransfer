using System;
using System.Collections.Generic;
using BankTransfer.BankAccount;
using BankTransfer.Enum;

namespace BankTransfer
{
    class Program
    {
        static List<Account> AccountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOptions = GetUserOp();

            while (userOptions.ToUpper() != "X")
            {
                switch (userOptions)
                {
                    case "1":
                        AccountLists();
                        break;
                    case "2":
                        AccountCreate();
                        break;
                    case "3":
                        AccountTransfer();
                        break;
                    case "4":
                        AccountWithDraw();
                        break;
                    case "5":
                        AccountDeposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOptions = GetUserOp();
            } 
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static string GetUserOp()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Bem vindo ao Banco da União");
            System.Console.WriteLine("Informe a operaçao desejada:");

            System.Console.WriteLine("1- Listar Contas");
            System.Console.WriteLine("2- Criar conta");
            System.Console.WriteLine("3- Transferência");
            System.Console.WriteLine("4- Sacar");
            System.Console.WriteLine("5- Depositar");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string userOp = Console.ReadLine().ToUpper();
            System.Console.WriteLine();

            return userOp;
        }

        private static void Clear()
        {
            throw new NotImplementedException();
        }

        private static void AccountDeposit()
        {
            throw new NotImplementedException();
        }

        private static void AccountWithDraw()
        {
            throw new NotImplementedException();
        }

        private static void AccountTransfer()
        {
            throw new NotImplementedException();
        }

        private static void AccountLists()
        {
            throw new NotImplementedException();
        }

        private static void AccountCreate()
        {
            System.Console.WriteLine("Cirar nova conta");

            System.Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int accountTypeCreate = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o nome do Cliente: ");
            string accountUserName = Console.ReadLine();

            System.Console.Write("Digite o saldo inicial: ");
            decimal accountBalance = decimal.Parse(Console.ReadLine());

            System.Console.Write("Digite o crédito: ");
            decimal accountDeposit = decimal.Parse(Console.ReadLine());

          
            Account newAccount = new Account(accountType: (AccountType)accountTypeCreate,
                                             name: accountUserName,
                                             balance: accountBalance,
                                             credit: accountDeposit);
            AccountList.Add(newAccount);

        }

        
    }
}
