using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionDetector : MonoBehaviour
{
    // components variable
    bool isFirstDetection = false;

    //충돌체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 캐릭터와의 충돌
        if (!isFirstDetection && collision.transform.tag == "Player")
        {
            GameController.GetInstance().conllisonHandler(this.gameObject);
            isFirstDetection = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
