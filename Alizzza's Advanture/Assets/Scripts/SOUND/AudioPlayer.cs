using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioPlayer : MonoBehaviour
{
    [Header("Pickup")]
    [FormerlySerializedAs("candyClip")]
    [SerializeField] AudioClip _candyClip;
    [FormerlySerializedAs("candyVolume")]
    [SerializeField] [Range(0f, 1f)] float _candyVolume = 0.25f;

    [Header("Enemies")]
    [FormerlySerializedAs("tvBoomClip")]
    [SerializeField] AudioClip _tvBoomClip;
    [FormerlySerializedAs("tvBoomVolume")]
    [SerializeField] [Range(0f, 1f)] float _tvBoomVolume = 0.3f;

    [FormerlySerializedAs("bossBoomClip")]
    [SerializeField] AudioClip _bossBoomClip;
    [FormerlySerializedAs("bossBoomVolume")]
    [SerializeField] [Range(0f, 1f)] float _bossBoomVolume = 0.3f;

    [Header("Player")]
    [FormerlySerializedAs("playerDeathClip")]
    [SerializeField] AudioClip _playerDeathClip;
    [FormerlySerializedAs("playerDeathVolume")]
    [SerializeField] [Range(0f, 1f)] float _playerDeathVolume = 0.3f;

    [FormerlySerializedAs("exitClip")]
    [SerializeField] AudioClip _exitClip;
    [FormerlySerializedAs("exitClipVolume")]
    [SerializeField] [Range(0f, 1f)] float _exitClipVolume = 0.3f;

    [FormerlySerializedAs("bounceClip")]
    [SerializeField] AudioClip _bounceClip;
    [FormerlySerializedAs("bounceClipVolume")]
    [SerializeField] [Range(0f, 1f)] float _bounceClipVolume = 0.3f;

    [FormerlySerializedAs("clapClip")]
    [SerializeField] AudioClip _clapClip;
    [FormerlySerializedAs("clapClipVolume")]
    [SerializeField] [Range(0f, 1f)] float _clapClipVolume = 0.5f;

    [FormerlySerializedAs("tadaClip")]
    [SerializeField] AudioClip tadaClip;
    [FormerlySerializedAs("tadaClipVolume")]
    [SerializeField] [Range(0f, 1f)] float _tadaClipVolume = 0.3f;

    public void PlayCandy()
    {
        if (_candyClip != null)
        {
            AudioSource.PlayClipAtPoint(_candyClip, Camera.main.transform.position, _candyVolume);
        }
    }
    public void PlayTvBoom()
    {
        if (_tvBoomClip != null)
        {
            AudioSource.PlayClipAtPoint(_tvBoomClip, Camera.main.transform.position, _tvBoomVolume);
        }
    }

    public void PlayBossBoom()
    {
        if (_bossBoomClip != null)
        {
            AudioSource.PlayClipAtPoint(_bossBoomClip, Camera.main.transform.position, _bossBoomVolume);
        }
    }

    public void PlayDeath()
    {
        if (_playerDeathClip!= null)
        {
            AudioSource.PlayClipAtPoint(_playerDeathClip, Camera.main.transform.position, _playerDeathVolume);
        }
    }

    public void PlayExit()
    {
        if (_exitClip != null)
        { 
            AudioSource.PlayClipAtPoint(_exitClip, transform.position, _exitClipVolume);
        }
    }
    public void PlayBounce()
    {
        if (_bounceClip != null)
        {
            AudioSource.PlayClipAtPoint(_bounceClip, Camera.main.transform.position, _bounceClipVolume);
        }
    }

    public void PlayClap()
    {
        if (_clapClip != null)
        {
            AudioSource.PlayClipAtPoint(_clapClip, Camera.main.transform.position, _clapClipVolume);
        }
    }
    public void PlayTada()
    {
        if (tadaClip != null)
        {
            AudioSource.PlayClipAtPoint(tadaClip, Camera.main.transform.position, _tadaClipVolume);
            GameObject.Find("BGmusic").GetComponent<AudioSource>().Stop();
        }
    }
}
