using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float strength;
    [SerializeField] private float shakeTime;
    private float currentShakeTime;
    private bool isShaking;
    [SerializeField] private CinemachineVirtualCamera camera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake() {
        noise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update() {
        if (isShaking) {
            currentShakeTime -= Time.deltaTime;
            if(currentShakeTime <= 0) {
                isShaking = false;
                noise.m_AmplitudeGain = 0;
            }
        }
    }
    public void Shake(float strength) {
        currentShakeTime = shakeTime;
        isShaking = true;
        noise.m_AmplitudeGain = strength;
    }
}
