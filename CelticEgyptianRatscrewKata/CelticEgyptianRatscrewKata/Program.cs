using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace CelticEgyptianRatscrewKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<SnapValidatorModule>();
            var container = containerBuilder.Build();

            var snapValidators = container.Resolve<IEnumerable<ISnapValidator>>();
            var isValid = false;
            foreach (var snapValidator in snapValidators)
            {
                if (snapValidator.IsValidSnap(stack))
                {
                    isValid = true;
                    break;
                }
            }
            Console.WriteLine(isValid);
            Console.ReadLine();
        }
    }
}
