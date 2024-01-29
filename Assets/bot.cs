using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class bot : MonoBehaviour
{

    float vertical;
    float horizontal;
    float movingtime = 12.0f;
    public float movingdistance = 0.005f;
    
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;
    Animator animator;

    bool broke = true;
    public void Start()
    {
       rigidbody2D =GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (broke == false) { return; }
        Vector2 position = transform.position;
        movingtime -= Time.deltaTime;
        
        if (movingtime > 9 && movingtime < 12)
        {
            position.x += movingdistance;
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);

        }
        if ( movingtime > 3 && movingtime < 6)
        {
            
            
            position.x -= movingdistance;
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);

        }
        if (movingtime > 6 && movingtime < 9)
        {

            
            position.y += movingdistance;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);

        }
        if (movingtime < 3)
        {

            
            position.y -= movingdistance;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);


        }
        if (movingtime < 0)
        {
            movingtime = 12;
        }
       

        rigidbody2D.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     RubyController rubycontroller = collision.gameObject.GetComponent<RubyController>();
        if (rubycontroller != null)
        {
            rubycontroller.HealthCacluator(-1);
        }
        projectile projectile = collision.gameObject.GetComponent<projectile>();
        if (projectile != null)
        {
            broke = false;
            animator.SetBool("Fixed", true);
        }

    }

    
        
    
        
    }



