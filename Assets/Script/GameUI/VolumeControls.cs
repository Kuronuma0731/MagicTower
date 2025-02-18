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
        volumeText.text = $"���q: 100 % ";
        //
        volumSlider.onValueChanged.AddListener(SetVloume);
    }
    public void SetVloume(float volume)
    {
        AudioListener.volume = volume;
        UpdateVolumeText(volume);
    }

    // ��s��ܭ��q����r�]�i��^
    private void UpdateVolumeText(float volume)
    {
        if (volumeText != null)
        {
            volumeText.text = "���q: " + Mathf.RoundToInt(volume * 100) + "%";
        }
    }
    public void ToggleVolumeControl()
    {
        volumeImage.gameObject.SetActive(volumeImage.gameObject.activeSelf);
        volumSlider.gameObject.SetActive(volumSlider.gameObject.activeSelf); // ��ܩ����í��q Slider
        
        //Characters.SetCanMove(true);
        if (volumeText != null)
        {
            volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // ��ܩ����í��q��ܤ奻
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf);
            //  Characters.SetCanMove(false);
            //return;
        }

    }
}
