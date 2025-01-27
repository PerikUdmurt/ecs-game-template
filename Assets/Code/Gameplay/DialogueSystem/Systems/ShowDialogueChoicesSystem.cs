using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.NodeBasedSystem.Core.Conditions;
using Code.Services.LocalizationServices;
using Code.UI.Core;
using Cysharp.Threading.Tasks;
using Entitas;
using JetBrains.Annotations;
using NodeBasedSystem.Nodes;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class ShowDialogueChoicesSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IUINavigator _uINavigator;
        private readonly ILocalizationService _localizationService;
        private readonly INodeConditionVerifyService _verifier;

        public ShowDialogueChoicesSystem(
            NodeSystemContext context, 
            IUINavigator uINavigator, 
            ILocalizationService localizationService, 
            INodeConditionVerifyService verifier) 
            : base(context)
        {
            _uINavigator = uINavigator;
            _localizationService = localizationService;
            _verifier = verifier;
        }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.isPlaying
                && entity.node.Value == ENodeType.Choices
                && entity.hasNextChoices
                && entity.hasGraphID;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var entity in entities)
            {
                List<ChoiceNodeLink> choicesLinks = entity.NextChoices;
                string graphID = entity.graphID.Value;

                List<NextChoiceData> nextChoices = new List<NextChoiceData>();
                
                foreach (var choice in choicesLinks)
                {
                    if (!_verifier.Check(choice.Conditions.ToArray()))
                        continue;
                    
                    NextChoiceData nextChoice = new NextChoiceData()
                    {
                        text = _localizationService.GetLocalizedString(choice.ChoiceLocalizedStringData),
                        nextNodeId = choice.NodeId,
                        nodePlayerId = graphID
                    };    
                    nextChoices.Add(nextChoice);
                }
                
                _uINavigator.Show<DialogueScreenController>(controller => 
                    controller.ShowChoices(nextChoices).Forget());
            }
        }
    }
}