
using UnityEngine;
using System.Collections;
using Cinemachine;
public class Main : MonoBehaviour
{
    [Header("Configuracion")]
    [Range(30, 120)] public int fps;
    [Range(0.1f, 1f)] public float scale;
    [Header("Dependencias del Shake")]
    [HideInInspector]public CinemachineVirtualCamera virtualCamera;
    [HideInInspector]public Vector2 amplitudeAndFrequency;
    private void Start()
    {
        Application.targetFrameRate = fps;
        Time.timeScale = scale;
    }
    //Zona General de Shake

    public void shakeNow(float time) { StartCoroutine(shake(time)); }
    private IEnumerator shake(float time)
    {
        CinemachineBasicMultiChannelPerlin chanel =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        chanel.m_AmplitudeGain = amplitudeAndFrequency.x;
        chanel.m_FrequencyGain = amplitudeAndFrequency.y;
        yield return new WaitForSecondsRealtime(time);
        chanel.m_AmplitudeGain = 0f;
        chanel.m_FrequencyGain = 0f;
    }
}
