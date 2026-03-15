using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;


public class PlayerCreator
{
    private PlayerClass player;
    private bool created;

    public PlayerCreator()
    {
        // if (!created)
        // {
        //     player = new PlayerClass();
        //     created = true;
        // }
    }

    public PlayerClass getPlayer()
    {
        if (!created)
        {
            player = new PlayerClass();
            created = true;
        }
        return player;
    }

}
