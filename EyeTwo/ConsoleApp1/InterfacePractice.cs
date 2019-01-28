using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class InterfacePractice
  {
    static void Main(string[] args)
    {
      ICanins dogs = new Newfoundland();
      dogs.Read();

      ICanins wolfs = new Wolf();

      wolfs.Read();

      IPanthera lion = new Lion();

      lion.Read();

      IPanthera tiger = new Tiger();

      tiger.Read();

      Console.WriteLine("Stop");
      Console.ReadLine();
    }//EOM

    class Newfoundland : ICanins
    {
      public void Read()
      {
        Console.WriteLine("A Newfoundland Dog is:");
        Console.WriteLine("Going to drool on your cloths.");
        Console.WriteLine("Going to shed tumble weeds of fur.");
        Console.WriteLine("Just doesn't seem to notice what dirt is.");
        Console.WriteLine("About the sweetest most loving dog in all existance.");
        Console.WriteLine("*************************************\n\n");
      }
    }

    class Wolf : ICanins
    {
      public void Read()
      {
        Console.WriteLine("A wolf is Canins Lupis it's a wild dog.");
        Console.WriteLine("Has most of the parts that your dog has at home.");
        Console.WriteLine("But not the brain, humans are to be feared by a wolf.");
        Console.WriteLine("I have played with Bear, and Big cats with little or no fear.");
        Console.WriteLine("Wolfs, because we let our guard down can kill in seconds.");
        Console.WriteLine("*************************************\n\n");
      }
    }

    class Lion : IPanthera
    {
      public void Read()
      {
        Console.WriteLine("A LION ~ Lives in Africa ~ Not the jungle");
        Console.WriteLine("Most of the time the females hunt");
        Console.WriteLine("Live in communcal groups called prides");
        Console.WriteLine("Is not REALLY the king of the cats");
        Console.WriteLine("*************************************\n\n");
      }
    }

    class Tiger : IPanthera
    {
      public void Read()
      {
        Console.WriteLine("A TIGER ~ Lives in the jungles of our world.");
        Console.WriteLine("Loves to play in water");
        Console.WriteLine("Lives alone most of the time");
        Console.WriteLine("Is truly the king of all cats, up to 600 or 700 pounds");
        Console.WriteLine("*************************************\n\n");
      }

    }


    interface ICanins
    {
      void Read();
    }

    interface IPanthera
    {
      void Read();
    }

  }//EOC
}//EONS
