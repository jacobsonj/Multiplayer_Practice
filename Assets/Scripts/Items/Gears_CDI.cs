using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears_CDI : MonoBehaviour
{
    public GameObject Gears_IDI;

    public Gears_IDI GearsIDI_script;
    // Start is called before the first frame update
    void Start()
    {
        GearsIDI_script = Gears_IDI.GetComponent<Gears_IDI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        print("IDI called toggle");
        GearsIDI_script.toggleActive();
    }
}
