using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;
    Animator animator;
    public float speed = 0.1f;
    // Update is called once per frame
    public float horizontal;
    public float vertical;
    public float maxhealth = 5;
    float currentHealth;
    public float health { get { return currentHealth; } }
    float timeinvicable = 2.0f;
    bool isinvicable;
    float invicableTimer;

    Vector2 move;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject ProjectilePrefeb;

    public void Start()
    { 
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxhealth;
    }

    public void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (isinvicable == true)
        {
            invicableTimer -= Time.deltaTime;
            animator.SetTrigger("Hit");
        }
        if (invicableTimer < 0)
        {
            isinvicable = false;
            animator.SetBool("Hit", false);
        }
        move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C) || Input.GetAxis("Fire1")!=0)
        {
            Lanuch();
        }
    }

    public void FixedUpdate()
    {
        Vector2 position = transform.position;
        position  += move * speed * Time.deltaTime;
         
        rigidbody2D.position = position;
         
        
    }

    public void HealthCacluator(int number)
    {
        if(number < 0)
        {
            if (isinvicable == true)
            {
                return;
            }
            isinvicable = true;
            invicableTimer = timeinvicable;
        }
        currentHealth = Mathf.Clamp(currentHealth + number, 0, maxhealth);
        Debug.Log($"Current health is {currentHealth}");
    }

    void Lanuch()
    {
        GameObject projectileObject = Instantiate(ProjectilePrefeb, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
        projectile projectile = projectileObject.GetComponent<projectile>();
        projectile.Lanuch(lookDirection,300);
        animator.SetTrigger("Launch");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /*void Update()
    {
        Vector2 position = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        transform.position = position;


       /* Vector2 position = transform.position;
        if (Input.GetKey("a"))
        {
            position.x -= 0.01f;
        }
        if (Input.GetKey("d"))
        {
            position.x += 0.01f;
        }
        if (Input.GetKey("w"))
        {
            position.y += 0.01f;
        }
        if (Input.GetKey("s"))
        {
            position.y -= 0.01f;
        }
        transform.position = position;
    */



    /*float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector2 position = transform.position;
    position.x = position.x + 0.1f * horizontal;
    position.y = position.y + 0.1f * vertical;
    transform.position = position;
    */
}


