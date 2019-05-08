using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public float noteSpeed;

    void Start()
    {
        noteSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * noteSpeed * Time.deltaTime;
        //오브젝트 삭제
        Vector3 veiw = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 Line = GameObject.Find("Line").transform.position;
        if (Input.GetKeyDown(KeyCode.N))
        {
            float temp = transform.position.x - Line.x;
            Debug.Log("!!" + Line);
            if (temp < 1.0f && temp > -1.0f)
            {
                Destroy(gameObject);
                Debug.Log("Success");
            }
        }
        if (veiw.x < -10)
        {
            Destroy(gameObject);
        }
    }


}
