using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
  
namespace Animals {
      
  abstract class  Animal {

    public byte Id {get; set;}
    public byte EATING_CAPACITY = 0;  //const
    public byte hayConsumed = 0;
    public bool isEating = false;
        
    //change to not be abstract and remove comment
    // public virtual async Task<byte> Eat(byte hayUnits, bool eat){
    //   await Task.Delay(1);
    //   return hayUnits;
    //   // hayUnits -= EATING_CAPACITY;
    //   // hayConsumed += EATING_CAPACITY;
    //   // Console.WriteLine("I am: " + this.GetType().Name + " " + Id);
    //   // Console.WriteLine("EATING_CAPACITY: " + EATING_CAPACITY);
    //   // System.Threading.Thread.Sleep(1000);
    // }

  }

}