using NaughtyAttributes;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

using Unity.VisualScripting;

public class AttackCombo : MonoBehaviour
{

    [Header("Main")]
    [SerializeField] float damage;
    [SerializeField] int maxComboCount = 5;
    [SerializeField] float cdBetweenComboKeys;
    [SerializeField] float endLag;

    [SerializeField] Animator animator;

    [SerializeField] float timeForComboExpire = 2f;


    // max 3
    [SerializeField] List<KeyCode> comboKeys = new List<KeyCode>();

    public string currentCombo;
    bool onCooldown;
    float lastComboKey;


    [Header("Combos")]
    [Expandable]
    [SerializeField] List<Combo> combos = new List<Combo>();

    void disableCooldown()
    {
        onCooldown = false;
    }

    void enableMoving()
    {
        GetComponent<PlayerMovement>().changeMoveState(true);
    }

    public void DealDamage()
    {
        RaycastHit2D raycastHit;
        if (PlayerMovement.rotation) raycastHit = Physics2D.Raycast(transform.position, Vector2.right, 2f);
        else raycastHit = Physics2D.Raycast(transform.position, Vector2.left, 2f);
        if (raycastHit.collider != null && raycastHit.collider.GetComponent<Health>())
        {
            Debug.Log(raycastHit.collider.gameObject);
            Health rayHealth = raycastHit.collider.GetComponent<Health>();

            rayHealth.TakeDamage(damage);
        }

    }
    IEnumerator Attack(string key)
    {
        onCooldown = true;
        //Invoke(nameof(), cdBetweenComboKeys);
        PlayerMovement PM = GetComponent<PlayerMovement>();

        // Basic Attack 1
        if (key == comboKeys[0].ToString().ToLower())
        {
            PM.changeMoveState(false);
            Debug.Log("Attack1");
            animator.Play("Attack1");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            onCooldown = false;

        }
        else
        // Basic Attack 2
        if (key == comboKeys[1].ToString().ToLower())
        {
            Debug.Log("Attack2");
            animator.Play("Attack2");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            onCooldown = false;

        }
        else
        // Basic Attack 3
        if (key == comboKeys[2].ToString().ToLower())
        {
            PM.changeMoveState(false);

            Debug.Log("Attack3");
            animator.Play("Attack3");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 1);
            onCooldown = false;

        }
        PM.changeMoveState(true);

    }

    void ComboCount(string key)
    {
        lastComboKey = Time.time;
        currentCombo += key.ToLower();

        Combo comboFound = combos.Find(x => x.comboString == currentCombo);

        if (comboFound == null)
            StartCoroutine(Attack(key));
        else
        {
            Debug.Log($"Found Combo\n Combo String: {comboFound.comboString}");
            if (comboFound.enabled == false) return;
            currentCombo = "";
            GetComponent<ComboAbility>().Ability(comboFound);
        }

        if (currentCombo.Length >= maxComboCount) currentCombo = "";
    }

    private void Update()
    {
        if (Time.time > lastComboKey + timeForComboExpire && !string.IsNullOrEmpty(currentCombo))
        {
            Debug.Log("combo expire");
            currentCombo = "";
        }

        if (comboKeys.Any(x => Input.GetKeyDown(x)) && !onCooldown)
        {
            string key = Input.inputString;
            // Sometimes printed double keys so this takes the first key one
            key = key.Substring(0, 1);

            ComboCount(key);
        }
    }
    private void Start()
    {
        lastComboKey = Time.time;
    }
}
