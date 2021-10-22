using System;
using System.IO;
using System.Threading.Tasks;
using Animals;

namespace Farm
{

  class Hay
  {

    public byte hayUnits = 100;
    private readonly object hayUnitsLock = new object();

    public async Task ConsumeHay(Animal animal)
    {
      while (animal.isEating)
      {
        await Task.Delay(1000); // 1 second

        lock (hayUnitsLock)
        {
          if (hayUnits - animal.EatingCapacity >= 0)
          {
            hayUnits -= animal.EatingCapacity;
          }
          else
          {
            animal.isEating = false;
            break;
          }
        }

        animal.hayConsumed += animal.EatingCapacity;
      }

      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine(animal.GetType().Name + " " + animal.Id + " has stopped eating.");
      Console.ResetColor();

    }

  }

}