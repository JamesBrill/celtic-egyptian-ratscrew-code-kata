namespace CelticEgyptianRatscrewKata
{
    public interface IConsecutiveRankValidator
    {
        bool IsValidSnap(Stack stack, int distanceBetweenConsecutiveRanks);
    }
}