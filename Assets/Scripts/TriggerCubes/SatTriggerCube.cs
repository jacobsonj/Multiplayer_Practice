using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatTriggerCube : MonoBehaviour
{
    public GameObject touching = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touching != null && Input.GetKeyDown("b"))
        {
            touching.SendMessage("activate");
        }
    }

    void OnTriggerEnter(Collider other)
     {
        
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Sat_CDI")
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }   
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        touching = null;
     }
}
