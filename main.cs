using System;
using System.IO;
using Animals;
  
namespace Farm {
      
    class Farm {

      private static byte hayUnit = 100;
          
      static void Main(string[] args) {
            
          Console.WriteLine("Welcome to my farm!");
          
          // To prevents the screen from running and closing quickly

          // Creating animals
          Pig pig1 = new Pig(1);
          Console.ReadKey();

          string path = @"Rapport.txt";
          // Create a file to write to.
          using (StreamWriter sw = File.CreateText(path))
          {
              sw.WriteLine("Test " + hayUnit + " " + pig1.Id);
          }	

      }
    }

}