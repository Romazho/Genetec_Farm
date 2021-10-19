using System;
using System.IO;
  
namespace Animals {
      
    abstract class  Animal {

      protected byte Id;
      protected byte EatCapacity;
      protected byte hayConsumed;
          
      protected abstract void Eat(byte hayUnit);
    }
}