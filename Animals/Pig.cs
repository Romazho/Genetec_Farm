using System;
using System.IO;

namespace Animals {
      
  class Pig : Animal {

    public Pig(byte id){
      Id = id;
    }

    protected new const byte EATING_CAPACITY = 2;

    override public void Eat(ref byte hayUnits){
      //do a loop
      hayUnits -= EATING_CAPACITY;
      hayConsumed += EATING_CAPACITY;
      System.Threading.Thread.Sleep(1000);
    }
    
  }

}