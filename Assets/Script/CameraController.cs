using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 tempPosition;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        tempPosition = this.transform.position;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        tempPosition.x = player.GetComponent<Transform>().position.x;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = tempPosition;
    }
}