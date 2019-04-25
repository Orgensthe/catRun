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
    Transform groundCheck;

    float timeSpan; // 시작화면 카메라워킹용 타이머
    //2단점프
    int jumpCnt; 
    bool grounded;
    //무적확인
    bool invincivility;


    void Start()
    {
        //미리 불러오기
        timeSpan = 0.0f;
        jumpCnt = 0;
        grounded = true;
        invincivility = false;
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("groundCheck");

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 지면과 충돌
        if (!grounded && collision.transform.tag == "Ground")
        {
            animator.SetTrigger("Run");
            Debug.Log("lend");
            grounded = true;
            jumpCnt = 0;
        }
    }
    void Update()
    {
        //spacebar 눌리면 점프
        if(Input.GetButtonDown("Jump"))
        {
            ActionJump();
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
                    Debug.Log("jump");
                }
                break;
            case 1:
                if (!grounded)
                {
                    Debug.Log("doublejump");
                    animator.SetTrigger("DoubleJump");
                    rigid.velocity = Vector2.up * jumpPower;
                    jumpCnt++;
                }
                break;
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
