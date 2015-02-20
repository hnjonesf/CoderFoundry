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
        /// <summary>
        /// Get Max Value from and Array
        /// </summary>
        /// <param name="values"></param>
        /// <returns>int values</returns>
        [HttpGet]
        [Route("max")]
        public int Max([FromUri] int[] values)
        {
            int currentMax = values.Max();

            return currentMax;
        }

        /// <summary>
        /// Sum and Multiply an Array
        /// </summary>
        /// <param name=numbers></param>
        /// <returns>int sum and int product of array</returns>
        [HttpGet]
        [Route("sum")]
        public int sum([FromUri]int[] numbers)
        {            
            int sum = numbers.Sum();
            return sum;
        }

        /// <summary>
        /// Sum and Multiply an Array
        /// </summary>
        /// <param name=numbers></param>
        /// <returns>int sum and int product of array</returns>
        [HttpGet]
        [Route("multiply")]
        public int multiply([FromUri]int[] numbers)
        {
            int product = 1;
            for (int i = 0; i < numbers.Length ; i++)
            {
                product = product * numbers[i];
            }

            return product;
        }

        /// <summary>
        /// Factorial of a Number
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>int sum and int product of array</returns>
        [HttpGet]
        [Route("factorial")]
        public int factorial(int numberToFactor)
        {
            var number = numberToFactor;
            var total = 1;
            for (var i = number; i > 0; i--)
            {
                total = total * i;
            }

            return total;
        }

        /// <summary>
        /// Palindrome
        /// </summary>
        /// <param name="string value"></param>
        /// <returns>bool</returns>
        [HttpGet]
        [Route("isPalindrome")]
        public static bool isPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

/// <summary>
/// Fizz, etc
/// </summary>
/// <returns></returns>
        public string fizz ()
        {
        //begin with 1
        string collector = "";
        //Rotate Up to 100
        for (int i = 1; i <= 100; i++) 
        {
            string str = "";
            //compare 3 = Fizz
            if (i % 3 == 0) 
            {
                //Fizz
                str += "Fizz";
            }
            if (i % 5 == 0) 
            {
                //Buzz if / 5
                str += "Buzz";
            }
            else if (str == "") {
                str += i;
            }
            collector += str + "<br>";
        }
        return collector;
        }

        //Leaving off Alice for Now as I lost my C# code and need to focus on api/  hnjones 02-18-2015

    }
}
