using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour
{
    bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(used==false)
            Application.OpenURL("http://www.linkedin.com/in/jakub-grobelkiewicz-7bb3971b3/");
            used = true;
        
    }
}
