using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(22, 26, 7);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The main camara get the position of my Player
        transform.position = player.transform.position + new Vector3(0, 30, -7);
    }
    public GameObject player;
}
