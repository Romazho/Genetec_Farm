using System;
using System.IO;
  
namespace Animals {
      
  abstract class  Animal {

    public byte Id {get; set;}
    protected const byte EATING_CAPACITY = 0;
    public byte hayConsumed = 0;
    public bool isEating = false;
        
    //change to not be abstract and remove comment
    public abstract void Eat(ref byte hayUnits);
  }

}