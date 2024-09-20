using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetWinner : MonoBehaviour
{
    static GetWinner instance;
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private int winnerNo;
    public void ModifyWinner(int Value)
    {
        winnerNo = Value;
    }
    public int GetTheWinner()
    {
        return winnerNo;
    }
}
