using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelectedPlayer : MonoBehaviour
{

    public GameObject Gears;
    public GameObject Luz;
    public GameObject Brute;
    public GameObject Pump;
    public GameObject Sat;
    public GameObject Main_Camera;
    GearMove gearMove_script;
    LuzMove luzMove_script;
    BruteMove bruteMove_script;
    PumpMove pumpMove_script;
    SatMove satMove_script;
    public CamerFollow cameraFollow_script;

    public int playerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        getMoveScripts();
        cameraFollow_script = Main_Camera.GetComponent<CamerFollow>();
        selectCameraFollow();
        // we need something in the start that goes and gets the states from the server and updates the player states so that new comers are jumping into the flow rather than forcing everyone to get on their flow.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            if(playerCount >= 5)
            {
                return;
            }
            Toggle();
        }
    }

    public void getMoveScripts()
    {
        gearMove_script = Gears.GetComponent<GearMove>();  
        luzMove_script = Luz.GetComponent<LuzMove>();
        bruteMove_script = Brute.GetComponent<BruteMove>();
        pumpMove_script = Pump.GetComponent<PumpMove>();
        satMove_script = Sat.GetComponent<SatMove>();
    }

    public void selectCameraFollow()
    {
        if(gearMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Gears);   
        }
        else if(luzMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Luz);
        }
        else if(bruteMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Brute);
        }
        else if(pumpMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Pump);
        }
        else if(satMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Sat);
        }
    }

    public void deselectMove()
    {
        gearMove_script.isLocalPlayer = false;
        luzMove_script.isLocalPlayer = false;
        bruteMove_script.isLocalPlayer = false;
        pumpMove_script.isLocalPlayer = false;
        satMove_script.isLocalPlayer = false;
        sendAllState();
    }

    public void sendAllState()
    {
        gearMove_script.sendState();
        luzMove_script.sendState();
        bruteMove_script.sendState();
        pumpMove_script.sendState();
        satMove_script.sendState();
    }

    public void selectGear(bool isSelected)
    {
        if(gearMove_script.toggleSelected)
        {
            satMove_script.isLocalPlayer = isSelected;
            satMove_script.toggleSelected = isSelected;
            selectLuz(gearMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            satMove_script.toggleSelected = isSelected;
            gearMove_script.toggleSelected = true;
            gearMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Gears);
        }
        sendAllState();   
    }
    public void selectLuz(bool isSelected)
    {
        if(luzMove_script.toggleSelected)
        {
            gearMove_script.isLocalPlayer = isSelected;
            gearMove_script.toggleSelected = isSelected;
            selectBrute(luzMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            gearMove_script.toggleSelected = isSelected;
            luzMove_script.toggleSelected = true;
            luzMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Luz);
        }
        sendAllState(); 
    }
    public void selectBrute(bool isSelected)
    {
        if(bruteMove_script.toggleSelected)
        {
            luzMove_script.isLocalPlayer = isSelected;
            luzMove_script.toggleSelected = isSelected;
            selectPump(bruteMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            luzMove_script.toggleSelected = isSelected;
            bruteMove_script.toggleSelected = true;
            bruteMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Brute);
        }
        sendAllState(); 
    }
    public void selectPump(bool isSelected)
    {
        if(pumpMove_script.toggleSelected)
        {
            bruteMove_script.isLocalPlayer = isSelected;
            bruteMove_script.toggleSelected = isSelected;
            selectSat(pumpMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            bruteMove_script.toggleSelected = isSelected;
            pumpMove_script.toggleSelected = true;
            pumpMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Pump);
        }
        sendAllState(); 
    }
    public void selectSat(bool isSelected)
    {
        if(satMove_script.toggleSelected)
        {
            pumpMove_script.isLocalPlayer = isSelected;
            pumpMove_script.toggleSelected = isSelected;
            selectGear(satMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            pumpMove_script.toggleSelected = isSelected;
            satMove_script.toggleSelected = true;
            satMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Sat);
        }
        sendAllState(); 
    }

    public void updatePlayerCount()
    {
        playerCount = 0;
        //gear isLocal
        if(gearMove_script.toggleSelected)
        {
            playerCount ++;
        }          
        //luz isLocal
        if(luzMove_script.toggleSelected)
        {
            playerCount ++;
        }
        //brute isLocal
        if(bruteMove_script.toggleSelected)
        {
            playerCount ++;
        }
        //pump isLocal
        if(pumpMove_script.toggleSelected)
        {
           playerCount ++;
        }
        //sat isLocal
        if(satMove_script.toggleSelected)
        {
            playerCount ++;
        }
        
    }

    public void Toggle()
    {

        {
            //gear isLocal
            if(gearMove_script.isLocalPlayer == true)
            {
                selectLuz(false);
            }          
            //luz isLocal
            else if(luzMove_script.isLocalPlayer == true)
            {
                selectBrute(false);
            }
            //brute isLocal
            else if(bruteMove_script.isLocalPlayer == true)
            {
                selectPump(false);
            }
            //pump isLocal
            else if(pumpMove_script.isLocalPlayer == true)
            {
                selectSat(false);
                // cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat isLocal
            else if(satMove_script.isLocalPlayer == true)
            {
                selectGear(false);
            }
            updatePlayerCount();
        }
    }
}
