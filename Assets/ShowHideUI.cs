using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    public float aValue = 0.2f;
    private CanvasGroup trans;
    public Outline outline;
   
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = aValue;
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    public void Setalpha(float number)
    {
        aValue = number;
        trans.alpha = aValue;
    }

    public void OnMouseOverUI()
    {
        this.Setalpha(1f);
        outline.OutlineWidth = 10;
    }

    public void OnMouseExitUI()
    {
        this.Setalpha(0.2f);
        outline.OutlineWidth = 0;
    }
}
