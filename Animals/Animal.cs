using System;

namespace Animals
{

  abstract class Animal
  {

    public byte Id { get; set; }
    public virtual byte EatingCapacity
    {
      get { return 0; }
    }
    public byte hayConsumed = 0;
    public bool isEating = false;

  }

}