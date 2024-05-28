using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource DriveM;
    [SerializeField] AudioSource StartSound;
    [SerializeField] AudioSource KenSound;
    [SerializeField] AudioSource KenMusic;
    [SerializeField] AudioSource LaLaSound;
    [SerializeField] AudioSource LaLaMusic;

    public static bool TimeToPlay;
    private bool TimeToSLeep = false;
    // Start is called before the first frame update
    void Start()
    {
        DriveM.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var timeSinceStart = Time.time;
        
        if (timeSinceStart > 22)
        {
            TimeToSLeep = true;
        }

        if (TimeToSLeep && DriveM.volume > 0)
        {
            DriveM.volume -= 0.0005f;
        }

        if (TimeToPlay)
        {
            StartSound.enabled = true;
            StartSound.Play();
            TimeToPlay = false;
            
            if (move.skin == "Ken")
            {
                KenMusic.enabled = true;
                KenMusic.Play();
            }

            if (move.skin == "LaLaLand")
            {
                LaLaMusic.enabled = true;
                LaLaMusic.Play();
            }
        }


        if (move.skin == "Ken" && Arrows.SkinIsChange)
        {
            KenSound.enabled = true;
            KenSound.Play();
            Arrows.SkinIsChange = false;
        }

        if (move.skin == "LaLaLand" && Arrows.SkinIsChange)
        {
            LaLaSound.enabled = true;
            LaLaSound.Play();
            Arrows.SkinIsChange = false;
        }
    }
}
