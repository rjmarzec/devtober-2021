using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverFadePanel : MonoBehaviour
{
    Image panelImage;
    public float fadeTime = 5.0f;
    public float currentAlpha = 0.0f;

    public string scene1Name;
    public string scene2Name;

    void Start()
    {
        panelImage = GetComponent<Image>();
    }

    private void Update()
    {
        currentAlpha = Mathf.Min(1.0f, currentAlpha + Time.deltaTime / fadeTime);

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, currentAlpha);

        if(currentAlpha >= 1)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene1Name))
            {
                SceneManager.LoadScene(scene2Name);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(scene2Name))
            {
                SceneManager.LoadScene(scene1Name);
            }
        }
    }
}
