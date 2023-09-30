using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackCombo : MonoBehaviour
{

    [Header("Main")]
    [SerializeField] float damage;
    [SerializeField] int maxComboCount = 5;
    [SerializeField] float cdBetweenComboKeys;

    // max 3
    [SerializeField] List<KeyCode> comboKeys = new List<KeyCode>();

    public string currentCombo;
    bool onCooldown;

    [Header("Combos")]
    [Expandable]
    [SerializeField] List<Combo> combos = new List<Combo>();

    void disableCooldown()
    {
        onCooldown = false;
    }

    void Attack(string key)
    {

        onCooldown = true;
        Invoke(nameof(disableCooldown), cdBetweenComboKeys);
        RaycastHit2D raycastHit;
        if(PlayerMovement.rotation) raycastHit = Physics2D.Raycast(transform.position, Vector2.right, 2f);
        else raycastHit = Physics2D.Raycast(transform.position, Vector2.left, 2f);
        if (raycastHit.collider != null && raycastHit.collider.GetComponent<Health>()) 
        {
            Debug.Log(raycastHit.collider.gameObject);
            Health rayHealth = raycastHit.collider.GetComponent<Health>();

            rayHealth.TakeDamage(damage);
        }

        // Basic Attack 1
        if(key == comboKeys[0].ToString().ToLower())
        {
            Debug.Log("Attack1");
        }        

        // Basic Attack 2
        if(key == comboKeys[1].ToString().ToLower())
        {
            Debug.Log("Attack2");
        }

        // Basic Attack 3
        if (key == comboKeys[2].ToString().ToLower())
        {
            Debug.Log("Attack3");
        }
    }

    void ComboCount(string key)
    {
        currentCombo += key;

        Combo comboFound = combos.Find(x => x.comboString == currentCombo);

        if(comboFound == null) Attack(key);

        else
        {
            Debug.Log($"Found Combo\n Combo String: {comboFound.comboString}");
            if (comboFound.enabled == false) return;
            currentCombo = "";
            comboFound.onCombo.Invoke();
        }

        if (currentCombo.Length >= maxComboCount) currentCombo = "";
    }

    private void Update()
    {
        if (comboKeys.Any(x => Input.GetKeyDown(x)) && !onCooldown)
        {
            string key = Input.inputString;
            // Sometimes printed double keys so this takes the first key one
            key = key.Substring(0, 1);

            ComboCount(key);
        };
    }
}
