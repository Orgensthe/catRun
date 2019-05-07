using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodada : MonoBehaviour, ICollisionAction
{
    private float timeCounter = 0.0f;
    private bool timeTrigger = false;
    private GameObject player;
    private GameObject cam;

    // Text object
    public GameObject text;

    // 고양이 데이터 백업
    private float movePowerBak;
    private float maxSpeedBak;

    public void CollisionAction(GameObject player, GameObject camera)
    {
        this.player = player;
        this.cam = camera;
        // 오브젝트를 안 보이게 하고 이벤트 처리
        gameObject.GetComponent<Renderer>().enabled = false;
        // 타임카운터 시작
        timeTrigger = true;
        // 이벤트 시작
        startEvent();
    }

    void Start() {
        text = GameObject.Find("ItemRunningTime");  
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTrigger)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= 4.0)
            {
                // 이벤트 종료
                endEvent();
            }
        }
    }

    void startEvent()
    {
        Debug.Log("Woodada : startEvent");
        // 고양이 woodadaAble ON
        player.GetComponent<CharacterController>().woodadaAble = true;

        // 고양이 속도 Backup
        // 이슈 : 고양이 movePower를 15로 설정할 때, 기존 movePower가 15 이상인 경우 어떻게 처리하는가
        movePowerBak = player.GetComponent<CharacterController>().movePower;
        maxSpeedBak = player.GetComponent<CharacterController>().maxSpeed;
        Debug.Log("이전 movePower : " + movePowerBak.ToString());

        // 고양이 속도 Set
        player.GetComponent<CharacterController>().movePower = 15.0F;
        player.GetComponent<CharacterController>().maxSpeed = 15.0F;

        // 텍스트 시간 On
        text.GetComponent<TimeText1>().triggerOn();
    }

    void endEvent()
    {
        Debug.Log("Woodada : endEvent");

        // 기존 movePower, maxSpeed 복구
        player.GetComponent<CharacterController>().woodadaAble = false;
        player.GetComponent<CharacterController>().movePower = movePowerBak;
        player.GetComponent<CharacterController>().maxSpeed = maxSpeedBak;

        text.GetComponent<TimeText1>().triggerOff();
        Destroy(this.gameObject);
    }
}
