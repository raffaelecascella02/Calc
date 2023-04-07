using System;

namespace CalculatorCode
{
    public static class Calculator
    {
        #region Attributes
        #endregion

        //#region Constructor(s)
        //public Calculator()
        //{
        //    
        //}
        //#endregion

        #region Methods
        /// <summary>
        /// Validates the number passed as a parameter by Program
        /// </summary>
        /// <param name="number">Number to verify</param>
        /// <returns>Error message, number</returns>
        public static (string, double) ValidateNum(string number)
        {
            string errore = String.Empty;
            double num = -99999;
            try
            {
                if (number != null)
                    num = Convert.ToDouble(number);
            }
            catch (Exception e) 
            {
                errore = e.Message;
            }
            return (errore, num);
        }

        /// <summary>
        /// Choice of the operation
        /// </summary>
        /// <param name="choice">Parameter of choice</param>
        /// <param name="Num1">First Number Passed</param>
        /// <param name="Num2">Second Number Passed (optional)</param>
        /// <returns></returns>
        public static (string, double) SwitchChoiceForOperation(int choice, string Num1, string Num2)
        {
            double risultato = -99999;
            (string errore, double num1) = ValidateNum(Num1);

            if (!string.IsNullOrEmpty(errore))
            {
                return (errore, risultato);
            }

            (errore, double num2) = ValidateNum(Num2);

            if (!string.IsNullOrEmpty(errore))
            {
                return (errore, risultato);
            }

            switch (choice)
            {
                case 1: //Sum

                    (errore, risultato) = Sum(num1, num2);

                    break;

                case 2: //Subtraction

                    (errore, risultato) = Sub(num1, num2);
                    break;

                case 3: //Multiplication

                    (errore, risultato) = Mul(num1, num2);
                    break;

                case 4: //Division

                    (errore, risultato) = Div(num1, num2);
                    break;

                case 5: //Squared

                    (errore, risultato) = Squared(num1);
                    break;

                case 6: //Cubed

                    (errore, risultato) = Cubed(num1);
                    break;

                default:
                    errore = "Invalid input!";
                    break;
            }
            return (errore, risultato);
        }

        private static (string, double) Sum(double num1, double num2)
        {
            double sum = -99999;
            string error = String.Empty;
            try
            {
                sum = num1 + num2;
                //Console.WriteLine($"SUM of {num1} + {num2} = {sum}");
            }
            catch (Exception e) 
            {
                error = e.Message;
            }
            return (error, sum);
        }

        private static (string, double) Sub(double num1, double num2)
        {
            double subtraction = -99999;
            string error = String.Empty;
            try
            { 
                subtraction = num1 - num2;
                //Console.WriteLine($"SUBTRACTION of {num1} - {num2} = {subtraction}");
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return (error, subtraction);
        }

        private static (string, double) Mul(double num1, double num2)
        {
            double multiplication = -99999;
            string error = String.Empty;
            try
            {
                multiplication = num1 * num2;
                //Console.WriteLine($"MULTIPLICATION of {num1} x {num2} = {multiplication}");
            }
            catch (Exception e) 
            {
                error = e.Message;
            }
            return (error, multiplication);
        }

        private static (string, double) Div(double num1, double num2)
        {
            double division = -99999;
            string error = String.Empty;
            try
            {
                if (num2 == 0)
                {
                    error = "The denominator must be non-zero!";
                    return (error, division);
                }
                division = num1 / num2;
                //Console.WriteLine($"DIVISION of {num1} / {num2} = {division}");
            }
            catch (Exception e) 
            {
                error = e.Message;
            }
            return (error, division);
        }

        private static (string, double) Squared(double num)
        {
            string error = String.Empty;
            double squared = -99999;
            try
            {
                squared = num * num;
                //Console.WriteLine($"THE SQUARED POWER OF {num} is: {squared}");
            }
            catch (Exception e) 
            {
                error = e.Message;
            }
            return (error, squared);
        }

        private static (string, double) Cubed(double num)
        {
            double cubed = -99999;
            string error = String.Empty;
            try
            {
                cubed = num * num * num;
                //Console.WriteLine($"CUBED POWER of {num} = {cubed}");
            }
            catch (Exception e) 
            {
                error = e.Message;
            }
            return (error, cubed);
        }
        #endregion
    }
}