using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteSwitcher : MonoBehaviour
{
    public Sprite locked;
    public Sprite Unlocked;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite= locked;
        this.GetComponent<TooltipTrigger>().active = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Unlocker()
    {
        this.GetComponent<Image>().sprite = Unlocked;
        this.GetComponent<TooltipTrigger>().active = true;
    }
}
