using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_CDI : MonoBehaviour
{
    public GameObject Pump_IDI;

    public Pump_IDI PumpIDI_script;
    // Start is called before the first frame update
    void Start()
    {
        PumpIDI_script = Pump_IDI.GetComponent<Pump_IDI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        print("IDI called toggle");
        PumpIDI_script.toggleActive();
    }
}
