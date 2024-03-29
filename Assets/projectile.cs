using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void Lanuch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction* force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"You hit {collision.gameObject}");
        Destroy (gameObject);
    }
}
