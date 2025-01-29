using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LensDistortionURP : MonoBehaviour
{
    public Volume volume;
    private LensDistortion lensDistortion;

    public float minDistortion = -0.5f;
    public float maxDistortion = 0.5f;
    public float speed = 2f;

    private float t = 0f;
    private bool increasing = true;

    void Start()
    {
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
        if (lensDistortion == null) return;

        
        t += (increasing ? 1 : -1) * speed * Time.deltaTime;

        if (t >= 1f)
        {
            t = 1f;
            increasing = false;
        }
        else if (t <= 0f)
        {
            t = 0f;
            increasing = true;
        }

        
        lensDistortion.intensity.value = Mathf.Lerp(minDistortion, maxDistortion, t);
    }
}
