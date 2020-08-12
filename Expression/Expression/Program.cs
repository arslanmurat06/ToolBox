using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { -3, 4, -5543, 234, 24, 423, -425, 42, -2342, 234, 2, 34, 23, 0 };
            Expression<Func<int, bool>> positivenNumberPredicate = (a) => a > 0;
            Expression<Func<int,bool>> negativeNumberPredicate = (a) => a < 0;

            //Find the positive numbers

            var positiveNumbers  = FindRequestedNumbers(numbers, positivenNumberPredicate);

            //Find the negative numbers

            var negativeNummbers = FindRequestedNumbers(numbers, negativeNumberPredicate);

            Console.WriteLine("Positive Numbers");
            positiveNumbers.ForEach((a)=> Console.Write($"{a} "));
            Console.WriteLine();

            Console.WriteLine("Negative Numbers");
            negativeNummbers.ForEach((a) => Console.Write($"{a} "));

            Console.ReadKey();
        }


        private static List<int> FindRequestedNumbers(List<int> numbers, Expression<Func<int, bool>> predicate)
        {
            SplitExpression(predicate);
            var requestedNumbers = numbers.AsQueryable().Where(predicate).ToList();
            return requestedNumbers;

        }

        private static void SplitExpression(Expression<Func<int, bool>> predicate)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Splitting Expressions:");
            BinaryExpression body = (BinaryExpression)predicate.Body;
            Console.WriteLine($"Expression Body: {body.ToString()}");
            Console.WriteLine($"Expression Right: {body.Right.ToString()}");
            Console.WriteLine($"Expression Left: {body.Left.ToString()}");
            Console.WriteLine($"Expression Node Type: {body.NodeType.ToString()}");
            Console.WriteLine("-------------------------------------------------------");

        }
    }
}
