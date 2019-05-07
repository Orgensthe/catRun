using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaNyang : MonoBehaviour, ICollisionAction
{
    private float timeCounter = 0.0f;
    private bool timeTrigger = false;
    private GameObject player;
    private GameObject cam;

    // Text object
    public GameObject text;

    // 고양이 데이터 백업
    private float original_Y;

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
            if (timeCounter >= 3.6F)
            {
                Vector3 scale = player.GetComponent<Transform>().localScale;
                scale.x = 0.31F + (0.5F * ((4.0F - timeCounter) / 0.4F));
                scale.y = 0.31F + (0.5F * ((4.0F - timeCounter) / 0.4F));
                player.GetComponent<Transform>().localScale = scale;
                if (timeCounter >= 4.0F)
                {
                    // 이벤트 종료
                    endEvent();
                }
            }
        }
    }

    void startEvent()
    {
        Debug.Log("MegaNyang : startEvent");
        // 고양이 megaNyangAble ON
        player.GetComponent<CharacterController>().megaNyangAble = true;

        // 고양이 Scale, position Set
        player.GetComponent<Transform>().localScale += new Vector3(0.5F, 0.5F, 0);
        player.GetComponent<Transform>().Translate(0, 2.1F, 0);

        // 텍스트 시간 On
        text.GetComponent<TimeText1>().triggerOn();
    }

    void endEvent()
    {
        Debug.Log("MegaNyang : endEvent");

        // 기존 Scale, position 복구
        player.GetComponent<CharacterController>().megaNyangAble = false;
        // player.GetComponent<Transform>().Translate(0, -1.7F, 0);
        // player.GetComponent<Transform>().localScale -= new Vector3(0.5F, 0.5F, 0);

        text.GetComponent<TimeText1>().triggerOff();
        Destroy(this.gameObject);
    }
}
