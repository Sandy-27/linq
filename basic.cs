using System.Collections.Generic;
using System.Linq;
namespace assign2
{
    public class basic
    {
        List<string> l = new List<string>(){
            "Chennai",
            "coimbatore",
        };

        IList<product> list = new List<product>(){
new product(){ProductId=1,ProductName="Watch",ProductPrice=7000},
new product(){ProductId=2,ProductName="shirt",ProductPrice=2000},
new product(){ProductId=3,ProductName="shoe",ProductPrice=5000},
new product(){ProductId=4,ProductName="doll",ProductPrice=1000},
new product(){ProductId=5,ProductName="Watch",ProductPrice=3000},
new product(){ProductId=6,ProductName="Kurta",ProductPrice=890},
        };

        // public void containsinList()
        // {
        //     //query
        //     var result = from i in l
        //                  where i.Contains("Hi")
        //                  select i;
        //     foreach (var i in result)
        //     {
        //         Console.WriteLine(i);
        //     }
        //     //method
        //     var result1 = l.Where(x => x.Contains("Hi"));

        //     l.Add("Dindigul");
        //     l.Add("Erode");
        //    IEnumerable<string> output = l.Select(x => x);
        //     foreach (var i in output)
        //     {
        //         Console.WriteLine(i);
        //     }
        // }

        public void productData()
        {
            //orderby,desc,then,desc,rev,Tolist,ToArray,Elementoperator,Groupby
            var usingorderby = list.Where(x => x.ProductPrice > 1000).OrderByDescending(x => x.ProductName).ThenBy(x => x.ProductPrice);
            foreach (var i in usingorderby)
            {
                Console.WriteLine("Product Name {0} and Poduct Price {1}", i.ProductName, i.ProductPrice);
            }
            IEnumerable<product> outputList = list.ToArray();
            foreach (var i in outputList)
            {
                Console.WriteLine(i.ProductName);
            }
            var outputLookup = list.ToLookup(x => x.ProductName);
            foreach (var i in outputLookup)
            {
                Console.WriteLine("Lookup output as : {0}", i.Key);
            }
            var outputDefault = list.DefaultIfEmpty();
            foreach (var i in outputDefault)
            {
                Console.WriteLine("Deafault ouput is output as : {0}", i?.ProductName);
            }
            var outputgroupby = list.GroupBy(x => x.ProductName);
            foreach (var i in outputgroupby)
            {
                foreach (var j in i)
                    Console.WriteLine("Groupby ouput is output as : {0} - {1}", j.ProductName, j.ProductPrice);
            }

        }
    }
    public class product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }

    }
}