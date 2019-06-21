using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
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

            //finding the number with a missing digit
            int indexs = 0;
            int indexe = 0;
            int indexq = 0;

            for (int k = 0; k < equation.Length; k++)
            {
                if(equation.ElementAt(k) == '*')
                {
                    indexs = k;
                }

                if (equation.ElementAt(k) == '=')
                {
                    indexe = k;
                }

                if (equation.ElementAt(k) == '?')
                {
                    indexq = k;
                }
            }

            if(indexq < indexs && indexq < indexe)  //number 1 is incomplete
            {
                // Number 1
                int c1 = 0;
                int i = 0;
                while (equation.ElementAt(i++) != '*')
                {
                    c1++;
                }
                string nc1 = equation.Substring(0, c1);
                //int n1 = Int32.Parse(nc1);
                //Console.WriteLine("nc1 : " + nc1);

                // Number 2
                int c2 = 0;
                i = c1 + 2;
                while (equation.ElementAt(i++) != '=')
                {
                    c2++;
                }
                string nc2 = equation.Substring(c1 + 1, c2 + 1);
                int n2 = Int32.Parse(nc2);

                //Console.WriteLine("nc2 : " + nc2);

                // Number 3
                int c3 = 0;
                i = c1 + c2 + 3;

                while (i < equation.Length - 1)
                {
                    c3++;
                    i++;
                }

                string nc3 = equation.Substring(c1 + c2 + 3, c3 + 1);
                //Console.WriteLine("nc3 : " + nc3);
                int n3 = Int32.Parse(nc3);

                int n1x = 0;
                if(n3%n2 == 0)
                {
                    n1x = n3 / n2;
                    string t1 = n1x.ToString();
                    
                    for(int p = 0; p < t1.Length; p++)
                    {
                        if (nc1.ElementAt(p) == '?')
                        {
                            //Console.WriteLine("RES : " + t1.ElementAt(p));
                            char rc = t1.ElementAt(p);
                            int res = rc - '0';
                            return res;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("RES : " + (-1));
                    return -1;
                }


            }

            else if (indexq > indexs && indexq < indexe)  //number 2 is incomplete
            {
                // Number 1
                int c1 = 0;
                int i = 0;
                while (equation.ElementAt(i++) != '*')
                {
                    c1++;
                }
                string nc1 = equation.Substring(0, c1);
                int n1 = Int32.Parse(nc1);
                //Console.WriteLine("nc1 : " + nc1);

                // Number 2
                int c2 = 0;
                i = c1 + 2;
                while (equation.ElementAt(i++) != '=')
                {
                    c2++;
                }
                string nc2 = equation.Substring(c1 + 1, c2 + 1);
                //int n2 = Int32.Parse(nc2);

                //Console.WriteLine("nc2 : " + nc2);

                // Number 3
                int c3 = 0;
                i = c1 + c2 + 3;

                while (i < equation.Length - 1)
                {
                    c3++;
                    i++;
                }

                string nc3 = equation.Substring(c1 + c2 + 3, c3 + 1);
                //Console.WriteLine("nc3 : " + nc3);
                int n3 = Int32.Parse(nc3);

                int n2x = 0;
                if (n3 % n1 == 0)
                {
                    n2x = n3 / n1;
                    string t2 = n2x.ToString();

                    if (nc2.Length != t2.Length)
                    {
                        //Console.WriteLine("RES : " + (-1));
                        return -1;
                    }

                    for (int p = 0; p < t2.Length; p++)
                    {
                        if (nc2.ElementAt(p) == '?')
                        {
                            //Console.WriteLine("RES : " + t2.ElementAt(p));
                            char rc = t2.ElementAt(p);
                            int res = rc - '0';
                            return res;
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("RES : " + (-1));
                    return -1;
                }
            }

            else if (indexq > indexs && indexq > indexe)  //number 3 is incomplete
            {
                // Number 1
                int c1 = 0;
                int i = 0;
                while (equation.ElementAt(i++) != '*')
                {
                    c1++;
                }
                string nc1 = equation.Substring(0, c1);
                int n1 = Int32.Parse(nc1);
                //Console.WriteLine("nc1 : " + nc1);

                // Number 2
                int c2 = 0;
                i = c1 + 2;
                while (equation.ElementAt(i++) != '=')
                {
                    c2++;
                }
                string nc2 = equation.Substring(c1 + 1, c2 + 1);
                int n2 = Int32.Parse(nc2);

                //Console.WriteLine("nc2 : " + nc2);

                // Number 3
                int c3 = 0;
                i = c1 + c2 + 3;

                while (i < equation.Length - 1)
                {
                    c3++;
                    i++;
                }

                string nc3 = equation.Substring(c1 + c2 + 3, c3 + 1);
                //Console.WriteLine("nc3 : " + nc3);
                //int n3 = Int32.Parse(nc3);

                //Compute
                int n3x = n1 * n2;

                string t3 = n3x.ToString();

                for (int p = 0; p < t3.Length; p++)
                {
                    if (nc3.ElementAt(p) == '?')
                    {
                        //Console.WriteLine("RES : " + t3.ElementAt(p));
                        char rc = t3.ElementAt(p);
                        int res = rc - '0';
                        return res;
                    }
                }
            }

           


            throw new NotImplementedException();
        }
    }
}
