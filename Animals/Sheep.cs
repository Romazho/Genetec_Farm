using System;

namespace Animals
{

  class Sheep : Animal
  {

    public Sheep(byte id)
    {
      Id = id;
    }

    public override byte EatingCapacity
    {
      get { return 1; }
    }

  }

}