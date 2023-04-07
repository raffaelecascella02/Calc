using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    public interface ICalcRepository
    {
        public void OperationInsert(string num1, string num2, int _choice, double result, string message);
        public (string, List<LogOperation>) GetAllOperation();
    }
}
