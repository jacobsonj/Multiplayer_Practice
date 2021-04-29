using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTriggerCube : MonoBehaviour
{
    public GameObject touching = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touching != null && Input.GetKeyDown("z"))
        {
            touching.SendMessage("activate");
        }
    }

    void OnTriggerEnter(Collider other)
     {
        
     }

    void OnTriggerStay(Collider other)
    {
        print("entered");
        
        var characterName = other.name;
        print(characterName);
        if(characterName == "Luz_CDI")
        {
            print("should work");
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
