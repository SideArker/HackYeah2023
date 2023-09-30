using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    float timeElapsed;
    float lerpDuration = 0.3f;
    [SerializeField] GameObject Fill;

    Health health;
    void Start()
    {
        health = GetComponentInParent<Health>();
    }

    void Update()
    {
        if (health.getHealth() < health.getMaxHealth())
        {
            if (timeElapsed < lerpDuration)
            {
                Fill.transform.localScale = new Vector3(Mathf.Lerp(Fill.transform.localScale.x, 0, timeElapsed / lerpDuration), Fill.transform.localScale.y, Fill.transform.localScale.z);
                timeElapsed += Time.deltaTime;
            }
            else Fill.transform.localScale = new Vector3(0, 1, 1);
        }
    }
}
