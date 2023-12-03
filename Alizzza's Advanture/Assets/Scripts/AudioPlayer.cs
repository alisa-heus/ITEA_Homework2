using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    

    [Header("Pickup")]

    [SerializeField] AudioClip candyClip;
    [SerializeField] [Range(0f, 1f)] float candyVolume = 0.25f;

    [Header("Enemies")]
    [SerializeField] AudioClip tvBoomClip;
    [SerializeField] [Range(0f, 1f)] float tvBoomVolume = 0.3f;

    [SerializeField] AudioClip bossBoomClip;
    [SerializeField] [Range(0f, 1f)] float bossBoomVolume = 0.3f;

    [Header("Player")]
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] [Range(0f, 1f)] float playerDeathVolume = 0.3f;

    [SerializeField] AudioClip exitClip;
    [SerializeField] [Range(0f, 1f)] float exitClipVolume = 0.3f;

    [SerializeField] AudioClip bounceClip;
    [SerializeField] [Range(0f, 1f)] float bounceClipVolume = 0.3f;

    [SerializeField] AudioClip clapClip;
    [SerializeField] [Range(0f, 1f)] float clapClipVolume = 0.5f;

    [SerializeField] AudioClip tadaClip;
    [SerializeField] [Range(0f, 1f)] float tadaClipVolume = 0.3f;

    public void PlayCandy()
    {
        if (candyClip != null)
        {
            AudioSource.PlayClipAtPoint(candyClip, Camera.main.transform.position, candyVolume);
        }
    }

    public void PlayTvBoom()
    {
        if (tvBoomClip != null)
        {
            AudioSource.PlayClipAtPoint(tvBoomClip, Camera.main.transform.position, tvBoomVolume);
        }
    }

    public void PlayBossBoom()
    {
        if (bossBoomClip != null)
        {
            AudioSource.PlayClipAtPoint(bossBoomClip, Camera.main.transform.position, bossBoomVolume);
        }
    }

    public void PlayDeath()
    {
        if (playerDeathClip!= null)
        {
            AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, playerDeathVolume);
        }
    }

    public void PlayExit()
    {
        if (exitClip != null)
        { 
            AudioSource.PlayClipAtPoint(exitClip, transform.position, exitClipVolume);
        }
    }
    public void PlayBounce()
    {
        if (bounceClip != null)
        {
            AudioSource.PlayClipAtPoint(bounceClip, Camera.main.transform.position, bounceClipVolume);
        }
    }

    public void PlayClap()
    {
        if (clapClip != null)
        {
            AudioSource.PlayClipAtPoint(clapClip, Camera.main.transform.position, clapClipVolume);
        }
    }
    public void PlayTada()
    {
        if (tadaClip != null)
        {
            AudioSource.PlayClipAtPoint(tadaClip, Camera.main.transform.position, tadaClipVolume);
            GameObject.Find("BGmusic").GetComponent<AudioSource>().Stop();
        }
    }
}
