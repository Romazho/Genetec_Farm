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
      Console.WriteLine("The list of animals:");
      PrintAnimals(ref animals, false);

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
              Console.WriteLine("All the animals are already eating, can't order more animals.");
              Console.ResetColor();
              break;
            }
            AssignAnimalAsync(animals, true);
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
            AssignAnimalAsync(animals, false);
            //AssignAnimalToStopEating(ref animals);
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

    // Order an animal to eat => assignToEat = true,
    // Order an animal to stop eating => assignToEat = false.
    static async void AssignAnimalAsync(List<Animal> animals, bool assignToEat)
    {
      string clientAnswer = "";
      bool foundId = false;
      while (!foundId)
      {
        Console.WriteLine("Available animals: ");
        PrintAnimals(ref animals, !assignToEat);
        Console.WriteLine("Enter the id of the desired animal:");
        clientAnswer = Console.ReadLine().ToLower();

        foreach (Animal animal in animals)
        {
          if (clientAnswer == animal.Id.ToString())
          {
            if (assignToEat && !animal.isEating)
            {
              foundId = true;
              animal.isEating = true;
              Console.ForegroundColor = ConsoleColor.DarkGreen;
              Console.WriteLine(animal.GetType().Name + " " + animal.Id + " is ordered to eat.");
              Console.ResetColor();
              await hay.ConsumeHay(animal);
            }
            else if (!assignToEat && animal.isEating)
            {
              foundId = true;
              animal.isEating = false;
              Console.ForegroundColor = ConsoleColor.DarkGreen;
              Console.WriteLine(animal.GetType().Name + " " + animal.Id + " is ordered to stop eating.");
              Console.ResetColor();
            }
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

    static void PrintAnimals(ref List<Animal> animals, bool eating)
    {
      foreach (Animal animal in animals)
      {
        if (eating && animal.isEating)
        {
          Console.WriteLine(animal.GetType().Name + " " + animal.Id);
        }
        else if (!eating && !animal.isEating)
        {
          Console.WriteLine(animal.GetType().Name + " " + animal.Id);
        }
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