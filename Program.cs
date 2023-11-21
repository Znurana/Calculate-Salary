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
            float ratio = 1;
            float taxPersentage = 0;// 1 emsal

            //1. data recieve

            Console.WriteLine("Enter your Gross Salary: (use the number to write)");
            int grossSalary = Convert.ToInt32(Console.ReadLine());
            totalSalary = totalSalary + grossSalary;
            Console.WriteLine("Enter your Martial Status:(Married/Single/Divorced)");
            string martialStatus = Console.ReadLine();
            Console.WriteLine("Enter your disabled status:(Yes/No)");
            string disabled = Console.ReadLine();

            if (disabled.ToLower() == DisabledStatus.Yes.ToString().ToLower())
            {
                ratio = ratio * 0.5f;
            }


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


            //2. data calculate 
            Console.WriteLine("***********************************************");


            if (totalSalary <= 1000)
            {
                taxPersentage = 15 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;
            }
            else if (grossSalary > 1000 && grossSalary <= 2000)
            {
                taxPersentage = 20 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;

            }
            else if (grossSalary > 2000 && grossSalary < 3000)
            {
                taxPersentage = 25 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;
            }
            else if (grossSalary >= 3000)
            {
                taxPersentage = 30 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;

            }


            //3. show result 
            Console.WriteLine("Gross salary: " + Math.Round(totalSalary, 2));
            Console.WriteLine("Net salary :" + Math.Round(netSalary));
            Console.WriteLine("Tax percentage :" + Math.Round(taxPersentage, 2));
            Console.WriteLine("Tax fee :" + Math.Round(taxValue, 2));


            //4. generate new algoritm  

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