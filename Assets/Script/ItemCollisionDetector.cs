using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollisionDetector : MonoBehaviour //아이템이 한종류라고 생각하고 만든 아이템 점수 처리 시스템
    //후에 다른 점수가 필요하다면 새로운 이름으로 스크립트 작성후 아이템에  istrigger 만 붙여주면 된.
    // 후에 추상클래스나 인터페이스로 변경할 수 있다면 바꾸어서
    // 각각의 아이템 종류별로 이 것을 상속받아서 스코어 값을 변경시켜 사용하면 될 듯.
{
    private int score = 100;

    
    //충돌체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 캐릭터와의 충돌
        if (collision.transform.tag == "Player")
        {
            GameController.GetInstance().conllisonHandler(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public int getScore(){
        return score;
    }


}
