using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    public static UnityEvent playerAttackEvent;
    public static UnityEvent playerHealEvent;
    public static UnityEvent enemyAttackEvent;
    public static UnityEvent roundOverEvent;
    public static UnityEvent gameOverEvent;

    public AudioClip playerAttack;
    public AudioClip playerHeal;
    public AudioClip enemyAttack;
    public AudioClip roundOver;
    public AudioClip gameOver;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        playerAttackEvent = new UnityEvent();
        playerHealEvent = new UnityEvent();
        enemyAttackEvent = new UnityEvent();
        roundOverEvent = new UnityEvent();
        gameOverEvent = new UnityEvent();

        playerAttackEvent.AddListener(PlayerAttackEventProc);
        playerHealEvent.AddListener(PlayerHealEventProc);
        enemyAttackEvent.AddListener(EnemyAttackEventProc);
        roundOverEvent.AddListener(RoundOverEventProc);
        gameOverEvent.AddListener(GameOverEventProc);
    }

    public void PlayerAttackEventProc()
    {
        audioSource.PlayOneShot(playerAttack);
    }

    public void PlayerHealEventProc()
    {
        audioSource.PlayOneShot(playerHeal);
    }

    public void EnemyAttackEventProc()
    {
        audioSource.PlayOneShot(enemyAttack);
    }

    public void RoundOverEventProc()
    {
        audioSource.PlayOneShot(roundOver);
    }

    public void GameOverEventProc()
    {
        audioSource.PlayOneShot(gameOver);
    }
}
