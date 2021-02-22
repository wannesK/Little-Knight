using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static AudioClip jump, sword, swordImpact, coin, characterHurt, button;
    private static AudioSource audioSource;
    void Start()
    {
        jump = Resources.Load<AudioClip>("Jump");
        sword = Resources.Load<AudioClip>("Sword");
        swordImpact = Resources.Load<AudioClip>("SwordImpact");
        coin = Resources.Load<AudioClip>("Coin");
        characterHurt = Resources.Load<AudioClip>("CharacterHurt");
        button = Resources.Load<AudioClip>("ButtonClick");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSource.PlayOneShot(jump);
                break;
            case "Sword":
                audioSource.PlayOneShot(sword);
                break;
            case "SwordImpact":
                audioSource.PlayOneShot(swordImpact);
                break;
            case "Coin":
                audioSource.PlayOneShot(coin);
                break;
            case "CharacterHurt":
                audioSource.PlayOneShot(characterHurt);
                break;
            case "ButtonClick":
                audioSource.PlayOneShot(button);
                break;
            default:
                break;
        }
    }
    public void ButtonSound()
    {
        PlaySound("ButtonClick");
    }
}
