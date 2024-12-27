using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateEntity
{
    public static GameEntity Empty() =>
        Contexts.sharedInstance.game.CreateEntity();
}

public static class CreateProgressEntity
{
    public static ProgressEntity Empty() =>
        Contexts.sharedInstance.progress.CreateEntity();
}
