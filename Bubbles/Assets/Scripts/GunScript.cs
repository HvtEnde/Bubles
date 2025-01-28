using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public WaitForIntro waitForintroScript;

    void Update()
    {
        if (waitForintroScript.canPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootGun();
            }
        }
    }
    void ShootGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "bubble")
            {
                hit.transform.GetComponent<BubbleScript>().BubbleDoDamage(1f);
            }
        }
    }
}
