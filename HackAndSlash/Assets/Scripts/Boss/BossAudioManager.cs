using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource stepSource;
    [SerializeField] private AudioClip[] step;
    [SerializeField] private AudioClip[] melee1;
    [SerializeField] private AudioClip[] melee2;
    [SerializeField] private AudioClip[] ranged;
    [SerializeField] private AudioClip[] death;

    public void Step() {
        stepSource.PlayOneShot(step[Random.Range(0, step.Length - 1)]);
    }

    public void Death() {
        source.PlayOneShot(death[Random.Range(0, death.Length - 1)]);
    }

    public void Melee1() {
        source.PlayOneShot(melee1[Random.Range(0, melee1.Length - 1)]);
    }

    public void Melee2() {
        source.PlayOneShot(melee2[Random.Range(0, melee2.Length - 1)]);
    }

    public void Ranged() {
        source.PlayOneShot(ranged[Random.Range(0, ranged.Length - 1)]);
    }
}
