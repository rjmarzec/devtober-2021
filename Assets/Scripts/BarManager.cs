using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public InfoDisplay infoDisplay;
    public bool isPlayer;

    RectTransform rt;

    float startingHealth;

    void Start()
    {
        rt = GetComponent<RectTransform>();

        if(isPlayer)
        {
            startingHealth = infoDisplay.playerHealth;
        }
        else
        {
            startingHealth = infoDisplay.enemyHealth;
        }
    }

    void Update()
    {
        rt.anchorMax = new Vector2(1.0f, (isPlayer ? infoDisplay.playerHealth/startingHealth : infoDisplay.enemyHealth/startingHealth));
    }
}
