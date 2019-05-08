using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCanvas : MonoBehaviour
{
    GameObject optionCanvas;

    private void Start()
    {
        optionCanvas = GameObject.Find("OptionCanvas");
    }

    public void OnClick() {
        pauseGame();
    }

    private void pauseGame()
    {
        optionCanvas.GetComponent<CanvasGroup>().alpha = 1f;
        optionCanvas.GetComponent<Canvas>().sortingOrder = 1;
        Time.timeScale = 0;


    }
}
