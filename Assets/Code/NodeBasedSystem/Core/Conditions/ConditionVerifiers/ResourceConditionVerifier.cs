using System;
using Code.Progress.PlayerStorage;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.NodeBasedSystem.Core.Conditions.ConditionVerifiers
{
    [UsedImplicitly]
    public class ResourceConditionVerifier : IConditionVerifier<ResourceCondition>
    {
        private readonly ProgressContext _progressContext;

        public ResourceConditionVerifier(ProgressContext progressContext)
        {
            _progressContext = progressContext;
        }
        
        public bool CheckCondition(ResourceCondition condition)
        {
            IGroup<ProgressEntity> itemStorages = _progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.PlayerResources));

            foreach (ProgressEntity item in itemStorages)
            {
                float currentResource = condition.Resource switch
                {
                    EResource.Benzine => item.Benzine,
                    EResource.Money => item.Money,
                    EResource.Volition => item.Volition,
                    EResource.Rating => item.Rating,
                    _ => throw new ArgumentOutOfRangeException()
                };

                switch (condition.Equation)
                {
                    case EEquation.Equal:
                        return Mathf.Approximately(currentResource, condition.Amount);
                    case EEquation.Below:
                        return currentResource < condition.Amount;
                    case EEquation.More:
                        return currentResource > condition.Amount;
                }
            }
            
            return false;
        }
    }
}