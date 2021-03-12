using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMove : Player
{

    public GameObject Gears;
    public Quaternion target;
    public float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        name = "Luz";
        target = Gears.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        target = Gears.transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    }
}
