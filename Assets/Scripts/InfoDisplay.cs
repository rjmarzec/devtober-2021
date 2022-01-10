using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public int playerHealth;
    public int enemyHealth;
    public int currentAbility = -1;
    public List<Ability> abilities;

    public GameObject currentAbilityMarker;
    public GameObject iconPrefab;
    public Sprite attackSprite;
    public Sprite healSprite;

    public bool gameOver = false;
    public bool playerWon = false;
    public bool enemyWon = false;

    private void Awake()
    {
        playerHealth = 25;
        enemyHealth = 50;
    }

    private void Update()
    {
        currentAbilityMarker.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * (currentAbility + 1), -110);

        currentAbilityMarker.SetActive(currentAbility > -1);
    }

    public void AddAbility(Ability addedAbility)
    {
        abilities.Add(addedAbility);
        GameObject tempAttackDisplay = Instantiate(iconPrefab, transform);

        if(addedAbility == Ability.attack)
        {
            tempAttackDisplay.GetComponent<Image>().sprite = attackSprite;
        }
        else if(addedAbility == Ability.heal)
        {
            tempAttackDisplay.GetComponent<Image>().sprite = healSprite;
        }

        tempAttackDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * abilities.Count, -50);
    }
}

public enum Ability
{
    attack,
    heal,
}
