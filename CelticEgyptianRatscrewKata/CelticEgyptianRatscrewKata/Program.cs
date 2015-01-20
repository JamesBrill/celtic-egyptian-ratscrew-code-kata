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
                new Card(Suit.Clubs, Rank.Two)
            };
            var stack = new Stack(cardsInStack);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<SnapValidatorModule>();
            var container = containerBuilder.Build();

            var snapValidators = container.Resolve<IEnumerable<ISnapValidator>>();
            foreach (var snapValidator in snapValidators.Where(snapValidator => snapValidator.IsValidSnap(stack)))
            {
                Console.WriteLine("Contains valid " + snapValidator.Name + " snap.");
            }
            Console.ReadLine();
        }
    }
}
