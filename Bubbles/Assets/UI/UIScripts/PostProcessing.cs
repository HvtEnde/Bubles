using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class NewBehaviourScript : MonoBehaviour
{
    public Volume postProcessing;
    public LensDistortion distortion;


    public float minDistortion = -50f;
    public float maxDistortion = 50f;
    public float speed = 2f;

}
