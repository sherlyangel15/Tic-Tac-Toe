using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameRules : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] GetWinner getWinner;

    [Header("Buttons")]
    [SerializeField] Button[,] buttonArray = new Button[3, 3];
    [SerializeField] Button[] row1Buttons;
    [SerializeField] Button[] row2Buttons;
    [SerializeField] Button[] row3Buttons;

    [Header("Audio")]
    [SerializeField] AudioClip clickSound;
    [SerializeField] float volume;

    [Header("Player")]
    [SerializeField] int Player1 = 1;
    [SerializeField] int Player2 = 2;
    [SerializeField] int currentPlayer;

    bool hasWinner = false;
    int buttonCount;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        for(int i = 0; i < 3; i++)
        {
            buttonArray[0,i] = row1Buttons[i];
            buttonArray[1,i] = row2Buttons[i];
            buttonArray[2,i] = row3Buttons[i];
        }
        currentPlayer = Player1;
        buttonCount = 0;
    }

    void Update()
    {
        CheckDraw();
    }

    public void CheckForWinner()
    {
        for(int i = 0; i < 3; i++)
        {
            if(GetPlayer(buttonArray[i,0]) !=0 && GetPlayer(buttonArray[i, 0]) == GetPlayer(buttonArray[i, 1]) && GetPlayer(buttonArray[i, 1]) == GetPlayer(buttonArray[i, 2]))
            {
                hasWinner = true;
            }
            if(GetPlayer(buttonArray[0,i]) != 0 && GetPlayer(buttonArray[0, i]) == GetPlayer(buttonArray[1, i]) && GetPlayer(buttonArray[1, i]) == GetPlayer(buttonArray[2, i]))
            {
                hasWinner = true;
            }
        }
        if(GetPlayer(buttonArray[0,0]) != 0 && GetPlayer(buttonArray[0,0]) == GetPlayer(buttonArray[1,1]) && GetPlayer(buttonArray[1,1]) == GetPlayer(buttonArray[2,2]))
        {
            hasWinner = true;
        }

        if(GetPlayer(buttonArray[0,2]) != 0 && GetPlayer(buttonArray[0,2]) == GetPlayer(buttonArray[1,1]) && GetPlayer(buttonArray[1,1]) == GetPlayer(buttonArray[2,0]))
        {
            hasWinner = true;
        }

        if(hasWinner)
        {
            int winner = (currentPlayer == 1) ? 2 : 1;
            Winner(winner); 
        }
        return;
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1; 
    }

    public void Changetext(Button button)
    {
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
        if(currentPlayer == Player1)
        {
            text.text = "x";
            button.interactable = false;
            button.GetComponent<ChoosenPlayer>().SetPlayer(1); 
        }
        if(currentPlayer == Player2)
        {
            text.text = "o";
            button.interactable = false;
            button.GetComponent<ChoosenPlayer>().SetPlayer(2);
        } 
    }
    
    void Winner(int player)
    {
        getWinner.ModifyWinner(player);
        Debug.Log("The winner is: " + player);
        manager.LoadEndScreen();
    }

    int GetPlayer(Button button)
    {
        return button.GetComponent<ChoosenPlayer>().GetPlayer();
    }

    public void Draw()
    {
        buttonCount ++;
    }

    public void CheckDraw()
    {
        if(buttonCount == 9 && hasWinner == false)
        {
            Debug.Log("this Match is a Draw!");
            getWinner.ModifyWinner(3);
            manager.LoadEndScreen();
        }
    }

    public void ClickAudio()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clickSound, cameraPos, volume);
    }
 }
