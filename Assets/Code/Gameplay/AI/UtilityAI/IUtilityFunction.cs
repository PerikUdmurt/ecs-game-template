using System;

namespace UtilityAi
{
    public interface IUtilityFunction
    {
        string Name { get; }

        bool AppliesTo(IAIAction action, object environmentForCalc);
        float GetInput(IAIAction action, object environmentForCalc);
        float Score(float input, object environmentForCalc);
    }

    public class UtilityFunction : IUtilityFunction
    {
        private readonly Func<IAIAction, object, bool> _appliesTo;
        private readonly Func<IAIAction, object, float> _getInput;
        private readonly Func<float, object, float> _score;

        public UtilityFunction(
            Func<IAIAction, object, bool> appliesTo,
            Func<IAIAction, object, float> getInput,
            Func<float, object, float> score,   
            string name
            )
        {
            _appliesTo = appliesTo;
            _getInput = getInput;
            _score = score;
            Name = name;
        }

        public string Name { get; }

        public bool AppliesTo(IAIAction action, object environmentForCalc) =>
            _appliesTo(action, environmentForCalc);


        public float GetInput(IAIAction action, object environmentForCalc) =>
            _getInput(action, environmentForCalc);

        public float Score(float input, object environmentForCalc) =>
            _score(input, environmentForCalc);
    }
}