using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayTimeLineOnTrigger : MonoBehaviour
{
    bool played;
    public PlayableDirector timeLine;
    [SerializeField] private PlayableDirector activatedTimeline;
    [SerializeField] private string key;
    [SerializeField] private int trackIndex;
    private TimelineAsset activatedAsset;

    private void Awake() {
        activatedAsset = (TimelineAsset)activatedTimeline.playableAsset;
        DataManagement.SetKey(key, false);
    }

    private void Update() {
        if (activatedTimeline.time >= activatedTimeline.duration) {
            DataManagement.SetKey(key, true);
        }
        if (DataManagement.GetKey(key)) {
            MuteTrack(trackIndex);
            PlayTimeLine();
        }
        else {
            UnmuteTrack(trackIndex);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayTimeLine();
    }

    private void PlayTimeLine() {
        if (played) {
            return;
        }
        played = true;
        timeLine.Play();
    }

    private void MuteTrack(int index) {
        TrackAsset track = activatedAsset.GetOutputTrack(index);
        track.muted = true;
    }

    private void UnmuteTrack(int index) {
        TrackAsset track = activatedAsset.GetOutputTrack(index);
        track.muted = false;
    }
}
