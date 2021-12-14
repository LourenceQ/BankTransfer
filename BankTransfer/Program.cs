using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankTransfer.BankAccount;
using BankTransfer.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace BankTransfer
{
    class Program
    {
        // public async Task<string> GetExchangeRate(string from, string to)
        // {
        //     //Examples:
        //     //from = "EUR"
        //     //to = "USD"
        //     using (var client = new System.Net.Http.HttpClient())
        //     {
        //         try
        //         {
        //             client.BaseAddress = new Uri("https://free.currencyconverterapi.com");
        //             var response = await client.GetAsync($"/api/v6/convert?q={from}_{to}&compact=y");
        //             var stringResult = await response.Content.ReadAsStringAsync();
        //             dynamic data = Object.Parse(stringResult);
        //             //data = {"EUR_USD":{"val":1.140661}}
        //             //I want to return 1.140661
        //             //EUR_USD is dynamic depending on what from/to is
        //             return data.?????.val;
        //         }
        //         catch (System.Net.Http.HttpRequestException httpRequestException)
        //         {
        //             Console.WriteLine(httpRequestException.StackTrace);
        //             return "Error calling API. Please do manual lookup.";
        //         }
        //     }
        // }
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://api.currencyfreaks.com/supported-currencies");
            
            responseTask.Wait();

            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var message = result.Content.ReadAsStringAsync();
                    responseTask.Wait();

                    System.Console.WriteLine("Menssagem da webapi : " + responseTask.Result);
                }
            }



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

        private static void AccountDeposit()
        {
            System.Console.WriteLine("Informe o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("informe o valor para depósito: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());

            accountList[accountIndex].Deposit(depositAmount);
        }

        private static void AccountWithDraw()
        {
            System.Console.WriteLine("Informe o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Iniforme o valor para saque: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());

            accountList[accountIndex].WithDraw(depositAmount);
        }

        private static void AccountTransfer()
        {
            System.Console.WriteLine();
            int accountIndexOrigin = int.Parse(Console.ReadLine());

            System.Console.WriteLine();
            int accountIndexDestination = int.Parse(Console.ReadLine());

            System.Console.Write("Informe o valor a ser transferido: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());

            accountList[accountIndexOrigin].Transfer(transferAmount, accountList[accountIndexDestination]);
        }

        private static void AccountLists()
        {
            System.Console.WriteLine("Listar contas");

            if (accountList.Count == 0)
            {
                System.Console.WriteLine("Não existem contas cadastrdas.");
                return;
            }

            for (int i = 0; i < accountList.Count; i++)
            {
                Account userAccount = accountList[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(userAccount);
            }
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
            accountList.Add(newAccount);

        }


    }
}
