using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText1 : MonoBehaviour
{
    public Text timeText;
    private float time;
    private bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            time += Time.deltaTime;
            timeText.text = "Item Running Time : " + time.ToString();
        }
    }

    public void triggerOn()
    {
        trigger = true;
    }

    public void triggerOff()
    {
        trigger = false;
    }
}
