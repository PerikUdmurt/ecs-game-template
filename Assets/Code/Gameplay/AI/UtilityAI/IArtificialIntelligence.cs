namespace UtilityAi
{
    public interface IArtificialIntelligence
    {
        IAIAction MakeBestDecision(IAIActionHolder actionHolder);
    }
}