using System;
using System.IO;
using System.Collections.Generic;
using Animals;
  
namespace Farm {
      
  class Farm {

    private static byte hayUnits = 100;
    private const byte NB_OF_ANIMALS = 8;
        
    static void Main(string[] args) {
          
      Console.WriteLine("Welcome to my farm!");
      
      // Creating animals
      List<Animal> animals = new List<Animal>();
      animals.Add(new Pig(1));
      animals.Add(new Pig(2));
      printAnimals(ref animals);

      string clientAnswer = "";
      while (clientAnswer != "q"){
        printMenu();
        clientAnswer = Console.ReadLine().ToLower();
        switch (clientAnswer)
        {
          case "1":
            assignAnimalToEat(ref animals);
            break;

          case "2":
            //verify if animals are eating
            Console.WriteLine("Enter the id of the desired animal:");
            break;

          case "3":
            //TODO with async
            generateReport(ref hayUnits, ref animals);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Report generated.");
            Console.ResetColor();
            break;

          case "q":
            break;

          default:
            printTryAgain();
            break;
        }
      }
      
      Console.WriteLine("Thank you for simulating :) \nGoodbye!");
      Console.ReadKey(); //just so you see this message ^ at the end

    }

    static void assignAnimalToEat(ref List<Animal> animals){
      
      byte nbOfRestingAnimals = 0;
      foreach (Animal animal in animals){
        if (!animal.isEating){
          nbOfRestingAnimals++;
        }
      }  

      if (nbOfRestingAnimals == 0){
        Console.WriteLine("All animals are already eating, can't order more animals.");
        return;
      }

      string clientAnswer = "";
      bool foundId = false;
      while (!foundId){
        printAvailableAnimals(ref animals);
        clientAnswer = Console.ReadLine().ToLower();

        foreach (Animal animal in animals){
          if (clientAnswer == animal.Id.ToString()){
            foundId = true;
            animal.isEating = true;
            Console.WriteLine(animal.GetType().Name + " " + animal.Id + " is ordered to eat.");
            //TODO make animal.Eat();
            break;
          }
         }

        if (!foundId){
          printTryAgain();
        }

      }
      
    }

    static void printAvailableAnimals(ref List<Animal> animals){
      Console.WriteLine("Available animals: ");
      foreach (Animal animal in animals){
        if (!animal.isEating){
          Console.WriteLine(animal.GetType().Name + " " + animal.Id);
        }
      }
      Console.WriteLine("Enter the id of the desired animal:");
    }

    static void printAnimals(ref List<Animal> animals){
      Console.WriteLine("The list of animals:");
      foreach (Animal animal in animals){
        Console.WriteLine(animals.IndexOf(animal) + 1 + ". " + animal.GetType().Name + " " + animal.Id);
      }
    }

    static void generateReport(ref byte hayUnits, ref List<Animal> animals){
      string path = @"Rapport.txt";
      using (StreamWriter sw = File.CreateText(path)){
        sw.WriteLine("Hay units left: " + hayUnits);
        foreach (Animal animal in animals){
          sw.WriteLine(animal.GetType().Name + " " + animal.Id + " consumed " + animal.hayConsumed);
        }
      }
    }

    static void printMenu(){
      Console.WriteLine("Enter 1 to order an animal to start eating.");
      Console.WriteLine("Enter 2 to order an animal to stop eating.");
      Console.WriteLine("Enter 3 to generate the report.");
      Console.WriteLine("Enter q to quit.");
    }

    static void printTryAgain(){
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Sorry, wrong entry try again.");
      Console.ResetColor();
    }

  }

}