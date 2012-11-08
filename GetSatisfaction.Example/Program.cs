using System;
using System.Collections.Generic;
using System.Linq;
using GetSatisfaction.Models;

namespace GetSatisfaction.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new SatisfactionClient("123", "1234567890", "123", "1234567890");

            IList<Topic> model = client.GetTopics("GetSatisfaction-DotNet");
            model.ToList().ForEach(x => Console.WriteLine(x.Subject));

            Console.ReadKey();
        }
    }
}
