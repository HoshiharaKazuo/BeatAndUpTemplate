using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemyVelocity;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDelay;
    [SerializeField] private Animator animator;
    [SerializeField] private PowerUpSpawnController powerUpSpawnController;

    [SerializeField]
    private float YMaximo;

    [SerializeField]
    private float YMinimo;

    [SerializeField]
    private float XMaximo;

    [SerializeField]
    private float XMinimo;

    private GameObject player;
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private bool canAttack = true;
    private float attackTimer;
    private bool canMove = true;
    private CapsuleCollider2D capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        player = GameObject.FindWithTag("Player");
        attackTimer = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttacKTimer();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if(!canMove) return;
        
        if (Vector2.Distance(transform.position, player.transform.position) > attackDistance)
        {
            movementDirection = (player.transform.position - transform.position).normalized;
            FlipEnemy();
            animator.SetTrigger("walk");
            rb.velocity = movementDirection * enemyVelocity;
            rb.position = new Vector2(Mathf.Clamp(rb.position.x, XMinimo, XMaximo), rb.position.y);
            rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, YMinimo, YMaximo));
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetTrigger("idle");
            PerformEnemyAttack();
        }
    }

    private void EnemyAttacKTimer()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer <= 0)
        {
            attackTimer = attackDelay;
            canAttack = true;
        }
    }

    private void PerformEnemyAttack()
    {
        if (canAttack)
        {
            animator.SetTrigger("punch");
            canAttack = false;
        }
    }
    private void FlipEnemy()
    {
        if (movementDirection.x >= 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void EnableMovement()
    {
        canMove = true;
        rb.velocity = Vector2.zero;
    }

    public void DiasbleMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }

    public void PerformEnemyDeath()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        capsuleCollider.enabled = false;
    }

    public void DestroyOnDeath()
    {
        powerUpSpawnController.SpawnPowerUp();
        Destroy(gameObject);
    }
}
