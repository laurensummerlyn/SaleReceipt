using System;
using System.Collections.Generic;
using System.Text;

namespace SaleReceipt
{
    class Receipt
    {
        public int CustomerID { get; set; }
        public int CogQuantity { get; set; }
        public int GearQuantity { get; set; }
        public DateTime SaleDate { get; set; }
        private double SalesTaxPercent;
        private double CogPrice;
        private double GearPrice;

        public Receipt()
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Today;
            SalesTaxPercent = .089;
            CogPrice = 79.99;
            GearPrice = 250.00;
        }

        public Receipt(int id, int cog, int gear)
        {
            CustomerID = id;
            CogQuantity = cog;
            GearQuantity = gear;
        }

        public double CalculateTotal()
        {
            return CalculateNetAmount() + CalculateTaxAmount();
        }
        public void PrintReceipt()
        {
            double cogTotal = CogPrice * CogQuantity;
            double gearTotal = GearPrice * GearQuantity;

            string rec = "\n\n\t\t\t\tRECEIPT\n" +
                    $"Customer ID   {CustomerID}\n" +
                    $"Item\t\t\t\t\tQuantity\t\t\t\tCost\n\n" +
                    $"Cogs\t\t\t\t\t{CogQuantity}\t\t\t\t{cogTotal.ToString("C2")}\n" +
                    $"Gears\t\t\t\t\t{GearQuantity}\t\t\t\t{gearTotal.ToString("C2")}\n\n" +
                    $"Total cost\t\t\t\t\t\t\t\t{CalculateNetAmount().ToString("C2")}\n" +
                    $"Sales Tax\t\t\t\t\t\t\t\t{CalculateTaxAmount().ToString("C2")}\n" +
                    $"Grand Total\t\t\t\t\t\t\t\t{CalculateTotal().ToString("C2")}";
            Console.WriteLine(rec);
        }
        private double CalculateTaxAmount()
        {
            return ((CogQuantity * CogPrice) + (GearQuantity * GearPrice)) * SalesTaxPercent;
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
