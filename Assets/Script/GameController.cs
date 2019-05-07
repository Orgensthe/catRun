using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;


    int maxHeart = 3;
    int currentHeart = 3;
    private int score = 0;
    public GameObject[] heartList;
    GameObject player ;

    // return singleton instance
    public static GameController GetInstance() //For singleton pattern method
    {
        if (!instance)
        {
            instance = (GameController)GameObject.FindObjectOfType(typeof(GameController));
            if (!instance)
                Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
        }
        return instance;
    }

    public int getScore() { //현재의 점수를 리턴해주는 함수
        return score;
    }

    public void sumScore(int newScore) { //현재의 점수에 파라미터로 받은 점수를 더해주는 함수
        score = score+newScore;
    }

    public int getCurrentHeart() {
        return currentHeart;
    }

    public void setCurrentHeart(int newCurrentHeart) {
        currentHeart = newCurrentHeart;
    }





    void Start()
    {
        heartList = new GameObject[maxHeart];
        player = GameObject.Find("Player");
        for(int i = 0; i < maxHeart; i++) {
            heartList[i] = GameObject.Find("heart" + i.ToString());
        }

    }

    public void conllisonHandler(GameObject ob)
    {
        ob.GetComponent<ICollisionAction>().CollisionAction(player, this.gameObject);
    }






}
