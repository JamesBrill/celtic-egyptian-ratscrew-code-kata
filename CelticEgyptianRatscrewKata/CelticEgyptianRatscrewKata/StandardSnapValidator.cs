namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator : ISnapValidator
    {
        public ConsecutiveRankValidator ConsecutiveRankValidator { get; set; }

        public StandardSnapValidator()
        {
            ConsecutiveRankValidator = new ConsecutiveRankValidator(ConsecutiveRankDistance.Standard);
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack);
        }
    }
}
