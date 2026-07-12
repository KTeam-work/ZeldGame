using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue maxHealth; 
    public float currenHealth;

    void Start()
    {
        currenHealth = maxHealth.Runtime;
    }

    // Hồi máu
    public virtual void heal(float healAmount)
    {
        currenHealth += healAmount;
        if(currenHealth > maxHealth.Runtime)
        {
            currenHealth = maxHealth.Runtime;
        }
    }

    // Nhận sát thương
    public virtual void TakeDamage(float damageAmount)
    {
        currenHealth -= damageAmount;
        if(currenHealth < 0)
        {
            currenHealth = 0;
        }
    }

    public virtual void SetMaxHealth()
    {
        currenHealth = maxHealth.Runtime;
    }

    public virtual void SetDied()
    {
        currenHealth = 0;
    }
}
