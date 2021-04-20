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

    // Start is called before the first frame update
    void Start()
    {
        getMoveScripts();
        cameraFollow_script = Main_Camera.GetComponent<CamerFollow>();
        // selectGear();
        selectCameraFollow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            print("toggle");
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
            
            //luz to brute
        else if(luzMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Luz);
        }
            
            //brute to pump
        else if(bruteMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Brute);
        }
            
            //pump to sat
        else if(pumpMove_script.toggleSelected == true)
        {
            cameraFollow_script.togglePlayerFollow(Pump);
        }
            //sat to gears
        else if(satMove_script.toggleSelected == true){
        
            cameraFollow_script.togglePlayerFollow(Sat);
        }
    }

    public void deselectMove()
    {
        // gearMove_script.toggleSelected = false;
        // luzMove_script.toggleSelected = false;
        // bruteMove_script.toggleSelected = false;
        // pumpMove_script.toggleSelected = false;
        // satMove_script.toggleSelected = false;
        gearMove_script.isLocalPlayer = false;
        luzMove_script.isLocalPlayer = false;
        bruteMove_script.isLocalPlayer = false;
        pumpMove_script.isLocalPlayer = false;
        satMove_script.isLocalPlayer = false;
        gearMove_script.sendState();
        luzMove_script.sendState();
        bruteMove_script.sendState();
        pumpMove_script.sendState();
        satMove_script.sendState();
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
            satMove_script.isLocalPlayer = false;
            satMove_script.toggleSelected = false;
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
            gearMove_script.isLocalPlayer = false;
            gearMove_script.toggleSelected = false;
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
            luzMove_script.isLocalPlayer = false;
            luzMove_script.toggleSelected = false;
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
            bruteMove_script.isLocalPlayer = false;
            bruteMove_script.toggleSelected = false;
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
            pumpMove_script.isLocalPlayer = false;
            pumpMove_script.toggleSelected = false;
            selectGear(satMove_script.toggleSelected);
        }
        else
        {
            deselectMove();
            pumpMove_script.toggleSelected = false;
            satMove_script.toggleSelected = true;
            satMove_script.isLocalPlayer = true;
            cameraFollow_script.togglePlayerFollow(Sat);
        }
        sendAllState(); 
    }


    public void Toggle()
    {

        {
            //gear to luz
            if(gearMove_script.isLocalPlayer == true){
                
                selectLuz(false);
                // cameraFollow_script.togglePlayerFollow(Luz);
            }
            
            //luz to brute
            else if(luzMove_script.isLocalPlayer == true){
                print("WEEEE DIID 222222");
                selectBrute(false);
                // cameraFollow_script.togglePlayerFollow(Brute);
            }
            
            //brute to pump
            else if(bruteMove_script.isLocalPlayer == true){
                selectPump(false);
                // cameraFollow_script.togglePlayerFollow(Pump);
            }
            
            //pump to sat
            else if(pumpMove_script.isLocalPlayer == true){
                selectSat(false);
                // cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat to gears
            else if(satMove_script.isLocalPlayer == true){
                selectGear(false);
                // cameraFollow_script.togglePlayerFollow(Gears);
            }
        }
        
    }
}
