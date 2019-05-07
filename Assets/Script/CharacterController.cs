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
    public int jumpCnt; 
    bool grounded, Lucy, MooM;
    //무적확인

    public bool invincivility;
    //태그중인지 확인
    bool tag, mtag;


    void Start()
    {
        //미리 불러오기
        timeSpan = 0.0f;
        jumpCnt = 0;
        grounded = true;
        invincivility = false;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Lucy = true;
        MooM = false;
        tag = false;
    }


    public void makeInvincivible()
    {

            movePower = minSpeed;
            StartCoroutine(Invincivility());
 
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
        if ( Input.touchCount != 0  && !tag)
        {
            for(int i = 0; i < Input.touchCount; i++) {

                if (Input.GetTouch(i).phase == TouchPhase.Ended &&Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    ActionJump();  

                }
            }
           
                    

        }

        //T key 입력시 tag 시스템
        if (Input.GetKeyDown(KeyCode.T))
            tagging();
        if (Input.GetKeyDown(KeyCode.M))
            Mtagging();

        //변신 종료
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BeLucy") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tag = false;
            Debug.Log("LTagEnd" + tag);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BeB-312") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tag = false;
            Debug.Log("312TagEnd" + tag);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bemoomeung") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95)
        {
            animator.SetTrigger("Run");
            tag = false;
            Debug.Log("MTagEnd" + tag);
        }

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

    void Mtagging()
    {
        if (grounded)
        {
            mtag = true;
            //StartCoroutine(Invincivility());  //무적 빼고 싶을 경우 주석처리할 문장
            if (MooM)
                animator.SetTrigger("M");
            else
                animator.SetTrigger("M");
            MooM = !MooM;
        }
    }

    void tagging()
    {
        if (grounded)
        {
            //StartCoroutine(Invincivility());  //무적 빼고 싶을 경우 주석처리할 문장
            if (Lucy)
                animator.SetTrigger("Tag");
            else
                animator.SetTrigger("Tag");
            Lucy = !Lucy;
            tag = true;
            Debug.Log("Tag" + tag);
        }
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

}
