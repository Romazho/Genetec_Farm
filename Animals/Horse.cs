using System;

namespace Animals
{

  class Horse : Animal
  {

    public Horse(byte id)
    {
      Id = id;
    }

    public override byte EatingCapacity
    {
      get { return 3; }
    }

  }

}