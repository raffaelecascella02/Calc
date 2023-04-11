using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    public class DbOperation : ICalcRepository
    {
        DbManager dbManager;

        public DbOperation(string connstr)
        {
            dbManager = new DbManager(connstr);
        }

        public void OperationInsert(string num1, string num2, int _choice, double result, string message)
        {
            string query = ($"INSERT INTO Log (FirstNumber, SecondNumber, Operator, Result, CurrentDateTime, Message)" +
                            $"VALUES ('{num1}', '{num2}', '{_choice}', '{result}'," +
                            $"'{DateTime.Now}', '{message}');");
            // caso da gestire
            dbManager.Insert(query);
        }

        public (string, List<LogOperation>) GetAllOperation()
        {
            string query = $"SELECT * FROM Log;";
            (string error, DataSet result) = dbManager.Select(query);
            List<LogOperation> logOperations = new List<LogOperation>();

            if (!string.IsNullOrEmpty(error))
                return (error, logOperations);

            try
            {
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    DataRow row = result.Tables[0].Rows[i];
                    LogOperation operation = new LogOperation()
                    {
                        Id = row.IsNull("Id") ? -1 : Convert.ToInt32(row["Id"]),
                        FirstNumber = row.IsNull("FirstNumber") ? string.Empty : Convert.ToString(row["FirstNumber"]),
                        SecondNumber = row.IsNull("SecondNumber") ? string.Empty : Convert.ToString(row["SecondNumber"]),
                        Operator = row.IsNull("Operator") ? -1 : Convert.ToInt32(row["Operator"]),
                        Result = row.IsNull("Result") ? -1 : Convert.ToDouble(row["Result"]),
                        CurrentDateTime = row.IsNull("CurrentDateTime") ? new DateTime(2000, 1, 1) : Convert.ToDateTime(row["CurrentDateTime"]),
                        Message = row.IsNull("Message") ? string.Empty : Convert.ToString(row["Message"])
                    };
                    logOperations.Add(operation);
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return (error, logOperations);
        }


    }
}
