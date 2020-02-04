using System;
using System.Collections.Generic;

namespace SaleReceipt
{
    class Program
    {
        int CogQuantity, GearQuantity, CustomerID;
        double CogPrice, GearPrice;
        double SalesTaxPercent = .089;
        static void Main(string[] args)
        {
            var list = new List<int>();
            int customerID, cogQuantity, gearQuantity;
            do
            {
                Console.WriteLine("Please enter Customer ID");
                customerID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the number of cogs for the order");
                cogQuantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the number of gears for the order");
                gearQuantity = Convert.ToInt32(Console.ReadLine());

                Receipt r = new Receipt();
                r.CustomerID = customerID;
                r.CogQuantity = cogQuantity;
                r.GearQuantity = gearQuantity;

                r.PrintReceipt();

                list.Add(customerID);
                list.Add(cogQuantity);
                list.Add(gearQuantity);


                Console.WriteLine("Do you want to enter another order?");
            } while (Console.ReadLine().ToLower() == "yes");

            Console.WriteLine("Would you like to print all receipts based off CustomerID, receipts for the day, or receipt for the highest sale? (enter: CustomerID, day, or sale)");
            string answer = Console.ReadLine();



            Console.ReadKey();
        }
        public double CalculateTotal()
        {
            double total = CalculateNetAmount() + CalculateTaxAmount();
            return total;
        }
        public void PrintReceipt()
        {
            double cogTotal = CogPrice * CogQuantity;
            double gearTotal = GearPrice * GearQuantity;

            string receipt = "\n\n\t\t\t\tRECEIPT\n" +
                    $"Customer ID   {CustomerID}\n" +
                    $"Item\t\t\t\tQuantity\t\tCost\n\n" +
                    $"Cogs\t\t\t\t\t{CogQuantity}\t\t\t\t{cogTotal.ToString("C2")}\n" +
                    $"Gears\t\t\t\t\t{GearQuantity}\t\t\t\t{gearTotal.ToString("C2")}\n\n" +
                    $"Total cost\t\t\t\t\t\t\t\t{CalculateNetAmount().ToString("C2")}\n" +
                    $"Sales Tax\t\t\t\t\t\t\t\t{CalculateTaxAmount().ToString("C2")}\n" +
                    $"Grand Total\t\t\t\t\t\t\t\t{CalculateTotal().ToString("C2")}";
            Console.WriteLine(receipt);
        }
        private double CalculateTaxAmount()
        {
            double taxAmount;
            taxAmount = ((CogQuantity * CogPrice) + (GearQuantity * GearPrice)) * SalesTaxPercent;

            return taxAmount;
        }
        private double CalculateNetAmount()
        {
            if (CogQuantity > 10 || GearQuantity > 10 || CogQuantity + GearQuantity > 16)
            {
                double netAmount = (CogQuantity * (CogPrice * .125)) + (GearQuantity * (GearPrice * .125));
                return netAmount;
            }
            else
            {
                double netAmount = (CogQuantity * (CogPrice * .15)) + (GearQuantity * (GearPrice * .15));
                return netAmount;
            }
        }
    }
}
