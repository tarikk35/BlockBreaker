using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject audioObject;
    [SerializeField] GameObject particleEffect;
    AudioSource audioSource;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBreakableBlock();
        audioSource = audioObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    void DestroyBlock()
    {
        audioSource.Play();
        level.RemoveBreakableBlock();
        FindObjectOfType<GameSession>().AddScore();
        ParticleEffect();
        Destroy(gameObject);
    }

    private void ParticleEffect()
    {
        GameObject particles = Instantiate(particleEffect,transform.position,transform.rotation);
        Destroy(particles, 2f);
    }
}
