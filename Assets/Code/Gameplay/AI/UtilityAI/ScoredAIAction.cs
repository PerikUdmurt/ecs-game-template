namespace UtilityAi
{
    public class ScoredAIAction : IAIAction
    {
        private float _score;
        private IAIAction _action;

        public ScoredAIAction(float score, IAIAction action)
        {
            _score = score;
            _action = action;
        }

        public float Score { get => _score; }
    }
}