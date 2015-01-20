namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnapValidator : ISnapValidator
    {
        public IConsecutiveRankValidator ConsecutiveRankValidator { get; set; }
        public string Name { get; private set; }

        public SandwichSnapValidator(IConsecutiveRankValidator validator)
        {
            ConsecutiveRankValidator = validator;
            Name = "sandwich";
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Sandwich);
        }
    }
}