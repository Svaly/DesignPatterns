using System;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal total = 500;
            string code = "BBX125";

            // category bb has 5% discount
            if (code.Contains("BB"))
            {
                total = total * (decimal)0.95;
            }
            // products with number higher than 124 are considered premium and has higher tax
            else if (code.GetNumericCode() >= 125)
            {
                total = total * (decimal)1.36;
            }
            else if(code.GetNumericCode() < 125)
            {
                total = total * (decimal)1.2;
            }

            Console.WriteLine($"Else if total: {total}");

            total = new TotalCostCalculatorCategoryDiscountHandler()
                        .SetNextHandler(new TotalCostCalculatorTaxHandler())
                        .CalculateTotal(code, total);

            Console.WriteLine($"Chain of responsibility total: {total}");
            Console.ReadKey();
        }
    }

    public abstract class TotalCostCalculateChain
    {
        private TotalCostCalculateChain _nextHandler;

        public TotalCostCalculateChain SetNextHandler(TotalCostCalculateChain nextHandler)
        {
            _nextHandler = nextHandler;
            return _nextHandler;
        }

        public decimal CalculateTotal(string code, decimal total)
        {
            return _nextHandler?.Handle(code, total) ?? total;
        }

        protected abstract decimal Handle(string code, decimal total);
    }

    public class TotalCostCalculatorCategoryDiscountHandler : TotalCostCalculateChain
    {
        const decimal Discount = (decimal)0.05;

        protected override decimal Handle(string code, decimal total)
        {
            return code.Contains("BB") ? total - Discount * total : total;
        }
    }

    public class TotalCostCalculatorTaxHandler : TotalCostCalculateChain
    {
        const decimal PremiumProductsTax = (decimal)1.36;
        const decimal StandardTax = (decimal)1.2;

        protected override decimal Handle(string code, decimal total)
        {
            return code.GetNumericCode() >= 125 ? total * PremiumProductsTax : total * StandardTax;
        }
    }

    public static class Extension
    {
        public static decimal GetNumericCode(this string text)
        {
            return 0;
        }
    }
}
