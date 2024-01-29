using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthdecrease : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount = -1;

 

    private void OnTriggerStay2D(Collider2D other)
    {
      
        RubyController rubycontroller = other.GetComponent<RubyController>();
        if (rubycontroller != null)
        {
            rubycontroller.HealthCacluator(amount);
        }
    }
}
