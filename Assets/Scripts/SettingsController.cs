using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

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
}
