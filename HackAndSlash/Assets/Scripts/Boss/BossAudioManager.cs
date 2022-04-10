using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] step;
    [SerializeField] private AudioClip[] melee1;
    [SerializeField] private AudioClip[] melee2;
    [SerializeField] private AudioClip[] ranged;
    [SerializeField] private AudioClip[] death;

    public void Step() {
        source.clip = step[Random.Range(0, step.Length - 1)];
        source.Play();
    }

    public void Death() {
        source.clip = death[Random.Range(0, death.Length - 1)];
        source.Play();
    }

    public void Melee1() {
        source.clip = melee1[Random.Range(0, melee1.Length - 1)];
        source.Play();
    }

    public void Melee2() {
        source.clip = melee2[Random.Range(0, melee2.Length - 1)];
        source.Play();
    }

    public void Ranged() {
        source.clip = ranged[Random.Range(0, ranged.Length - 1)];
        source.Play();
    }
}
