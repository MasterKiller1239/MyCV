using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInter : MonoBehaviour
{
    
    public spriteSwitcher ui;
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
        if(ui!=null)
        ui.Unlocker();
    }

   
}
