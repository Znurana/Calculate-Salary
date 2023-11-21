using System;
using Task_1.Enum;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // NET + Tax = Gross Umumi emek haqqi
            //xalis= groos -tax
            int childsupport = 0;
            int familysupport = 0;
            int childrenCount = 0;
            float totalSalary = 0;  //totalsalary=benefit+child+familsupport
            float netSalary = 0;
            float taxValue = 0;
            float ratio = 1; // 1 emsal


            Console.WriteLine("Enter your Gross Salary: (use the number to write)");
            int grossSalary = Convert.ToInt32(Console.ReadLine());
            totalSalary = totalSalary + grossSalary;
            Console.WriteLine("Enter your Martial Status:(Married/Single/Divorced)");
            string martialStatus = Console.ReadLine();
            Console.WriteLine("Enter your disabled status:(Yes/No)");
            string disabled = Console.ReadLine();


            if (martialStatus.ToLower() != MartialStatus.Single.ToString().ToLower())
            {

                Console.WriteLine("How many kids do you have ? (use the number to write)");
                childrenCount = Convert.ToInt32(Console.ReadLine());
                if (martialStatus.ToLower() == MartialStatus.Married.ToString().ToLower())
                {
                    familysupport = 50;
                    totalSalary = totalSalary + familysupport;
                }
                switch (childrenCount)
                {

                    case 1:
                        childsupport = 30;
                        break;

                    case 2:
                        childsupport = 55; //30+25
                        break;

                    case 3:
                        childsupport = 75;
                        break;

                    default:
                        childsupport = 75 + (childrenCount - 3) * 15;
                        break;
                }
                totalSalary = totalSalary + childsupport;
            }


            Console.WriteLine("***********************************************");

            if (disabled.ToLower() == DisabledStatus.No.ToString().ToLower())
            {
                if (totalSalary <= 1000)
                {
                    taxValue = totalSalary * (15 * ratio) / 100;
                    netSalary = totalSalary - taxValue;
                }
                else if (grossSalary > 1000 && grossSalary <= 2000)
                {
                    Console.WriteLine("Tax percentage: 20 %");
                    taxValue = totalSalary * (20 * ratio) / 100;
                    netSalary = totalSalary - taxValue;

                }
                else if (grossSalary > 2000 && grossSalary < 3000)
                {
                    Console.WriteLine("Tax percentage: 25 %");
                    taxValue = totalSalary * (25 * ratio) / 100;
                    netSalary = totalSalary - taxValue;
                }
                else if (grossSalary >= 3000)
                {
                    Console.WriteLine("Tax percentage: 30 %");
                    taxValue = totalSalary * (30 * ratio) / 100;
                    netSalary = totalSalary - taxValue;

                }


            }
            else
            {

                ratio = ratio * 0.5f;
                if (totalSalary <= 1000)
                {
                    taxValue = totalSalary * (15 * ratio) / 100;
                    netSalary = totalSalary - taxValue;
                }
                else if (grossSalary > 1000 && grossSalary <= 2000)
                {
                    Console.WriteLine("Tax percentage: 10 %");
                    taxValue = totalSalary * (20 * ratio) / 100;
                    netSalary = totalSalary - taxValue;

                }
                else if (grossSalary > 2000 && grossSalary < 3000)
                {
                    Console.WriteLine("Tax percentage: 22.5 %");
                    taxValue = totalSalary * (25 * ratio) / 100;
                    netSalary = totalSalary - taxValue;
                }
                else if (grossSalary >= 3000)
                {
                    Console.WriteLine("Tax percentage: 15 %");
                    taxValue = totalSalary * (30 * ratio) / 100;
                    netSalary = totalSalary - taxValue;

                }
            }


            Console.WriteLine("Gross salary: " + Math.Round(totalSalary, 2));
            Console.WriteLine("Net salary :" + Math.Round(netSalary));
            Console.WriteLine("Tax fee :" + Math.Round(taxValue, 2));


            int[] availableMoney = { 200, 100, 50, 20, 10, 1 };

            foreach (int i in availableMoney)
            {
                int count = Convert.ToInt32(netSalary) / i;

                if (count > 0)
                {
                    Console.WriteLine($"{count} x {i}");
                    netSalary %= i;
                }





            }
        }
    }
}