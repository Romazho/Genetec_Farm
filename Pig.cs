using System;
using System.IO;

namespace Animals {
      
    class Pig : Animal {

      public Pig(byte id){
        Id = id;
        Console.WriteLine("My id is: " + Id);
        Console.WriteLine("My eat capacity is : " + EatCapacity);
      }

      protected byte Id;

      protected byte EatCapacity = 2;

      protected byte hayConsumed = 0;

      public void Eat(ref byte hayUnit){
        //do a loop
        hayUnit -= EatCapacity;
        System.Threading.Thread.Sleep(1000);
      }
    }
}