using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlayer : MonoBehaviour {
    AudioSource clickSound;

    private void Start()
    {
        clickSound = GameObject.Find("ClickSound").GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {        
        clickSound.Play();
    }

    public float GetClipLenght()
    {
        return clickSound.clip.length+0.2f;
    }
}
