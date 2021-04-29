using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz_CDI : MonoBehaviour
{
    public GameObject Luz_IDI;

    public Luz_IDI LuzIDI_script;
    // Start is called before the first frame update
    void Start()
    {
        LuzIDI_script = Luz_IDI.GetComponent<Luz_IDI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        print("IDI called toggle");
        LuzIDI_script.toggleActive();
    }
}
