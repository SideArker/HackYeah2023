using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float range = 1.5f;
    [SerializeField] float cooldownTime = 1;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] Animator animator;

    bool onCooldown;

    void cooldown()
    {
        onCooldown = false;
    }

    public void Attack()
    {
        onCooldown = true;

        // Play Animation here

        GameObject player = Player.Instance.transform.gameObject;
        Health plrHp = player.GetComponent<Health>();

        animator.Play("raptorttack");
        plrHp.TakeDamage(damage);

        Invoke(nameof(cooldown), cooldownTime);

    }

    private void Update()
    {
        GameObject player = Player.Instance.transform.gameObject;

        transform.position += moveSpeed * Time.deltaTime * transform.forward;

        if (Vector2.Distance(transform.position, player.transform.position) < range && !onCooldown)
        {
            Attack();
        }
    }
}
