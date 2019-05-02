using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;


    int maxHeart = 3;
    int currentHeart = 3;
    int score = 0;
    GameObject[] heartList;
    GameObject player ;

    // return singleton instance
    public static GameController GetInstance()
    {
        if (!instance)
        {
            instance = (GameController)GameObject.FindObjectOfType(typeof(GameController));
            if (!instance)
                Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
        }
        return instance;
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
        if (player.GetComponent<CharacterController>().invincivility) {
            return; 
        }


        if (ob.tag == "Obstacle") {
            
            collideWithObsatcle();
            player.GetComponent<CharacterController>().makeInvincivible();

        }

        if (ob.tag == "scoreItem")
        {
            collideWithScoreItem(ob);
        }
    }

    public void collideWithObsatcle() { //장애물 충돌 처리 함수
        currentHeart -= 1;
        if (currentHeart == 0){
            heartList[currentHeart].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            Time.timeScale = 0;

        }
        else {
            heartList[currentHeart].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }

    }

    public void collideWithScoreItem(GameObject ob) //아이템 충돌 처리 함수
    {

        score += ob.GetComponent<ItemCollisionDetector>().getScore();
    }




    // Update is called once per frame
    void Update()
    {
    }


}
