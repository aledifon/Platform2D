using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    [Header("UI")]
    public Image acornUI;

    [Header("Death")]
    public float forceJumpDeath;

    Animator anim;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
        acornUI.fillAmount = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //Public method which I'll call from the enemy's script
    public void TakeDamage(int amount)
    {
        //In case hurting anim. is running or the player is death then we'll return.
        if (anim.GetBool("Hurt") || currentHealth <= 0) return; 

        currentHealth -= amount;
        acornUI.fillAmount = currentHealth / maxHealth;

        anim.SetBool("Hurt", true);
        //stop the player, reset the speed
        playerMovement.ResetVelocity();

        if (currentHealth <= 0)
        {
            Death();
            return;
        }
        Invoke("HurtToFalse", 1);
    }
    void HurtToFalse()
    {
        anim.SetBool("Hurt", false);
    }
    void Death()
    {
        playerMovement.DeathVelocity();
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceJumpDeath);
        //GetComponent<Rigidbody2D>().gravityScale = 10;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(2, 2, 2));
    }
}
