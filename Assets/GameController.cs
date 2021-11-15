using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Slider Cplusbar;
    public ItemSpawner cplus;
    public Slider Chashbar;
    public ItemSpawner Chash;
    public Slider Unitybar;
    public ItemSpawner Unity;
    public Slider Unrealbar;
    public ItemSpawner Unreal;
    public Slider PLbar;
    public ItemSpawner PL;
    public Slider ENbar;
    public ItemSpawner EN;
    public Slider FRbar;
    public ItemSpawner FR;
    public ItemSpawner Achievements;
    public ShowHideUI Skills;
    public ShowHideUI AChieve;
    public ShowHideUI Langu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AchievementsUpdate(int number)
    {
       if(number>0)
        {
            AChieve.OnMouseOverUI();
            Achievements.Spawn(number);
            Achievements.Switchero();
        }
    
    
    }
    public void CplusUpdate(int number)
    {
        if (number > 0)
        {
            Cplusbar.value += (float)number / 10;
            cplus.Spawn(number);
            cplus.Switchero();
            Skills.OnMouseOverUI();
        }
  
    }
    public void ChashUpdate(int number)
    {
        if (number > 0)
        {
            Chashbar.value += (float)number / 10;
            Chash.Spawn(number);
            Chash.Switchero();
        }
  
   
    }
    public void UnityUpdate(int number)
    {
        if (number > 0)
        {
            Unitybar.value += (float)number / 10;
            Unity.Spawn(number);
            Unity.Switchero();
        }
       
    }
    public void UnrealUpdate(int number)
    {
        if (number > 0)
        {
            Unrealbar.value += (float)number / 10;
            Unreal.Spawn(number);
            Unreal.Switchero();
        }
       
    }
    public void PLUpdate(int number)
    {
        if (number > 0)
        {
            PLbar.value += (float)number / 10;
            PL.Spawn(number);
            PL.Switchero();
        }
      
    }
    public void ENUpdate(int number)
    {
        if (number > 0)
        {
            ENbar.value += (float)number / 10;
            EN.Spawn(number);
            EN.Switchero();

            Langu.OnMouseOverUI();
        }
       
    }
    public void FRUpdate(int number)
    {
        if (number > 0)
        {
            FRbar.value += (float)number / 10;
            FR.Spawn(number);
            FR.Switchero();
        }
       
    }

}
