using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayTimeLineOnTrigger : MonoBehaviour
{
    bool played;
    public PlayableDirector timeLine;

    private void OnTriggerEnter(Collider other)
    {
        if (played)
        {
            return;
        }
        played = true;
        timeLine.Play();
    }
}
