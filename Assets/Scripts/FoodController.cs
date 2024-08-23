using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    [SerializeField]
    private int lifeToRegen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerLife>().RegenLife(lifeToRegen);
            Destroy(gameObject);
        }
    }
}
