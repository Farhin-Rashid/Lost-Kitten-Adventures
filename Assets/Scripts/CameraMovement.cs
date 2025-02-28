using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Object the camera will follow
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //Move camera along player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
