using System;
using System.Globalization;
using ExcInterface.Entities;
using ExcInterface.Services;

namespace ExcInterface;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter contract data");
        Console.Write("Number of account: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Date (dd/MM/yyyy): ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        Console.Write("Contract value: ");
        double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter number of installments: ");
        int months = int.Parse(Console.ReadLine());

        Contract contract = new Contract(number, date, contractValue);

        ProcessContractService processContractService = new ProcessContractService (new PaypalService());

        processContractService.ProcessContract(contract, months);

        Console.WriteLine();
        Console.WriteLine("Installments:");
        foreach (Installment installment in contract.Installments)
        {
            Console.WriteLine(installment);
        }
    }
}