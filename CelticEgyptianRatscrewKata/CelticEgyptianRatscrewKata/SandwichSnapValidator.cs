namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnapValidator : ISnapValidator
    {
        public IConsecutiveRankValidator ConsecutiveRankValidator { get; set; }

        public SandwichSnapValidator(IConsecutiveRankValidator validator)
        {
            ConsecutiveRankValidator = validator;
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Sandwich);
        }
    }
}