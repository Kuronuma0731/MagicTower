using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PanAudio : MonoBehaviour
{
    public AudioSource audioSource;  // ����
    public Text volumeText;          // ��ܭ��q�� UI (�i��)
    private float panValue = 0f;      // �����n���� (-1 = ��, 1 = �k)
    public Slider volumeSlider;

    private float volume = 0.1f;      // �w�]���q
    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        //audioSource.panStereo = panValue; // �]�w��l����
        //audioSource.Play();  // ���񭵼�

        //UpdateVolumeText();
        //
        //if (volumeSlider != null)
        //{
        //    volumeSlider.value = volume;
        //    volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        //}
    }
    //
    //�b Unity �� AudioSource �ե󤤡A�A�i�H�ϥ� ���ĮĪG�]Effects�^ �ӧ����n������{�A�Ҧp �^���]Reverb�^�B3D ��¶���ġB�o�i�]Low Pass/High Pass�^ ���C�o�ǮĪG�i�H�j�T���ɹC������������C

    //AudioSource �D�n�ĪG
    //�b Unity AudioSource �ե󤤡A�A�i�H�վ�H�U�ѼƨӼv�T���ġG
    //
    //�Ѽ� �@��
    //Volume ����q�]0.0 ~ 1.0�^
    //Pitch ����ա]1.0 �����`�A0.5 ���C���A2.0 �������^
    //Pan Stereo  ����k�n�D�]-1.0 = ���n�D�A1.0 = �k�n�D�^
    //Spatial Blend   ���� 2D/3D �n���V�X�]0 = 2D�A1 = 3D�^
    //Reverb Zone Mix �]�w�V�T�]Reverb�^���j��
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            volume += volume * 0.1f; // �C���u�ʧ��� 10% ���q
            volume = Mathf.Clamp(volume, 0f, 1f); // ����b 0~1 ����
            audioSource.volume = volume;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            volume += volume * -0.1f; // �C���u�ʧ��� 10% ���q
            volume = Mathf.Clamp(volume, 0f, 1f); // ����b 0~1 ����
            audioSource.volume = volume;
        }

    }
    void UpdateVolumeText()
    {
        if (volumeText != null)
        {
            volumeText.text = "���q: " + Mathf.Round(volume * 100) + "%";
        }
    }
    void ChangeVolume()
    {
        volume = volumeSlider.value;
        audioSource.volume = volume;
        UpdateVolumeText();
    }
}
