namespace CelticEgyptianRatscrewKata.Rules
{
	public interface ISnapRule
	{
		bool IsValidFor(Cards stack);
	}
}