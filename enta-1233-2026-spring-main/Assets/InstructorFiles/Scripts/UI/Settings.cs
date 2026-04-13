using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// Settings menu
/// Should include sliders and toggles for player preferences
/// Such as audio settings or accessibility settings
/// </summary>
public class Settings : MenuBase
{
    [FormerlySerializedAs("BackButton")] [SerializeField] private Button _backButton;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    private void OnEnable()
    {
        _backButton.Select();

        _masterSlider.value = AudioMgr.Instance.GlobalVolume;
        _soundSlider.value = AudioMgr.Instance.SfxVolume;
        _musicSlider.value = AudioMgr.Instance.MusicVolume;
    }

    public override GameMenus MenuType()
    {
        return GameMenus.SettingsMenu;
    }

    public void ButtonClose()
    {
        UIMgr.Instance.HideMenu(GameMenus.SettingsMenu);
        SaveUtil.Save();
    }

    public void SetMasterVolume(float volume)
    {
        Debug.Log($"Master volume = {volume}");
        AudioMgr.Instance.GlobalVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        Debug.Log($"sound volume = {volume}");
        AudioMgr.Instance.SfxVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log($"music volume = {volume}");
        AudioMgr.Instance.MusicVolume = volume;
    }
}
