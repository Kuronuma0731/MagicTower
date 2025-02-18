using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour
{
    [SerializeField] private Slider volumSlider;
    [SerializeField] private Text volumeText;
    [SerializeField] private Image volumeImage;
    [SerializeField] private Characters Characters;
    // Update is called once per frame

    private void Start()
    {
        volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
        // Set up 
        volumSlider.value = AudioListener.volume;
        volumeText.text = $"音量: 100 % ";
        //
        volumSlider.onValueChanged.AddListener(SetVloume);
    }
    public void SetVloume(float volume)
    {
        AudioListener.volume = volume;
        UpdateVolumeText(volume);
    }

    // 更新顯示音量的文字（可選）
    private void UpdateVolumeText(float volume)
    {
        if (volumeText != null)
        {
            volumeText.text = "音量: " + Mathf.RoundToInt(volume * 100) + "%";
        }
    }
    public void ToggleVolumeControl()
    {
        volumeImage.gameObject.SetActive(volumeImage.gameObject.activeSelf);
        volumSlider.gameObject.SetActive(volumSlider.gameObject.activeSelf); // 顯示或隱藏音量 Slider
        
        //Characters.SetCanMove(true);
        if (volumeText != null)
        {
            volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // 顯示或隱藏音量顯示文本
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf);
            //  Characters.SetCanMove(false);
            //return;
        }

    }
}
