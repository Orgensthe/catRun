using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTextor : MonoBehaviour
{

    GameController gameCon;
    GameObject player;
    int fontSize;
    public GameObject pointTextUI;

  
    private void Start()
    {
        gameCon = GameController.GetInstance();
        player = GameObject.Find("Player");
       
        pointTextUI = GameObject.Find("Text");
     

    }

    private void LateUpdate()
    {
        pointTextUI.GetComponent<Text>().text = GameController.GetInstance().getScore().ToString();
    }
}
