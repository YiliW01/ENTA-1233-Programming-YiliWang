/// <summary>
/// Game over screen
/// Allows for quitting or retrying
/// </summary>
public class GameComplete : MenuBase
{
    public override GameMenus MenuType()
    {
        return GameMenus.GameCompleteMenu;
    }

    public void ButtonMainMenu()
    {
        SceneMgr.Instance.LoadScene(GameScenes.MainMenu, GameMenus.MainMenu);
    }
}
