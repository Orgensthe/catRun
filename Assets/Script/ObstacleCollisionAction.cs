using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionAction : MonoBehaviour, ICollisionAction
{
    private int currentHeart;

    public void CollisionAction(GameObject player, GameObject camera) {

        if (player.GetComponent<CharacterController>().invincivility)
        {
            return;
        }


        currentHeart = GameController.GetInstance().getCurrentHeart();

        if (currentHeart == 0) //현재의 하트 갯수가 0개라면 멈춤 -> 추후에는 게임종료 씬으로 전환
        {
            GameController.GetInstance().heartList[currentHeart-1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            Time.timeScale = 0;

        }
        else //그렇지 않다면 하트의 갯수를 하나 감소시킴
        {
            GameController.GetInstance().heartList[currentHeart-1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            GameController.GetInstance().setCurrentHeart(currentHeart-1);
        }

        player.GetComponent<CharacterController>().makeInvincivible();


    }
}
