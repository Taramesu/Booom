using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerSettingsManager : Singleton2Manager<PlayerSettingsManager>
{
    public bool fullScreen;
    public float masterVolume;
    public float musicVolume;
    public float soundEffectsVolume;

    const string SETTINGS_DATA_KEY = "SettingsData";

    class SettingsData
    {
        public bool fullScreen;
        public float masterVolume;
        public float musicVolume;
        public float soundEffectsVolume;
    }

    public void Save()
    {
        var settingsData = new SettingsData();

        settingsData.fullScreen = fullScreen;
        settingsData.masterVolume = masterVolume;
        settingsData.musicVolume = musicVolume;
        settingsData.soundEffectsVolume = soundEffectsVolume;

        SaveSystem.Instance.SaveByPlayerPrefs(SETTINGS_DATA_KEY, settingsData);
    }

    public void Load() 
    {
        var json = SaveSystem.Instance.LoadFromPlayerPrefs(SETTINGS_DATA_KEY);
        var settingsData = JsonUtility.FromJson<SettingsData>(json);

        fullScreen = settingsData.fullScreen;
        masterVolume = settingsData.masterVolume;
        musicVolume = settingsData.musicVolume;
        soundEffectsVolume = settingsData.soundEffectsVolume;
    }

}
