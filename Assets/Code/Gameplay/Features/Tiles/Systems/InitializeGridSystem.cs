using Code.Common.Entity;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class InitializeGridSystem : IInitializeSystem
    {
        private const string GridTag = "Grid";
        
        public void Initialize()
        {
            GameObject gridObject = GameObject.FindGameObjectWithTag(GridTag);

            Grid grid = gridObject.GetComponent<Grid>();

            CreateEntity.Empty()
                .AddGrid(grid)
                .AddGridSize(new Vector2Int(16,16));
        }
    }
}