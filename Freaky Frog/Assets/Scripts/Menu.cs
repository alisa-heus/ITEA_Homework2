using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Button ExitButton;
    public Button MusicButton;
    public Button SoundButton;
    public Button LanguageButton;
    public Button FacebookButton;
    public Button DevicesButton;
    public Button AboutButton;
    public Button HelpButton;

    public TextMeshProUGUI MusicText;
    public TextMeshProUGUI SoundText;
    public TextMeshProUGUI FacebookText;

    private bool _musicOn;
    private bool _soundOn;
    private bool _facebookConnected;

    private void Start()
    {
        _soundOn = true;
        _musicOn = true;
        _facebookConnected = false;
        MusicText.text = "ON";
        SoundText.text = "ON";
        FacebookText.text = "Disconnected";
    }
    private void OnEnable()
    {
        ExitButton.onClick.AddListener(DebugInfo);
        MusicButton.onClick.AddListener(ToggleMusic);
        SoundButton.onClick.AddListener(ToggleSound);
        LanguageButton.onClick.AddListener(ChangeLanguage);
        FacebookButton.onClick.AddListener(ToggleFacebook);
        DevicesButton.onClick.AddListener(LinkDevice);
        AboutButton.onClick.AddListener(ReadAbout);
        HelpButton.onClick.AddListener(GetHelp);
    }

    private void DebugInfo()
    {
        Debug.Log("You close the menu");
    }

    private void ToggleMusic()
    {
        if(_musicOn == true)
        {
            Debug.Log("Music is OFF");
            _musicOn = false;
            MusicText.text = "OFF";
        }
        else
        {
            Debug.Log("Music is ON");
            _musicOn = true;
            MusicText.text = "ON";
        }
    }

    private void ToggleSound()
    {
        if (_soundOn == true)
        {
            Debug.Log("Sound is OFF");
            _soundOn = false;
            SoundText.text = "OFF";
        }
        else
        {
            Debug.Log("Sound is ON");
            _soundOn = true;
            SoundText.text = "ON";
        }
    }

    private void ChangeLanguage()
    {
        Debug.Log("Changes language");
    }

    private void ToggleFacebook()
    {
        if(_facebookConnected == false)
        {
            Debug.Log("You are connected to Facebook");
            _facebookConnected = true;
            FacebookText.text = "Connected";
        }
        else
        {
            Debug.Log("You are disconnected from Facebook");
            _facebookConnected = false;
            FacebookText.text = "Disconnected";
        }
    }

    private void LinkDevice()
    {
        Debug.Log("Links a device");
    }

    private void ReadAbout()
    {
        Debug.Log("This game is designed by bla-bla-bla...");
    }

    private void GetHelp()
    {
        Debug.Log("You enter the FAQ page");
    }

    private void OnDisable()
    {
        ExitButton.onClick.RemoveListener(DebugInfo);
        MusicButton.onClick.RemoveListener(ToggleMusic);
        SoundButton.onClick.RemoveListener(ToggleSound);
        LanguageButton.onClick.RemoveListener(ChangeLanguage);
        FacebookButton.onClick.RemoveListener(ToggleFacebook);
        DevicesButton.onClick.RemoveListener(LinkDevice);
        AboutButton.onClick.RemoveListener(ReadAbout);
        HelpButton.onClick.RemoveListener(GetHelp);
    }
}
