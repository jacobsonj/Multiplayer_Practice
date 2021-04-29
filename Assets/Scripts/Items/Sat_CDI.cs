using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sat_CDI : MonoBehaviour
{
    public GameObject Sat_IDI;

    public Sat_IDI SatIDI_script;
    // Start is called before the first frame update
    void Start()
    {
        SatIDI_script = Sat_IDI.GetComponent<Sat_IDI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        print("IDI called toggle");
        SatIDI_script.toggleActive();
    }
}
