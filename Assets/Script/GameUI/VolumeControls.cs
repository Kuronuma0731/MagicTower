using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour
{
    [SerializeField] private Slider volumSlider;
    [SerializeField] private Text volumeText;
    [SerializeField] private Image volumeImage;
    [SerializeField] private Characters Characters;
    [SerializeField] private Button buttonEvent;

    private bool canMove = true;
    // Update is called once per frame

    private void Start()
    {
        volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
        // Set up 
        volumSlider.value = AudioListener.volume;
        volumeText.text = $"音量: 100 % ";
        //
        volumSlider.onValueChanged.AddListener(SetVloume);
        buttonEvent.onClick.AddListener(ToggleCharacterMovement);
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
    //按鈕動作時自動隱藏音量
    public void ToggleVolumeControl()
    {
        volumeImage.gameObject.SetActive(volumeImage.gameObject.activeSelf);
        volumSlider.gameObject.SetActive(volumSlider.gameObject.activeSelf); // 顯示或隱藏音量 Slider

        if (volumeText != null)
        {
            volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // 顯示或隱藏音量顯示文本
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf);

            //return;
        }

    }

    // 偵測按鈕動作
    void ToggleCharacterMovement()
    {
        canMove = !canMove;
        Characters.SetCanMove(canMove);
    }
}
