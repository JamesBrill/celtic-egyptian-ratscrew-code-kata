namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator : ISnapValidator
    {
        public IConsecutiveRankValidator ConsecutiveRankValidator { get; set; }
        public string Name { get; private set; }

        public StandardSnapValidator(IConsecutiveRankValidator validator)
        {
            ConsecutiveRankValidator = validator;
            Name = "standard";
        }

        public bool IsValidSnap(Stack stack)
        {
            return ConsecutiveRankValidator.IsValidSnap(stack, ConsecutiveRankDistance.Standard);
        }
    }
}
