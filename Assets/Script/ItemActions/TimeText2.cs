using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText2 : MonoBehaviour
{
    public Text text;
    public GameObject cat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Cat Speed : " + cat.GetComponent<CharacterController>().movePower.ToString();
    }
}
