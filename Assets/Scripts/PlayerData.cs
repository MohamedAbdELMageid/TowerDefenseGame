using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int currency;

    public PlayerData()
    {
        level = LevelManager.currentLevel+=1;
        currency = GameManager.currency;
    }
}
