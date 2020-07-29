using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private const float defaultVolume = 0.5f;
    private const float defaultDifficulty = 1f;

    public enum SettingKeys
    {
        Volume,
        Difficulty
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume(float value)
    {
        PlayerPrefs.SetFloat($"{SettingKeys.Volume}", value);

        var result = PlayerPrefs.GetFloat($"{SettingKeys.Volume}");
        Debug.Log($"volume set to {result}");
    }

    public void UpdateDifficulty(float value)
    {
        PlayerPrefs.SetFloat($"{SettingKeys.Difficulty}", value);
        var result = PlayerPrefs.GetFloat($"{SettingKeys.Difficulty}");
        Debug.Log($"Difficulty set to {result}");
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat($"{SettingKeys.Volume}", defaultVolume);
    }
    public float GetDifficulty()
    {
        return PlayerPrefs.GetFloat($"{SettingKeys.Difficulty}", defaultDifficulty);
    }
}
