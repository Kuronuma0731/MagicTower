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
        volumeText.text = $"���q: 100 % ";
        //
        volumSlider.onValueChanged.AddListener(SetVloume);
        buttonEvent.onClick.AddListener(ToggleCharacterMovement);
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
    //���s�ʧ@�ɦ۰����í��q
    public void ToggleVolumeControl()
    {
        volumeImage.gameObject.SetActive(volumeImage.gameObject.activeSelf);
        volumSlider.gameObject.SetActive(volumSlider.gameObject.activeSelf); // ��ܩ����í��q Slider

        if (volumeText != null)
        {
            volumeImage.gameObject.SetActive(!volumeImage.gameObject.activeSelf);
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf); // ��ܩ����í��q��ܤ奻
            volumeText.gameObject.SetActive(!volumeText.gameObject.activeSelf);

            //return;
        }

    }

    // �������s�ʧ@
    void ToggleCharacterMovement()
    {
        canMove = !canMove;
        Characters.SetCanMove(canMove);
    }
}
