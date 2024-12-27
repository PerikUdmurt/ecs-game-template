using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UtilityAi
{
    public class UtilityAI : IArtificialIntelligence
    {
        private IEnumerable<IUtilityFunction> _utilityFunctions;
        private object _environment;    //�������������� (���� ���) ����� �� ������ ������� ���������� ������
        //� ������ ���������� ��� ��� ����������� �� ���� ��������

        public UtilityAI(object environment)
        {
            _utilityFunctions = new Brains().GetUtilityFunctions();
            _environment = environment;
        }

        public IAIAction MakeBestDecision(IAIActionHolder actionHolder)
        {
            IEnumerable<ScoredAIAction> choices = GetScoredAIAction(actionHolder);

            return choices.FindMax(c => c.Score);
        }

        //����� ��������� ���������� ��� ��������� ����������� ������ �������� �������� + ����� ��������� ��������
        private IEnumerable<ScoredAIAction> GetScoredAIAction(IAIActionHolder actionHolder)
        {
            //����� ��������� �������� ��������� ������� �� ���������
            //������ ������, �������� ���� ��������� �������� � ������ ������ ������
            IEnumerable<IAIAction> availableActions = actionHolder.GetAvailableActions();


            foreach (IAIAction action in availableActions)
            { 
                float score = CalculateScore(action, _environment);
                yield return new ScoredAIAction(score, action);
            }

        }

        private float CalculateScore(IAIAction action, object environmentForCalc)
        {
            IEnumerable<ScoreFactor> scoreFactors = 
                (from utilityFunction in _utilityFunctions
                where utilityFunction.AppliesTo(action, environmentForCalc)
                let input = utilityFunction.GetInput(action, environmentForCalc)
                let score = utilityFunction.Score(input, environmentForCalc)
                select new ScoreFactor(utilityFunction.Name, score));

            return scoreFactors.Sum(x => x.Score);
        }
    }
}