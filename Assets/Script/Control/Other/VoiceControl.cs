using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeText;
    void Start()
    {
        //設置初始音量值
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(SetVolume);

        // 初始化顯示音量（可選）
        UpdateVolumeText(volumeSlider.value);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        UpdateVolumeText(volume);
    }
    private void UpdateVolumeText(float volume)
    {
        if (volumeText != null)
        {
            volumeText.text = "音量: " + Mathf.RoundToInt(volume * 100) + "%";
        }
    }

    [SerializeField]
    public void ToggleVolumeControl()
    {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf); // 顯示或隱藏音量 Slider
        if (volumeText != null)
        {
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // 顯示或隱藏音量顯示文本
        }
    }

}
