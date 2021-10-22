using System;

namespace Animals
{

  class Pig : Animal
  {

    public Pig(byte id)
    {
      Id = id;
    }

    public override byte EatingCapacity
    {
      get { return 2; }
    }

  }

}