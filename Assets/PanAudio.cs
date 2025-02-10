using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PanAudio : MonoBehaviour
{
    public AudioSource audioSource;  // 音源
    public Text volumeText;          // 顯示音量的 UI (可選)
    private float panValue = 0f;      // 立體聲平衡 (-1 = 左, 1 = 右)
    public Slider volumeSlider;

    private float volume = 0.1f;      // 預設音量
    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        //audioSource.panStereo = panValue; // 設定初始音場
        //audioSource.Play();  // 播放音樂

        //UpdateVolumeText();
        //
        //if (volumeSlider != null)
        //{
        //    volumeSlider.value = volume;
        //    volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        //}
    }
    //
    //在 Unity 的 AudioSource 組件中，你可以使用 音效效果（Effects） 來改變聲音的表現，例如 回音（Reverb）、3D 環繞音效、濾波（Low Pass/High Pass） 等。這些效果可以大幅提升遊戲的音效體驗。

    //AudioSource 主要效果
    //在 Unity AudioSource 組件中，你可以調整以下參數來影響音效：
    //
    //參數 作用
    //Volume 控制音量（0.0 ~ 1.0）
    //Pitch 控制音調（1.0 為正常，0.5 為低音，2.0 為高音）
    //Pan Stereo  控制左右聲道（-1.0 = 左聲道，1.0 = 右聲道）
    //Spatial Blend   控制 2D/3D 聲音混合（0 = 2D，1 = 3D）
    //Reverb Zone Mix 設定混響（Reverb）的強度
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            volume += volume * 0.1f; // 每次滾動改變 10% 音量
            volume = Mathf.Clamp(volume, 0f, 1f); // 限制在 0~1 之間
            audioSource.volume = volume;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            volume += volume * -0.1f; // 每次滾動改變 10% 音量
            volume = Mathf.Clamp(volume, 0f, 1f); // 限制在 0~1 之間
            audioSource.volume = volume;
        }

    }
    void UpdateVolumeText()
    {
        if (volumeText != null)
        {
            volumeText.text = "音量: " + Mathf.Round(volume * 100) + "%";
        }
    }
    void ChangeVolume()
    {
        volume = volumeSlider.value;
        audioSource.volume = volume;
        UpdateVolumeText();
    }
}
