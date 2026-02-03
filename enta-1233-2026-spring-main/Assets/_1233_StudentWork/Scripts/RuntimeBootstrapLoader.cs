using UnityEngine;


/// <summary>
/// Creates the GameGlobals object once
/// regardless of where the game it loaded from
/// </summary>
public static class RuntimeBootstrapLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    private static void Initialize()
    {
        if (GlobalsMgr.Instance)
            return;

        var prefab = Resources.Load<GameObject>("GameGlobals");
        Object.Instantiate(prefab);
    }
}
