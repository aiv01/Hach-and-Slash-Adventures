using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeLineOnTrigger : MonoBehaviour
{
    bool played;
    public PlayableDirector timeLine;
    [SerializeField] private string key;

    private void Awake() {
        DataManagement.SetKey(key, false);
    }

    private void Update() {
        if (DataManagement.GetKey(key)) {
            PlayTimeLine();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayTimeLine();
        DataManagement.SetKey(key, true);
    }

    private void PlayTimeLine() {
        if (played) {
            return;
        }
        played = true;
        timeLine.Play();
    }
}
