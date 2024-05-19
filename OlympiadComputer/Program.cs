using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation[] operation = new Operation[0];
            string input = "x";
            while (input != "e")
            {
                Console.Clear();
                Console.WriteLine("Add (a)");
                Console.WriteLine("Delete (d)");
                Console.WriteLine("Query (q)");
                Console.WriteLine("Print (p)");
                Console.WriteLine("Exit (e)");
                Console.WriteLine();
                Console.Write("what do you wanna do? :  ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "a":

                        Operation add = new Operation();

                        Operation[] OperationAdd = new Operation[operation.Length + 1];

                        for (int i = 0; i < operation.Length; i++)
                        {
                            OperationAdd[i] = operation[i];
                        }

                        Console.Write("Enter the time  :  ");
                        if (!int.TryParse(Console.ReadLine(), out int timeNumber))
                        {
                            Console.WriteLine("Invalid Value!");
                            Console.ReadKey();

                            break;
                        }

                        Console.Write("Enter the value  :  ");
                        if (!double.TryParse(Console.ReadLine(), out double valueNumber))
                        {
                            Console.WriteLine("Invalid Value!");
                            Console.ReadKey();

                            break;
                        }

                        add.value1 = timeNumber;
                        add.value2 = valueNumber;
                        add.Operator = "Add";
                        add.active = true;

                        OperationAdd[operation.Length] = add;

                        operation = new Operation[OperationAdd.Length];

                        for (int i = 0; i < operation.Length; i++)
                        {
                            operation[i] = OperationAdd[i];
                        }

                        break;

                    case "d":

                        Operation delete = new Operation();

                        Operation[] OperationDelete = new Operation[operation.Length + 1];

                        for (int i = 0; i < operation.Length; i++)
                        {
                            OperationDelete[i] = operation[i];
                        }

                        Console.Write("Enter the operation time  :  ");
                        if (!int.TryParse(Console.ReadLine(), out int operationTime))
                        {
                            Console.WriteLine("Invalid Value!");
                            Console.ReadKey();

                            break;
                        }

                        Console.Write("Enter the target time  :  ");
                        if (!int.TryParse(Console.ReadLine(), out int targetTime))
                        {
                            Console.WriteLine("Invalid Value!");
                            Console.ReadKey();

                            break;
                        }

                        delete.value1 = operationTime;
                        delete.value2 = targetTime;
                        delete.Operator = "Delete";
                        delete.active = true;

                        OperationDelete[operation.Length] = delete;

                        operation = new Operation[OperationDelete.Length];

                        for (int i = 0; i < operation.Length; i++)
                        {
                            operation[i] = OperationDelete[i];
                        }

                        break;

                    case "q":

                        Console.Write("Enter the time : ");
                        if (!int.TryParse(Console.ReadLine(), out int timeQuery))
                        {
                            Console.WriteLine("Invalid Value!");
                            Console.ReadKey();

                            break;
                        }

                        
                        double sum = 0;
                        int index = 0;
                        for (int i = operation.Length-1; i >= 0; i--)
                        {
                            if (operation[i].value1 <= timeQuery && operation[i].active == true)
                            {
                                if (operation[i].Operator == "Add")
                                {
                                    sum += operation[i].value2;
                                }
                                else if (operation[i].Operator == "Delete")
                                {
                                    for (int j = 0; j < i; j++)
                                    {
                                        if (operation[j].value1 == operation[i].value2 && operation[j].active == true)
                                        {
                                            index = j;
                                            break;
                                        }
                                    }
                                    operation[index].active = false;
                                }
                            }
                        }
                        for (int i = 0; i < operation.Length; i++)
                        {
                            operation[i].active = true;
                        }
                        Console.WriteLine(sum);
                        Console.ReadKey();

                        break;

                    case "p":
                        foreach (var item in operation)
                        {
                            Console.WriteLine("{0}({1},{2})", item.Operator, item.value1, item.value2);
                        }
                        Console.ReadKey();
                        break;

                    case "e":

                        Environment.Exit(0);
                        break;

                    default:

                        break;
                }

            }

        }
    }
}
