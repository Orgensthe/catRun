using UnityEngine;
using System.Collections;

public class Score300 : MonoBehaviour , ICollisionAction
{
    private int scroe = 1000;

    public void CollisionAction(GameObject player, GameObject camera)
    {
        camera.GetComponent<GameController>().sumScore(scroe);
        Destroy(this.gameObject);
    }

}
