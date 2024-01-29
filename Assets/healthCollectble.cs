using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectble : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"You touched {other}");
        RubyController rubycontroller = other.GetComponent<RubyController>();
        if (rubycontroller != null)
        {
            rubycontroller.HealthCacluator(amount);
            Destroy(gameObject);
        } 
        
    }

   
    
}
