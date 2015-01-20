namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnapValidator : ISnapValidator
    {
        public ConsecutiveRankValidator ConsecutiveRankValidator { get; set; }

        public SandwichSnapValidator()
        {
            ConsecutiveRankValidator = new ConsecutiveRankValidator();
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Sandwich);
        }
    }
}