using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float attackDelay;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float YMaximo;

    [SerializeField]
    private float YMinimo;

    [SerializeField]
    private float XMaximo;

    [SerializeField]
    private float XMinimo;


    private Rigidbody2D rb;

    private Vector2 inputMovement;

    private Vector2 movementDirection;

    private float currentAttackTime;

    private bool canAttack = true;

    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        currentAttackTime = attackDelay;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackDelay();
        ReadInputs();
        RunAnimations();
        FlipPlayer();
        PlayerMovement();
    }

    private void AttackDelay()
    {
        currentAttackTime -= Time.deltaTime;

        if (currentAttackTime <= 0)
        {
            canAttack = true;
        }

    }
    
    private void RunAnimations()
    {
        if (inputMovement.magnitude == 0)
        {
            animator.SetTrigger("idle");

        }else if (inputMovement.magnitude !=0)
        {
            animator.SetTrigger("walk");
        }

        if (Input.GetKeyDown(KeyCode.J) && canAttack)
        {
            animator.SetTrigger("punch");
            rb.velocity = Vector2.zero;
            canAttack = false;

        }

        if (Input.GetKeyDown(KeyCode.K) && canAttack)
        {
            animator.SetTrigger("kick");
            rb.velocity = Vector2.zero;
            canAttack = false;
        }

    }

    public void DisableMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }

    public void EnableMovement()
    {
        canMove= true;
        rb.velocity = Vector2.zero;
    }

    private void FlipPlayer()
    {
        if (inputMovement.x >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void ReadInputs()
    {
        inputMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void PlayerMovement()
    {
       
        if (!canMove) return;
        movementDirection = inputMovement.normalized;
        rb.velocity = movementDirection * playerSpeed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x,XMinimo, XMaximo), rb.position.y);
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y,YMinimo, YMaximo));
    }
}
