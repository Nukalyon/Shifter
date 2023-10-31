<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> albert
using UnityEngine;

public class Health : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private int maxHealth = 10;
    private int currentHealth = 0;


    // Start is called before the first frame update
=======
    [SerializeField] private int maxHealth = 20;

    private int currentHealth = 0;

    // Start is called before the first frame update

>>>>>>> albert
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
<<<<<<< HEAD
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0)
=======
        currentHealth += damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0)
>>>>>>> albert
        {
            Destroy(this.gameObject);
        }
    }
<<<<<<< HEAD

    public void GainHealth(int healthAmount)
    {
        currentHealth += healthAmount;
=======
    public void GainHealth(int healthAmount)
    {
        currentHealth += healthAmount;

>>>>>>> albert
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
