

using Microsoft.VisualBasic.CompilerServices;

namespace SimpleCalculator.Models;

public enum Operators
{
    add,sub,mul,div
}

    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.add:
                        return "+";
                    case Operators.sub:
                        return "-";
                    case Operators.div:
                        return "/";
                    case Operators.mul:
                        return "*";
                        
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate() {
            switch (Operator)
            {
                case Operators.add:
                    return (double) (X + Y);
                case Operators.sub:
                    return (double)(X - Y);
                case Operators.div:
                    return (double) (X / Y);
                case Operators.mul:
                    return (double) (X * Y);
                default: return double.NaN;
            }
        }
    }
