using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{    public float shieldAmount { get; private set; }

    [Header("Main")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;

    [Header("Other")]
    [SerializeField] bool showBossBar;
    [SerializeField] GameObject normalHealthBar;

    bool createdHealthBar;

    public UnityEvent onDeath;

    #region Health Functions

    public float getHealth()
    {
        return health;
    }    
    public float getMaxHealth()
    {
        return maxHealth;
    }
    public void HealHealth(float health)
    {
        this.health += health;

        if (health > maxHealth) health = maxHealth;
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
    }
    #endregion

    #region Damage Functions

    public void TakeTrueDamage(float damage)
    {
        if (damage < 0) damage = -damage;

        health -= damage;

        if(health < maxHealth && !createdHealthBar && !transform.GetComponent<Player>())
        {
            createdHealthBar = true;
            GameObject healthBar = Instantiate(normalHealthBar, transform.position, transform.rotation, transform);
            healthBar.transform.position += transform.up * 0.75f;
        }

        if (health <= 0) KillEntity();


    }
    public void TakeDamage(float amount)
    {
        if (amount > shieldAmount)
        {
            float healthDeplete = amount - shieldAmount;

            TakeTrueDamage(healthDeplete);

            shieldAmount = 0;
        }
        else shieldAmount -= amount;
    }

    void destroyGameObject()
    {
        Destroy(transform.gameObject);
    }

    void KillEntity()
    {
        // Send a message that character is dead 
        //Debug.Log(transform.name + " is dead");
        onDeath.Invoke();
        Invoke("destroyGameObject", 0.5f);

    }

    #endregion

    #region Other
    public void GiveShield(float amount)
    {
        shieldAmount += amount;
    }

    #endregion
}