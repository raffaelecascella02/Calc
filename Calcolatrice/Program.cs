using System.Data.SqlClient;

namespace CalculatorCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            ICalcRepository dbOperation = new DbOperation("Data Source=localhost; Initial Catalog=CalcDb; Integrated Security=True");

            while (exit == 0)
            {
                PrintInstructions();
                int _choice = Choice();

                if (_choice == 9)
                {
                    exit = 9;
                    dbOperation.OperationInsert(string.Empty, string.Empty, exit, 0, "Exit");
                }
                else if (_choice == 7) 
                {
                    //dbOperation.OperationSelect();
                }
                else
                {
                    string num1 = RetrieveNumForOperation("Insert 1st Value");
                    string num2 = (_choice != 5 && _choice != 6 ? RetrieveNumForOperation("Insert 2nd Value") : "1");
                    (string errorMessage, double risultato) = Calculator.SwitchChoiceForOperation(choice: _choice, Num1: num1, Num2: num2);

                    if (!string.IsNullOrEmpty(errorMessage))
                        Console.WriteLine(errorMessage);
                    else
                        Console.WriteLine($"Result is: {risultato}");

                    dbOperation.OperationInsert(num1, num2, _choice, risultato, errorMessage);

                    #region EXIT VALUE CONTROL
                    while (true)
                    {
                        string message = String.Empty;
                        Console.WriteLine("CONTINUE (0) OR EXIT(9)?");

                        try
                        {
                            exit = Convert.ToInt32(Console.ReadLine());
                            if (exit != 0 && exit != 9)
                            {
                                message = "Input Error";
                                dbOperation.OperationInsert(string.Empty, string.Empty, exit, -99999, message);
                                Console.WriteLine(message);
                                Console.Write("Reinsert, please -> ");
                                exit = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                message = exit == 0 ? "Continue" : "Exit";
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            message = e.Message;
                            Console.WriteLine(message);
                        }
                        finally
                        {
                            dbOperation.OperationInsert(string.Empty, string.Empty, exit, 0, message);
                            
                        }
                    }
                    #endregion
                }
            }
        }

        public static void PrintInstructions()
        {
            Console.Clear();
            Console.WriteLine("Choose the operator: ");
            Console.WriteLine("1. SUM\n" +
                              "2. SUBTRACTION\n" +
                              "3. MULTIPLICATION\n" +
                              "4. DIVISION\n" +
                              "5. SQUARED POWER\n" +
                              "6. CUBED POWER\n" +
                              "7. PRINT HISTORY\n" +
                              "8. - EMPTY -\n" +
                              "9. EXIT");
        }
        public static int Choice()
        {
            int choice;
            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.Write("\nChoice -> ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice > 0 && choice <= 7 || choice == 9)
                        {
                            Console.WriteLine();
                            return choice;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value! Reinsert;\n");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unespected Input!\n {e}\"\n");
                }
            }
        }
        public static string RetrieveNumForOperation(string mex)
        {
            string number = String.Empty;
            Console.Write($"{mex} -> ");
            try
            {
                number = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return number;
        }

    }
}