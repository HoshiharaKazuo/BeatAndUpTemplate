using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionController : MonoBehaviour
{
    [SerializeField]
    private int attackDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLife>() != null)
        {
            collision.gameObject.GetComponent<PlayerLife>().GetDamage(attackDamage);
        }
    }
}
