namespace BincomAssign2.Okwe.Implementation
{
    public class Calculator 
    { 
        public decimal CalculatePAYE(decimal income)
        {
            decimal tax = 0;
            decimal minimumWage = 360000m;

            if (income <= minimumWage)
            {
                return 0;
            }

            decimal[] incomeBrackets = { 300000m, 300000m, 500000m, 500000m, 1600000m };
            decimal[] taxRates = { 0.07m, 0.11m, 0.15m, 0.19m, 0.21m };
            decimal highIncomeRate = 0.24m;

            for (int i = 0; i < incomeBrackets.Length; i++)
            {
                if (income > incomeBrackets[i])
                {
                    tax += incomeBrackets[i] * taxRates[i];
                    income -= incomeBrackets[i];
                }
                else
                {
                    tax += income * taxRates[i];
                    return tax;
                }
            }

            if (income > 0)
            {
                tax += income * highIncomeRate;
            }

            return tax;
        }
    }
}
