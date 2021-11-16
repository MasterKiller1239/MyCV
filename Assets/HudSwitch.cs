using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudSwitch : MonoBehaviour
{
    public GameObject[] ui;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowUI()
    {
        foreach(GameObject window in ui)
        {
            window.GetComponent<ShowHideUI>().OnMouseOverUI();
        }

    }
    public void HideUI()
    {
        foreach (GameObject window in ui)
        {
            window.GetComponent<ShowHideUI>().OnMouseExitUI();
        }

    }
    public void DisableUI()
    {
        active = !active;
        foreach (GameObject window in ui)
        {
            if(active)
            window.SetActive(false);
            else
            window.SetActive(true);
        }

    }
    public void EnableUI()
    {
        foreach (GameObject window in ui)
        {
            window.SetActive(true);
        }

    }
}
