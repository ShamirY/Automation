using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = "00:01:07,400-234-090";
            var component = new Solution();
            var result = component.solution(inputString); 

            Console.WriteLine("The result is: " + result);

        }
    }
}


