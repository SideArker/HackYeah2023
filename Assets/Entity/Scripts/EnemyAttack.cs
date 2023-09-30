using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float range = 1.5f;
    [SerializeField] float cooldownTime = 1;

    bool onCooldown;

    void cooldown()
    {
        onCooldown = false;
    }

    private void Attack()
    {
        onCooldown = true;

        // Play Animation here

        GameObject player = Player.Instance.transform.gameObject;
        Health plrHp = player.GetComponent<Health>();

        plrHp.TakeDamage(damage);

        Invoke(nameof(cooldown), cooldownTime);

    }

    private void Update()
    {
        GameObject player = Player.Instance.transform.gameObject;

        if(Vector2.Distance(transform.position, player.transform.position) < range && !onCooldown)
        {
            Attack();
        }
    }
}
