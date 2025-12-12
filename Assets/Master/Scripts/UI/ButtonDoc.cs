using System.Collections.Generic;
using Michsky.MUIP;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoc : MonoBehaviour
{
    [SerializeField] private Image m_DefaultSoundImage;
    [SerializeField] private Image m_PauseImage;
    [SerializeField] private Button m_SoundDocButton;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private List<AudioClip> m_ListAudioClip;
    [SerializeField] private CustomDropdown m_DropDownVoice;
    private bool isSoundOn = true;

    private void OnEnable() => ResetButtonDocState();
    private void Start()
    {
        m_SoundDocButton.onClick.AddListener(ToggleSoundIcon);
        if (m_DropDownVoice != null) m_DropDownVoice.onValueChanged.AddListener(OnChangeVoice);
        ResetButtonDocState();
    }
   
    private void OnChangeVoice(int index)
    {
        VoiceDropDownList.CurrentVoiceIndex = index;
        
    }
    private void ToggleSoundIcon()
    {
        Debug.Log("PlaySound");
        isSoundOn = !isSoundOn;
        if (!isSoundOn)
        {
            m_AudioSource.clip = m_ListAudioClip[VoiceDropDownList.CurrentVoiceIndex];
            m_AudioSource.Play();
        }
        else m_AudioSource.Pause();
       
        UpdateUI();
    }

    private void UpdateUI()
    {
        m_DefaultSoundImage.gameObject.SetActive(isSoundOn);
        m_PauseImage.gameObject.SetActive(!isSoundOn);
    }
    private void ResetButtonDocState()
    {
        isSoundOn = true;
        UpdateUI();
    }
}
