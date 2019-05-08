using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionCanvas : MonoBehaviour
{
    public GameObject optionCanvas;
    // Start is called before the first frame update
    void Start()
    {

        optionCanvas = GameObject.Find("OptionCanvas");
        optionCanvas.GetComponent<CanvasGroup>().alpha = 0f;

    }

    public void resume() {
        optionCanvas.GetComponent<CanvasGroup>().alpha = 0f;
        optionCanvas.GetComponent<Canvas>().sortingOrder = -1;
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void exit()
    {
        Application.Quit();
    }

}
