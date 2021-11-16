using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    private Outline outline;
    public ShowHideUI ui;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        if(ui!=null)
        ui.Setalpha(1.0f);
        if (outline != null)
            outline.OutlineWidth = 10;
    }

    void OnMouseExit()
    {
        if (ui != null)
            ui.Setalpha(0.2f);
        if (outline != null)
            outline.OutlineWidth = 0;
    }
}
