using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator.Models
{
    public class Anniversary
    {
        public Anniversary(int val, string type, DateTime date)
        {
            Value = val;
            Type = type;
            Date = date;
        }

        public int Value { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Value} {Type}: {Date.ToShortDateString()}";
        }
    }
}
