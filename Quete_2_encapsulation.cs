using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quete_2_encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            BeerEncapsulator beerproduction = new BeerEncapsulator();

            while (true)
            {

                Console.Write(" " + beerproduction.GetAvalaibleBeerVolume() + " centilitre(s) de bière disponible. Combien voulez vous ajouter de bière ? ");
                beerproduction.Addbeer(double.Parse(Console.ReadLine()));

                Console.Write(" " + beerproduction.GetAvalaibleCapsules() + " capsule(s) de bière disponible. Combien voulez vous ajouter de capsule ? ");
                beerproduction.SetAvalaibleCapsules(int.Parse(Console.ReadLine()));

                Console.Write(" " + beerproduction.GetAvalaibleBottles() + " bouteille(s) de bière disponible. Combien voulez vous ajouter de bouteille ? ");
                beerproduction.SetAvalaibleBottles(int.Parse(Console.ReadLine()));

                Console.Write(" Combien de bouteilles de bière voulez vous produire ? ");
                beerproduction.ProduceEncapsulatedBeerBottles(int.Parse(Console.ReadLine()));

            Console.Write(" Voulez vous produire d'autres boutielles ? (répondre par oui ou non) ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "oui")
            {
                continue;
            }
            else
            {
                break;
            }

        }

        Console.ReadLine();
        }
    }

    public class BeerEncapsulator
    {

        private double _avalaibleBeerVolume;
        private int _avalaibleBottles;
        private int _avalaibleCapsules;


        public int GetAvalaibleBottles()
        {
            return _avalaibleBottles;
        }

        public void SetAvalaibleBottles(int stockbottle)
        {
            _avalaibleBottles += Math.Abs(stockbottle);
        }

        public int GetAvalaibleCapsules()
        {
            return _avalaibleCapsules;
        }

        public void SetAvalaibleCapsules(int stockcapsule)
        {
            _avalaibleCapsules += Math.Abs(stockcapsule);
        }
        public double GetAvalaibleBeerVolume()
        {
            return _avalaibleBeerVolume;
        }


        public void Addbeer(double beerVolume)
        {
            if (beerVolume > 0)
            {
                _avalaibleBeerVolume += Math.Abs(beerVolume);
            }
            else
            {
                Console.WriteLine(" Vous ne pouvez pas diminuer la quantité de bière !");
            }
        }


        public void ProduceEncapsulatedBeerBottles(int makeBottle)
        {
            int BottleProduct = 0;

            while (makeBottle > BottleProduct)

            {
                if (_avalaibleBeerVolume < 33 || _avalaibleCapsules < 1 || _avalaibleBottles < 1)
                {
                    Console.WriteLine(" Vous n'avez pas assez de composants pour fabriquer vos bouteilles =( ");

                    if (_avalaibleBeerVolume < 33)
                    {
                        Console.WriteLine("   Il reste " + _avalaibleBeerVolume + " centilitres de bière");
                        Console.WriteLine(" Vous devez ajouter " + (makeBottle * 33 - _avalaibleBeerVolume) + " centilitres pour fabriquer vos bouteilles.");
                    }

                    if (_avalaibleCapsules < 1)
                    {
                        Console.WriteLine("   Il reste " + _avalaibleCapsules + "  capsule");
                        Console.WriteLine(" Vous devez ajouter " + (BottleProduct - _avalaibleCapsules) + " capsule(s) pour fabriquer vos bouteilles.");
                    }

                    if (_avalaibleBottles < 1)
                    {
                        Console.WriteLine("   Il reste " + _avalaibleBottles + "  bouteille");
                        Console.WriteLine(" Vous devez ajouter " + (BottleProduct - _avalaibleBottles) + " bouteilles(s) pour fabriquer vos bouteilles.");
                    }
                    break;
                }
                else
                {
                    _avalaibleBeerVolume = _avalaibleBeerVolume - 33;
                    Console.WriteLine("   Il reste " + _avalaibleBeerVolume + " centilitre(s) de bière.");

                    _avalaibleCapsules = _avalaibleCapsules - 1;
                    Console.WriteLine("   Il reste " + _avalaibleCapsules + " capsule(s).");

                    _avalaibleBottles = _avalaibleBottles - 1;
                    Console.WriteLine("   Il reste " + _avalaibleBottles + " bouteille(s).");

                    BottleProduct = BottleProduct + 1;

                }

            }
            Console.WriteLine();
            Console.WriteLine(" Vous avez produit " + BottleProduct + " bouteille(s) de bière.");
            Console.WriteLine();
        }

    }
}
