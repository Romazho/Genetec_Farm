using System;

namespace Animals
{

  class Cow : Animal
  {

    public Cow(byte id)
    {
      Id = id;
    }

    public override byte EatingCapacity
    {
      get { return 4; }
    }

  }

}