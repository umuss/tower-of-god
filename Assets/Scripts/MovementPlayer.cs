using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    //VARIABLES
    // SERIALIZE FIELD MI PERMETTE DI MODIFICARE IL VALORE NELL'INSPECTOR
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject sphere;
    [SerializeField] private Transform point;
    public float lifePoints;
    private Vector3 velocity;
    public bool lanciata;
    private GameObject sfera;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator animator;
    private Vector2 input;
    private int clickCounter = 0;
    private GameObject otherObject;

    //START & UPDATE
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        lanciata = false;

    }
    
    void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        */
        
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !lanciata)
        {
            StartCoroutine(Attack());
        }
        else
        {
            Move();
        }

    }

    //UTILS
    private void Move()
    {
        //Ferma la gravità quando tocca il piano
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            animator.SetFloat("InputX", input.x);
            animator.SetFloat("InputY", input.y);
            moveDirection = new Vector3(input.x, 0, input.y);
            moveDirection = transform.TransformDirection(moveDirection);
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }

            moveDirection *= moveSpeed;
        }
        
        controller.Move(moveDirection * Time.deltaTime); //DeltaTime per il controllo dei frame
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void Walk()
    {
        moveSpeed = walkSpeed;

    }

    

    private IEnumerator Attack()
    {
            animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.9f);
            if (!lanciata)
            {
                lanciata = true;
                sfera =Instantiate(sphere, point.position, GameObject.Find("Camera").transform.rotation);
                
            }
            
    }
}
    
    
    
    


