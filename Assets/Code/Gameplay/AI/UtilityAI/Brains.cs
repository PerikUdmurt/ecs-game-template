using System;
using System.Collections.Generic;
using UtilityAi.Convolution;

namespace UtilityAi
{
    public class Brains
    {
        private Convolutions _convolutions = new Convolutions()
        {
            
        };

        internal IEnumerable<IUtilityFunction> GetUtilityFunctions()
        {
            return null;
        }
    }


}

namespace UtilityAi.Convolution
{
    public class Convolutions : List<UtilityFunction>
    {
        public void Add(
            Func<IAIAction, object, bool> appliesTo,
            Func<IAIAction, object, float> getInput,
            Func<float, object, float> score,
            string name)
        {
            Add(new UtilityFunction(appliesTo, getInput, score, name));
        }
    }

    public static class When
    {
        public static object SkillIsDamage { get; internal set; }
    }

    public static class GetInput
    {
        internal static object PercentageDamage;
    }

    public static class Score
    {
     
    }
}