using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
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
            Fill.transform.localScale = new Vector3(health.getHealth() / health.getMaxHealth(), Fill.transform.localScale.y, Fill.transform.localScale.z);
            Color colorChange = Color.Lerp(Color.red, Color.green, health.getHealth() / health.getMaxHealth());
            Fill.GetComponentInChildren<SpriteRenderer>().color = colorChange;
        }
    }
}
