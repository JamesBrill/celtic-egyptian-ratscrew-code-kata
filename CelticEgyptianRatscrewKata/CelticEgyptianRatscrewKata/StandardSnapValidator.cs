namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator : ISnapValidator
    {
        public IConsecutiveRankValidator ConsecutiveRankValidator { get; set; }

        public StandardSnapValidator(IConsecutiveRankValidator validator)
        {
            ConsecutiveRankValidator = validator;
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Standard);
        }
    }
}
