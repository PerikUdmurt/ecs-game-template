using System.Collections.Generic;
using System.Text;
using Code.Gameplay.Test.UI;
using Code.UI.Core;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Test.Systems
{
    [UsedImplicitly]
    public class DebugPlayerProgressSystem : ReactiveSystem<ProgressEntity>
    {
        private readonly IUINavigator _iuiNavigator;

        public DebugPlayerProgressSystem(
            IUINavigator iuiNavigator, 
            ProgressContext context) 
            : base(context)
        {
            _iuiNavigator = iuiNavigator;
        }

        protected override ICollector<ProgressEntity> GetTrigger(IContext<ProgressEntity> context)
        {
            return context.CreateCollector(ProgressMatcher.PlayerResources);
        }

        protected override bool Filter(ProgressEntity entity) => true;

        protected override void Execute(List<ProgressEntity> entities)
        {
            StringBuilder str = new StringBuilder();
            foreach (ProgressEntity e in entities)
            {
                str.AppendLine($"Benzine:   {e.benzine.Value}");   
                str.AppendLine($"Energy:    {e.volition.Value}"); 
                str.AppendLine($"Money:     {e.money.Value}"); 
                str.AppendLine($"Rating:    {e.rating.Value}"); 
                str.AppendLine($"ProgressTokens:");
                foreach (var token in e.progressTokenStorage.Value)
                {
                    str.Append($"{token} ,");
                }
            }
            _iuiNavigator.Perform<ProgressDebuggerUIController>(c => 
                c.SetProgressText(str.ToString()));
        }
    }
}