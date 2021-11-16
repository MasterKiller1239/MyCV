using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disolvelauncher : MonoBehaviour
{
    public bool wasUsed = false;
    // Start is called before the first frame update
    public DissolveObject []obj;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Train" && wasUsed != true)
        {
            foreach(DissolveObject dis in obj)
            {
                dis.activite();
            }
          
            wasUsed = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
