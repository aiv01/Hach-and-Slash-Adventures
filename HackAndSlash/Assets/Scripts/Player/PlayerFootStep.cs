using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{
    public AudioSource audioFootPlayer;
    public AudioClip footStep;

    private void PlayStep()
    {
        audioFootPlayer.clip = footStep;
        audioFootPlayer.Play();
    }
}
