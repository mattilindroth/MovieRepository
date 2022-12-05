using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    public class LovelyClass : ILovelyInterface
    {
        public LovelyClass() { }

        public void LovelyMethod(int lovelyParameter)
        {
            Console.WriteLine("Isn't life lovely");
        }
    }
}
