using System;
using System.IO;
using System.Threading.Tasks;
using Animals;

namespace Farm
{

  class Hay
  {

    public byte hayUnits = 100;
    private readonly object hayLock = new object(); //use?

    public async Task ConsumeHay(Animal animal)
    {

      while (animal.isEating && (hayUnits - animal.EatingCapacity) > 0)
      {
        await Task.Delay(1000);

        hayUnits -= animal.EatingCapacity;
        animal.hayConsumed += animal.EatingCapacity;
        Console.WriteLine(animal.GetType().Name + " " + animal.Id + " consumed: " + animal.hayConsumed);
        Console.WriteLine("hayUnits: " + hayUnits);
      }

    }
  }

}