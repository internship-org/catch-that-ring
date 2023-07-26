using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera stableCamera;

    [SerializeField]
    CinemachineVirtualCamera deathCamera;

    [SerializeField]
    float shakeIntensity = 1f;

    [SerializeField]
    float shakeTime = 0.2f;

    float timer = 0f;

    CinemachineBasicMultiChannelPerlin _noise;

    private void Awake() { }

    private void Start()
    {
        SetStopShakeSettings();
    }

    public void SwitchToDeathCamera()
    {
        stableCamera.enabled = false;
        deathCamera.enabled = true;
    }

    public void ShakeCamera()
    {
        _noise = stableCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
        StartCoroutine(StopShake());
    }

    IEnumerator StopShake()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        SetStopShakeSettings();
    }

    void SetStopShakeSettings()
    {
        _noise = stableCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = 0f;
        timer = 0f;
    }
}
