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
        //�]�m��l���q��
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(SetVolume);

        // ��l����ܭ��q�]�i��^
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
            volumeText.text = "���q: " + Mathf.RoundToInt(volume * 100) + "%";
        }
    }

    [SerializeField]
    public void ToggleVolumeControl()
    {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf); // ��ܩ����í��q Slider
        if (volumeText != null)
        {
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // ��ܩ����í��q��ܤ奻
        }
    }

}
