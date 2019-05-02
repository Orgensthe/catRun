using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // components variable
    bool isFirstDetection = false;
    //충돌체크
    private void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log(isFirstDetection);
        // 캐릭터와의 충돌
        if (!isFirstDetection && collision.transform.tag == "Player")
        {
            GameController.GetInstance().conllisonHandler(this.gameObject);
            isFirstDetection = true;
        }
    }


}
