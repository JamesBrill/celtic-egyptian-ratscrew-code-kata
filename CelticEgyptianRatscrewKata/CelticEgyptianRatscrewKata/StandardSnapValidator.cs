namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator : ISnapValidator
    {
        public ConsecutiveRankValidator ConsecutiveRankValidator { get; set; }

        public StandardSnapValidator()
        {
            ConsecutiveRankValidator = new ConsecutiveRankValidator();
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Standard);
        }
    }
}
