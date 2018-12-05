using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [SerializeField] GameObject audioObject;
    [SerializeField] GameObject particleEffect;
    [SerializeField] Sprite[] hitSprites;

    //cached references
    AudioSource audioSource;
    Level level;
    int timesHit = 0;

    //state variables
    

    private void Start()
    {
        AddBlock();
    }

    private void AddBlock()
    {
        level = FindObjectOfType<Level>();

        if (gameObject.tag == "Breakable")
        {
            level.AddBreakableBlock();
        }
        audioSource = audioObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag=="Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        FindObjectOfType<GameSession>().AddScore();
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = (timesHit - 1);
        if(hitSprites[spriteIndex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing :" + gameObject.name);
        }
    }

    void DestroyBlock()
    {
        audioSource.Play();
        level.RemoveBreakableBlock();
        ParticleEffect();
        Destroy(gameObject);
    }

    private void ParticleEffect()
    {
        GameObject particles = Instantiate(particleEffect,transform.position,transform.rotation);
        Destroy(particles, 2f);
    }
}
