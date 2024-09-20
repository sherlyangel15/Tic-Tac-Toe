using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenPlayer : MonoBehaviour
{
    [SerializeField] int Player = 0;

    public int GetPlayer()
    {
        return Player;
    }
    public void SetPlayer(int player)
    {
        Player = player;
    }
}
