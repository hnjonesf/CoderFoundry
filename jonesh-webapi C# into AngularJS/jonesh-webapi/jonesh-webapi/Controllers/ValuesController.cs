using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace jonesh_webapi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {


        public class threeNumbers
        {
            public int maxn1 { get; set; }
            public int maxn2 { get; set; }
            public int maxn3 { get; set; }
        }

        [HttpPost]
        [Route("max")]
        public int Max(threeNumbers numbers)
        {
            return Math.Max(numbers.maxn1, Math.Max(numbers.maxn2, numbers.maxn3));
        }


        public class threeNumbersSum
        {
            public int sumn1 { get; set; }
            public int sumn2 { get; set; }
            public int sumn3 { get; set; }
        }

        [HttpPost]
        [Route("sum")]
        public int Sum(threeNumbersSum sumNumbers)
        {
            return sumNumbers.sumn1 + sumNumbers.sumn2 + sumNumbers.sumn3;
        }


        public class TwoNumbers
        {
            public int num1 { get; set; }
            public int num2 { get; set; }
        }

        [HttpPost]
        [Route("multiply")]
        public int Multiply(TwoNumbers numList)
        {
            return numList.num1 * numList.num2;
        }

        [HttpPost]
        [Route("factorial")]
        public int Factorial([FromBody]int btnFactorial)
        {
            var number = btnFactorial;
            var total = 1;
            for (var i = number; i > 0; i--)
            {
                total = total * i;
            }

            return total;
        }

        [HttpPost]
        [Route("palindrome")]
        public string Palindrome([FromBody]string btnPalindrome)
        {
            var answerPalindrome = "Yes";
            int min = 0;
            int max = btnPalindrome.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return answerPalindrome;
                }
                char a = btnPalindrome[min];
                char b = btnPalindrome[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    answerPalindrome = "Nope";
                    return answerPalindrome;
                }
                min++;
                max--;
            }
        }

            //public string fizz()
            //{
            //    begin with 1
            //    string collector = "";
            //    Rotate Up to 100
            //    for (int i = 1; i <= 100; i++)
            //    {
            //        string str = "";
            //        compare 3 = Fizz
            //        if (i % 3 == 0)
            //        {
            //            Fizz
            //            str += "Fizz";
            //        }
            //        if (i % 5 == 0)
            //        {
            //            Buzz if / 5
            //            str += "Buzz";
            //        }
            //        else if (str == "")
            //        {
            //            str += i;
            //        }
            //        collector += str + "<br>";
            //    }
            //    return collector;
            //}

    }
}


