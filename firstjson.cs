using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace assign2{
    class student{
         public int Roll {get; set;}
  public string? name {get; set;}
  public List<string>? courses {get; set;}
    }

    public class samplejson{
public void studenDetail()
    {
      student student1 = new student() 
      {
      Roll = 110,
      name = "Alex",
      courses = new List<string>()
      {
        "Math230",
        "Calculus1",
        "CS100",
        "ML"
      }
      };
     Console.WriteLine("JSON converted string: ");
     // convert to Json string by seralization of the instance of class.
     string stringjson = JsonConvert.SerializeObject(student1);
     Console.WriteLine(stringjson);  
      }
    }
    }
