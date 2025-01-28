using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public float minimumSize;
    public float maximumSize;

    float health = 1f;
    private void Start()
    {
        float randomizer = Random.Range(1f, 3f);
        transform.localScale = new Vector3(randomizer, randomizer, randomizer);
    }
    private void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void BubbleDoDamage(float damage)
    {
        health -= damage;
    }
}
