using System;
using System.Collections.Generic;

namespace WebApplication_MVC
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, int> QuantityPizza { get; set; }
        public virtual Squirrel Squirrel { get; set; }

        //count check out
        public int CheckOut(Dictionary<string, int> dic)
        { int sum = 0;
            foreach (int item in dic.Values)
            {
                sum += item;
            }
            return sum;
        }
    }
}