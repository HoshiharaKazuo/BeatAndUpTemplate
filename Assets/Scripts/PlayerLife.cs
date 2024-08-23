using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int playerMaxLife;
    [SerializeField] private Animator animator;

    private bool playerAlive = true;
    
    private int playerCurrentLife;

    
    private void Start()
    {
        playerCurrentLife = playerMaxLife;
    }

    public void GetDamage(int damage)
    {
        if (playerAlive)
        {
            playerCurrentLife -= damage;
           
            if (playerCurrentLife <= 0) { 
                playerAlive = false;
                animator.Play("death");
            }
            else
            {
                animator.SetTrigger("damage");
            }
        }
    }

    public void RegenLife(int lifeToRegen)
    {
        if(playerCurrentLife + lifeToRegen >= playerMaxLife)
        {
            playerCurrentLife = playerMaxLife;
        }
        else
        {
            playerCurrentLife += lifeToRegen;
        }  
    }

    public int GetMaxLife()
    {
        return playerMaxLife;
    }

    public int GetCurrentLife()
    {
        return playerCurrentLife;
    }

    public bool GetAliveStatus()
    {
        return playerAlive;
    }
}
