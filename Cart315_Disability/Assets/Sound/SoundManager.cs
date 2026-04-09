using UnityEngine;
using System.Collections.Generic;
public enum SoundType

{
Walk1,
Walk2,
Jump,
Click,
Interact,
Dialogue
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    
    }

    private void Start()
    {
    audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public static void PlaySound(SoundType sound, float volume = 1)
    {
    
    instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);

    }
}
