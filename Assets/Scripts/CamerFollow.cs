using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        // offset = new Vector3()
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
