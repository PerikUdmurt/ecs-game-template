namespace UtilityAi
{
    public class ScoreFactor
    {
        public ScoreFactor(string name, float score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; }
        public float Score { get; }
    }
}