using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Winner : MonoBehaviour
{
    [SerializeField] GetWinner getWinner;

    [Header("Background")]
    [SerializeField] GameObject backGround;

    [Header("Sprites")]
    [SerializeField] Sprite Player1Wins;
    [SerializeField] Sprite Player2Wins;
    [SerializeField] Sprite Draw;
    [SerializeField] Sprite Default;

    [Header("Audio")]
    [SerializeField] AudioClip winAudioClip;
    [SerializeField] AudioClip drawAudioClip;
    [SerializeField] float volume;
    Vector3 cameraPos;

    int winner;

    void Start()
    {
        getWinner = FindObjectOfType<GetWinner>();
        winner = getWinner.GetTheWinner();
        cameraPos = Camera.main.transform.position;
    }
    void Update()
    {
        if(getWinner != null)
        {
            ChangeSprite();
        }
    }
    void ChangeSprite()
    {
        WinningSprite(winner);
        getWinner.gameObject.SetActive(false);
        Destroy(getWinner);
    }

    void WinningSprite(int player)
    {
        if(player == 1)
        {
            Sprite(Player1Wins);
            PlayAudio(winAudioClip);
        }
        else if(player == 2)
        {
            Sprite(Player2Wins);
            PlayAudio(winAudioClip);
        }
        else if(player == 3)
        {
            Sprite(Draw);
            PlayAudio(drawAudioClip);
        }
        else
        {
            Sprite(Default);
        }
    }

    void Sprite(Sprite spriteImage)
    {
        backGround.GetComponent<SpriteRenderer>().sprite = spriteImage;
    }

    void PlayAudio(AudioClip audio)
    {
        AudioSource.PlayClipAtPoint(audio, cameraPos, volume);
    }
}
