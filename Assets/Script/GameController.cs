using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // singleton variable
    private static GameController instance;

    int maxHeart = 3;
    int currentHeart = 3;
    int score = 0;
    GameObject[] heartList;

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
