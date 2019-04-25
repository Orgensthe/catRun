using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    int maxHeart = 3;
    int currentHeart = 3;
    int score = 0;
    GameObject[] heartList;


    // Start is called before the first frame update
    void Start()
    {
        heartList = new GameObject[maxHeart];
        for(int i = 0; i < maxHeart; i++) {
            heartList[i] = GameObject.Find("heart" + i.ToString());
        }

    }

    public void conllisonHandler(GameObject ob)
    { 
        if(ob.tag == "Obstacle") {
            collideWithObsatcle();
        }
    }

    public void collideWithObsatcle() {
        currentHeart -= 1;
        if (currentHeart == 0){
            heartList[currentHeart].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            Time.timeScale = 0;

        }
        else {
            heartList[currentHeart].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        }

    }




    // Update is called once per frame
    void Update()
    {
    }


}
