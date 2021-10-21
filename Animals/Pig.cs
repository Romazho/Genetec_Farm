using System;
using System.IO;
using System.Threading.Tasks;

namespace Animals {
      
  class Pig : Animal {

    public Pig(byte id){
      Id = id;
    }

    public override byte EATING_CAPACITY {
      get { return 2; }
    }  //const

    //override
    // override public async Task Eat(byte hayUnits, bool eat){

    //   while (eat && (hayUnits - EATING_CAPACITY) > 0){
    //     await Task.Delay(1000);
        
    //     hayUnits -= EATING_CAPACITY;
    //     hayConsumed += EATING_CAPACITY;
    //     Console.WriteLine("EATING_CAPACITY: " + EATING_CAPACITY);
    //     Console.WriteLine(this.GetType().Name + " " + Id + " consumed: " + hayConsumed);
    //     Console.WriteLine("hayUnits: " + hayUnits);

    //     //return hayUnits;
    //   }
    //   //return hayUnits;

    // }

  }

}