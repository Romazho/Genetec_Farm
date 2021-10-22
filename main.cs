using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animals;

namespace Farm
{

  class Farm
  {

    private static Hay hay = new Hay();

    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to my farm!");

      // Creating animals
      var animals = new List<Animal>();
      animals.Add(new Pig(1));
      animals.Add(new Pig(2));
      animals.Add(new Cow(3));
      animals.Add(new Sheep(4));
      animals.Add(new Sheep(5));
      animals.Add(new Sheep(6));
      animals.Add(new Horse(7));
      animals.Add(new Horse(8));
      PrintAnimals(ref animals);

      string clientAnswer = "";
      while (clientAnswer != "q")
      {
        PrintMenu();
        clientAnswer = Console.ReadLine().ToLower();
        switch (clientAnswer)
        {
          case "1":
            // Verify if animal(s) are resting
            if (GetNbOfRestingAnimals(ref animals) == 0)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("All animals are already eating, can't order more animals.");
              Console.ResetColor();
              break;
            }
            AssignAnimalToEatAsync(animals);
            break;

          case "2":
            // Verify if animal(s) are eating
            if (GetNbOfRestingAnimals(ref animals) == animals.Count)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("No animal eats. Assign at least one animal to eat.");
              Console.ResetColor();
              break;
            }
            AssignAnimalToStopEating(ref animals);
            break;

          case "3":
            GenerateReportAsync(hay.hayUnits, animals);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Report generated.");
            Console.ResetColor();
            break;

          case "q":
            foreach (Animal animal in animals)
            {
              animal.isEating = false;
            }
            break;

          default:
            PrintTryAgain();
            break;
        }
      }

      Console.WriteLine("Thank you for simulating :) \nGoodbye!");
      Console.ReadKey(); // Just so you see this message ^ at the end
    }

    static async void AssignAnimalToEatAsync(List<Animal> animals)
    {
      string clientAnswer = "";
      bool foundId = false;
      while (!foundId)
      {
        PrintAvailableAnimals(ref animals);
        clientAnswer = Console.ReadLine().ToLower();

        foreach (Animal animal in animals)
        {
          if (clientAnswer == animal.Id.ToString() && !animal.isEating)
          {
            foundId = true;
            animal.isEating = true;
            Console.WriteLine(animal.GetType().Name + " " + animal.Id + " is ordered to eat.");
            await hay.ConsumeHay(animal);
          }

        }

        if (!foundId)
        {
          PrintTryAgain();
        }

      }

    }

    static void AssignAnimalToStopEating(ref List<Animal> animals)
    {
      string clientAnswer = "";
      bool foundId = false;
      while (!foundId)
      {
        PrintNotAvailableAnimals(ref animals);
        clientAnswer = Console.ReadLine().ToLower();

        foreach (Animal animal in animals)
        {
          if (clientAnswer == animal.Id.ToString() && animal.isEating)
          {
            foundId = true;
            animal.isEating = false;
            Console.WriteLine(animal.GetType().Name + " " + animal.Id + " is ordered to stop eating.");
          }
        }

        if (!foundId)
        {
          PrintTryAgain();
        }

      }

    }

    static byte GetNbOfRestingAnimals(ref List<Animal> animals)
    {
      byte nbOfRestingAnimals = 0;
      foreach (Animal animal in animals)
      {
        if (!animal.isEating)
        {
          nbOfRestingAnimals++;
        }
      }
      return nbOfRestingAnimals;
    }

    static async void GenerateReportAsync(byte hayUnits, List<Animal> animals)
    {
      await Task.Run(() =>
      {
        string path = @"Rapport.txt";
        using (StreamWriter sw = File.CreateText(path))
        {
          sw.WriteLine("Hay units left: " + hayUnits);
          foreach (Animal animal in animals)
          {
            sw.WriteLine(animal.GetType().Name + " " + animal.Id + " consumed " + animal.hayConsumed);
          }
        }
      });
    }

    static void PrintAvailableAnimals(ref List<Animal> animals)
    {
      Console.WriteLine("Available animals: ");
      foreach (Animal animal in animals)
      {
        if (!animal.isEating)
        {
          Console.WriteLine(animal.GetType().Name + " " + animal.Id);
        }
      }
      Console.WriteLine("Enter the id of the desired animal:");
    }

    static void PrintNotAvailableAnimals(ref List<Animal> animals)
    {
      Console.WriteLine("NOT Available animals: ");
      foreach (Animal animal in animals)
      {
        if (animal.isEating)
        {
          Console.WriteLine(animal.GetType().Name + " " + animal.Id);
        }
      }
      Console.WriteLine("Enter the id of the desired animal:");
    }

    static void PrintAnimals(ref List<Animal> animals)
    {
      Console.WriteLine("The list of animals:");
      foreach (Animal animal in animals)
      {
        Console.WriteLine(animals.IndexOf(animal) + 1 + ". " + animal.GetType().Name + " " + animal.Id);
      }
    }

    static void PrintMenu()
    {
      Console.WriteLine("Enter 1 to order an animal to start eating.");
      Console.WriteLine("Enter 2 to order an animal to stop eating.");
      Console.WriteLine("Enter 3 to generate the report.");
      Console.WriteLine("Enter q to quit.");
    }

    static void PrintTryAgain()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Sorry, wrong entry try again.");
      Console.ResetColor();
    }

  }

}