using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int turnNumber;
    public float moveDelay = 0.75f;
    public InfoDisplay infoDisplay;
    public bool roundStarted;

    public GameObject panel1;
    public GameObject panel2;

    public FadeOutOverTime playerSlash;
    public FadeOutOverTime playerHeal;
    public FadeOutOverTime enemySlash;

    public GameObject playerObject;
    public GameObject enemyObject;
    public GameObject gameOverFadePanel;

    void Start()
    {
        turnNumber = 1;
    }

    void Update()
    {
        // do an attack after a key press
        if (!infoDisplay.gameOver && !roundStarted && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)))
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                infoDisplay.AddAbility(Ability.attack);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                infoDisplay.AddAbility(Ability.heal);
            }

            roundStarted = true;
            StartCoroutine(StartRound());
        }

        panel1.SetActive(!roundStarted);
        panel2.SetActive(!roundStarted);
    }

    IEnumerator StartRound()
    {
        infoDisplay.currentAbility = 0;

        for (int i = 0; i < infoDisplay.abilities.Count; i++)
        {
            infoDisplay.currentAbility = i;

            if (infoDisplay.abilities[i] == Ability.attack)
            {
                infoDisplay.enemyHealth -= 1;
                playerSlash.currentAlpha = 1.0f;
                SoundManager.playerAttackEvent.Invoke();
            }
            else if (infoDisplay.abilities[i] == Ability.heal)
            {
                infoDisplay.playerHealth = Mathf.Min(100, infoDisplay.playerHealth + 2);
                playerHeal.currentAlpha = 1.0f;
                SoundManager.playerHealEvent.Invoke();
            }

            yield return new WaitForSeconds(moveDelay);
        }

        infoDisplay.playerHealth -= (int)(turnNumber * 0.8f) + 2;
        enemySlash.currentAlpha = 1.0f;
        SoundManager.enemyAttackEvent.Invoke();

        roundStarted = false;
        turnNumber++;
        infoDisplay.currentAbility = -1;
        yield return new WaitForSeconds(moveDelay);

        if (infoDisplay.playerHealth <= 0)
        {
            SoundManager.gameOverEvent.Invoke();
            EnemyWin();
        }
        else if (infoDisplay.enemyHealth <= 0)
        {
            SoundManager.gameOverEvent.Invoke();
            PlayerWin();
        }
        else
        {
            SoundManager.roundOverEvent.Invoke();
        }
    }

    void PlayerWin()
    {
        infoDisplay.gameOver = true;
        infoDisplay.playerWon = true;

        playerObject.AddComponent(typeof(MovesRight));
        enemyObject.AddComponent(typeof(MovesDown));
        gameOverFadePanel.SetActive(true);
    }

    void EnemyWin()
    {
        infoDisplay.gameOver = true;
        infoDisplay.enemyWon = true;

        playerObject.AddComponent(typeof(MovesDown));
        gameOverFadePanel.SetActive(true);
    }
}
