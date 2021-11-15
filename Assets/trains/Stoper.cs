using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoper : MonoBehaviour
{
    public bool wasUsed = false;

    public GameController gameCon;
    public int Cplus = 0;
    public int Chash = 0;
    public int Unity = 0;
    public int Unreal = 0;
    public int PL = 0;
    public int EN = 0;
    public int FR = 0;
    public int Achievements = 0;
    public spriteSwitcher[] sprites; 
      

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Train" && wasUsed!=true)
        {
            collision.gameObject.GetComponent<WaypointController>().isMoving = false;
            wasUsed = true;
            gameCon.CplusUpdate(Cplus);
            gameCon.ChashUpdate(Chash);
            gameCon.UnityUpdate(Unity);
            gameCon.UnrealUpdate(Unreal);
            gameCon.PLUpdate(PL);
            gameCon.ENUpdate(EN);
            gameCon.FRUpdate(FR);
            gameCon.AchievementsUpdate(Achievements);
            if (sprites.Length > 0)
                foreach (spriteSwitcher sprite in sprites)
                    sprite.Unlocker();
        }
    }
}
