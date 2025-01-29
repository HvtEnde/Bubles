using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProccesingBehaviour : MonoBehaviour
{
    public Volume volume;
    private ChromaticAberration chromatic;
    private LensDistortion lensDistortion;

    public float startValue = 0.5f;
    public float endValue = 1f;

    public float minDistortion = -0.5f;
    public float maxDistortion = 0.5f;

    public float minSpeed = 1f;
    public float maxspeed = 5f;
    private float speed = 2.5f;

    private Vector2 currentCenter;
    private Vector2 targetCenter;
    private float timeElapsed;

    private void Start()
    {
        if (volume.profile.TryGet(out chromatic))
        {
            Debug.Log("Chromatic aberration gevondenuhuhhhh");
        }
        else
        {
            Debug.LogError("Chromatic aberration niet gevonden in Volume profile idioot");
        }
        if (volume.profile.TryGet(out lensDistortion))
        {
            Debug.Log("Lens Distortion gevondenuhuhhhh");
        }
        else
        {
            Debug.LogError("Lens Distortion niet gevonden in Volume profile idioot");
        }
    }
    void Update()
    {
        SetChromaticIntensity();

        speed = Mathf.Lerp(minSpeed, maxspeed, Time.deltaTime);

        if (lensDistortion == null) return;

        currentCenter = Vector2.Lerp(currentCenter, targetCenter, speed * Time.deltaTime);

        lensDistortion.center.Override(currentCenter);

        timeElapsed += Time.deltaTime;
        if (timeElapsed > 1f)
        {
            SetRandomLensDistortionCenter();
            timeElapsed = 0f;
        }
    }
    void SetChromaticIntensity()
    {
        if (chromatic == null) return;

        float time = Time.time;
        float lerpFactor = (Mathf.Sin(time * speed) + 1f) / 2f;
        float result = Mathf.Lerp(startValue, endValue, lerpFactor);

        chromatic.intensity.value = result;
    }
    void SetRandomLensDistortionCenter()
    {
        targetCenter = new Vector2(Random.Range(minDistortion, maxDistortion), Random.Range(minDistortion, maxDistortion));

        if (lensDistortion != null)
        {
            currentCenter = lensDistortion.center.value;
        }
    }
}
