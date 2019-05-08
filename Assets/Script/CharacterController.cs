using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpPower = 1.0f;
    public float movePower = 6.0f;
    public float maxSpeed = 17.0f;
    public float minSpeed = 6.0f;
    Animator animator;
    Rigidbody2D rigid;

    float timeSpan; // 시작화면 카메라워킹용 타이머
    //2단점프
    int jumpCnt; 
    bool grounded, lucy, moomeung, b312;
    //무적확인
    bool invincivility;

    //태그중인지 확인
    private bool tagging;

    //파쿠르 가능 여부 확인
    private bool paku;


    void Start()
    {
        //미리 불러오기
        timeSpan = 0.0f;
        jumpCnt = 0;
        grounded = true;
        invincivility = false;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lucy = false;
        moomeung = false;
        b312 = false;
        tagging = false;
        paku = false;
    }

    //충돌체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 장애물과 충돌
        if (!invincivility && collision.transform.tag == "Obstacle")
        {
            movePower = minSpeed;
            StartCoroutine(Invincivility());
        }

        //파쿠르와 충돌
        if(collision.transform.tag == "PakuruPosition")
        {
            paku = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 지면과 충돌
        if (!grounded && collision.transform.tag == "Ground")
        {
            animator.SetTrigger("Run");
            grounded = true;
            jumpCnt = 0;
        }
    }
    void Update()
    {
        //spacebar 눌리면 점프
        if (Input.GetButtonDown("Jump") && !tagging )
        {
            if(paku)
            {
                //요기 파쿠르
                StartCoroutine(pakuru());
            }
            else
            {
                ActionJump();
            }
              
        }

        //T key 입력시 tag 시스템
        if (Input.GetKeyDown(KeyCode.L) && !lucy)
            lTagging();
        if (Input.GetKeyDown(KeyCode.M) && !moomeung)
            mTagging();
        if (Input.GetKeyDown(KeyCode.B) && !b312)
            bTagging();

        //변신 종료
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BeLucy") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tagging = false;
            Debug.Log("LTagEnd" + tag);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BeB-312") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tagging = false;
            Debug.Log("312TagEnd" + tag);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bemoomeung") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tagging = false;
            Debug.Log("MTagEnd" + tag);
        }

        //카메라 워킹
        timeSpan += Time.deltaTime;
        if (timeSpan > 0.5f)
         Camera.main.transform.position = new Vector3(transform.position.x + 5.0f, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    private void FixedUpdate()
    {
        //우측 이동
        transform.position += Vector3.right * movePower * Time.deltaTime;
        if (movePower < maxSpeed)
            movePower += 0.05f;
        
    }

    private void ActionJump()
    {
        switch (jumpCnt)
        {
            case 0:
                if (grounded)
                {
                    animator.SetTrigger("Jump");
                    rigid.velocity = Vector2.up * jumpPower;
                    jumpCnt++;
                    grounded = false;
                }
                break;
            case 1:
                if (!grounded)
                {
                    animator.SetTrigger("DoubleJump");
                    rigid.velocity = Vector2.up * jumpPower;
                    jumpCnt++;
                }
                break;
        }
    }

    void mTagging()
    {
        //StartCoroutine(Invincivility());  //무적 빼고 싶을 경우 주석처리할 문장
        
        tagging = true;
        animator.SetTrigger("Moomeung");
        moomeung = true;
        lucy = false;
        b312 = false;
        
    }

    void bTagging()
    {
        //StartCoroutine(Invincivility());  //무적 빼고 싶을 경우 주석처리할 문장

        tagging = true;
        animator.SetTrigger("B-312");
        moomeung = false;
        lucy = false;
        b312 = true;
    }

    void lTagging()
    {
        //StartCoroutine(Invincivility());  //무적 빼고 싶을 경우 주석처리할 문장

        tagging = true;
        animator.SetTrigger("Lucy");
        moomeung = false;
        lucy = true;
        b312 = false;
    }

    private IEnumerator Invincivility()
    {

        int countBlik = 0;
        invincivility = true;
        while(countBlik < 8)
        {
            if(countBlik%2 == 0)
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
            else
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);
            countBlik++;
        }
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        invincivility = false;
    }
    //파쿠르 실행
    private IEnumerator pakuru()
    {
        paku = false;
        for (int i = 0; i < 3; i++)
        {
            float temp = Random.RandomRange(0.0f, 0.5f);
            GameObject.Find("PakuruGameUi").SetActive(true);
            GameObject.Find("PakuruGameUi").GetComponent<Pakuru>().NoteMaker();
            Debug.Log(temp);
            yield return new WaitForSeconds(temp);
        }
    }
}
