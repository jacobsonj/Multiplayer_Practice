using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{

    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;
    public GameObject touching = null;

    void Start()
    {
        liftPos = new Vector3(0.0f, 1.5f, 1.0f);
    }

    void OnTriggerEnter(Collider other)
     {
          canLift = true;
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "Luz" || characterName == "Gears" || characterName == "Sat" || characterName == "Pump")
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }   
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "Luz" || characterName == "Gears" || characterName == "Sat" || characterName == "Pump" || characterName.Contains("Box"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }
        }
     }

     void Update()
    {   
        // if(lifting == true)
        // {
        //     touching.transform.position = transform.TransformPoint(liftPos);
        // } 

        if(touching && Input.GetKeyDown("l"))
        {
            toggleLift();
        }
    }
    
    public void toggleLift() 
    {
        if(touching.name == "Luz" || touching.name == "Gears" || touching.name == "Sat" || touching.name == "Pump")
        {
            lifting = !lifting;
            touching.SendMessage("toggleIsBeingCarried");
        }
    }
}
