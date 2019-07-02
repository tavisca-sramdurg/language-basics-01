using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {


            int indexStar = 0;
            int indexEqual = 0;
            int indexQuestionMark = 0;

            for (int k = 0; k < equation.Length; k++)
            {
                if (k == equation.IndexOf('*'))
                {
                    indexStar = k;
                }

                if (k == equation.IndexOf('='))
                {
                    indexEqual = k;
                }

                if (k == equation.IndexOf('?'))
                {
                    indexQuestionMark = k;
                }
            }

            //finding the number with a missing digit
            if (indexQuestionMark < indexStar && indexQuestionMark < indexEqual)  //number 1 is incomplete
            {
                int res = NumberOneIncomplete(equation);
                return res;

            }

            else if (indexQuestionMark > indexStar && indexQuestionMark < indexEqual)  //number 2 is incomplete
            {
                int res = NumberTwoIncomplete(equation);
                return res;
            }

            else                                                                    //number 3 is incomplete
            {
                int res = NumberThreeIncomplete(equation);
                return res;
            }
        }



        public static int NumberOneIncomplete(string equation)
        {
            string[] numbers = GetNumbers(equation);
            string num1 = numbers[0];

            Int32.TryParse(numbers[1], out int n2);
            Int32.TryParse(numbers[2], out int n3);


            if (n3 % n2 == 0)
            {
                int n1x = n3 / n2;
                string t1 = n1x.ToString();

                for (int p = 0; p < t1.Length; p++)
                {
                    if (num1.ElementAt(p) == '?')
                    {
                        char rc = t1.ElementAt(p);
                        int res = rc - '0';
                        return res;
                    }
                }
            }
            else
            {
                return -1;
            }

            return -1;
        }

        public static int NumberTwoIncomplete(string equation)
        {
            string[] numbers = GetNumbers(equation);
            string num2 = numbers[1];

            Int32.TryParse(numbers[0], out int n1);
            Int32.TryParse(numbers[2], out int n3);

            if (n3 % n1 == 0)
            {
                int n2x = n3 / n1;
                string t2 = n2x.ToString();

                if (num2.Length != t2.Length)
                {
                    return -1;
                }

                for (int p = 0; p < t2.Length; p++)
                {
                    if (p == num2.IndexOf('?'))
                    {
                        char rc = t2.ElementAt(p);
                        int res = rc - '0';
                        return res;
                    }
                }
            }
            else
            {
                return -1;
            }

            return -1;
        }

        public static int NumberThreeIncomplete(string equation)
        {
            string[] numbers = GetNumbers(equation);
            string num3 = numbers[2];

            Int32.TryParse(numbers[0], out int n1);
            Int32.TryParse(numbers[1], out int n2);

            //Compute
            int n3x = n1 * n2;

            string t3 = n3x.ToString();

            for (int p = 0; p < t3.Length; p++)
            {
                if (p == num3.IndexOf('?'))
                {
                    char rc = t3.ElementAt(p);
                    int res = rc - '0';
                    return res;
                }
            }

            return -1;
        }

        public static string[] GetNumbers(string equation)
        {
            string[] numbers = new string[3];
            //Number 1
            string[] temp1 = equation.Split('*');
            string num1 = temp1[0];

            // Number 2
            string[] temp2 = temp1[1].Split('=');
            string num2 = temp2[0];


            // Number 3
            string num3 = temp2[1];

            numbers[0] = num1;
            numbers[1] = num2;
            numbers[2] = num3;

            return numbers;
        }
    }
}
