using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    public class LogOperation
    {
        public int Id;
        public string FirstNumber;
        public string SecondNumber;
        public int Operator;
        public double Result;
        public DateTime CurrentDateTime;
        public string Message;

        public LogOperation() { }

        // getOperation per formattare
        // id 4 cifre
    }
}

/*
 - AGGIUNGERE voce di menu per stampare tutto il Log
 - Impostare un metodo getOperation per visualizzare in maniera esteticamente gradevole l'output
 - Formattare in modo tale da avere l'Id di 4 cifre fisso
 - Gestire un caso in Insert non gestito
 */