using System;
using System.IO;
using System.Threading.Tasks;
using Animals;

namespace Farm {
      
  class Hay {

    public byte hayUnits = 100; 
    private readonly object hayLock = new object();

    public async Task ConsumeHay(Animal animal){

      while (animal.isEating && (hayUnits - animal.EATING_CAPACITY) > 0){
        await Task.Delay(1000);
        
        hayUnits -= animal.EATING_CAPACITY;
        animal.hayConsumed += animal.EATING_CAPACITY;
        Console.WriteLine("EATING_CAPACITY: " + animal.EATING_CAPACITY);
        Console.WriteLine(animal.GetType().Name + " " + animal.Id + " consumed: " + animal.hayConsumed);
        Console.WriteLine("hayUnits: " + hayUnits);

      }

    }
  }

}