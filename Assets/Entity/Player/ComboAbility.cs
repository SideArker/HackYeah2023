using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAbility : MonoBehaviour
{
    List<Combo> comboCooldowns = new List<Combo>();

    void comboCooldown(Combo combo)
    {
        comboCooldowns.Remove(combo);
    }

    public void Ability(Combo comboData)
    {
        if (comboCooldowns.Find(x => x == comboData)) return;
        comboCooldowns.Add(comboData);
        RaycastHit2D raycastHit;
        if (PlayerMovement.rotation) raycastHit = Physics2D.Raycast(transform.position, Vector2.right, comboData.range);
        else raycastHit = Physics2D.Raycast(transform.position, Vector2.left, comboData.range);

        if (raycastHit.collider != null && raycastHit.collider.GetComponent<Health>())
        {
            Debug.Log(raycastHit.collider.gameObject);
            Health rayHealth = raycastHit.collider.GetComponent<Health>();

            rayHealth.TakeDamage(comboData.damage);

        }

        if (comboData.abilityType == abilityType.Laser)
        {
            GameObject laser = Instantiate(comboData.laserPrefab, transform);
            laser.transform.position = transform.position + transform.right;

            Destroy(laser, 1f);

        }

    }
}
