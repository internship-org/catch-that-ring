using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Catching Gold / Ring Sound")]
    [SerializeField] AudioClip catchingSound;
    [SerializeField] [Range(0f, 1f)] float catchingVolume = 1f;

    [Header("Bad Ring / Missing Ring Sound")]
    [SerializeField] AudioClip missingSound;
    [SerializeField] [Range(0f, 1f)] float missingVolume = 1f;

    [Header("Heal Sound")]
    [SerializeField] AudioClip healSound;
    [SerializeField] [Range(0f, 1f)] float healVolume = 1f;

    [Header("Powerup Sound")]
    [SerializeField] AudioClip powerupSound;
    [SerializeField] [Range(0f, 1f)] float powerupVolume = 1f;

    public static AudioPlayer Instance { get; private set; }

    private void Awake() {
        Instance = this;  
    }

    public void PlayCatchingSound() {
        PlaySound(catchingSound, catchingVolume);
    }
    public void PlayMissingSound() {
        PlaySound(missingSound, missingVolume);
    }
    public void PlayHealSound() {
        PlaySound(healSound, healVolume);
    }
    public void PlayPowerupSound() {
        PlaySound(powerupSound, powerupVolume);
    }
    void PlaySound(AudioClip sound, float volume) {
        if(sound != null) {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(sound, cameraPosition, volume);
        }
    }
}
