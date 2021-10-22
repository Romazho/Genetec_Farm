using System;
using System.IO;
using System.Threading.Tasks;
using Animals;

namespace Farm
{

  class Hay
  {

    public byte hayUnits = 100;

    public async Task ConsumeHay(Animal animal)
    {
      while (animal.isEating && (hayUnits - animal.EatingCapacity) > 0)
      {
        await Task.Delay(1000); // 1 second

        if (hayUnits > 0)
        {
          hayUnits -= animal.EatingCapacity;
        }
        else
        {
          animal.isEating = false;
          break;
        }

        animal.hayConsumed += animal.EatingCapacity;
      }

      Console.WriteLine(animal.GetType().Name + " " + animal.Id + " has stopped eating.");

    }

  }

}