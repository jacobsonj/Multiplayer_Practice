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
        selectGear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
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

    public void deselectMove()
    {
        gearMove_script.toggleSelected = false;
        luzMove_script.toggleSelected = false;
        bruteMove_script.toggleSelected = false;
        pumpMove_script.toggleSelected = false;
        satMove_script.toggleSelected = false;
    }

    public void selectGear()
    {
        deselectMove();
        gearMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Gears);
    }
    public void selectLuz()
    {
        deselectMove();
        luzMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Luz);
    }
    public void selectBrute()
    {
        deselectMove();
        bruteMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Brute);
    }
    public void selectPump()
    {
        deselectMove();
        pumpMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Pump);
    }
    public void selectSat()
    {
        deselectMove();
        satMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Sat);
    }

    public void Toggle()
    {

        {
            //gear to luz
            if(gearMove_script.toggleSelected == true){
                selectLuz();
                // cameraFollow_script.togglePlayerFollow(Luz);
            }
            
            //luz to brute
            else if(luzMove_script.toggleSelected == true){
                selectBrute();
                // cameraFollow_script.togglePlayerFollow(Brute);
            }
            
            //brute to pump
            else if(bruteMove_script.toggleSelected == true){
                selectPump();
                // cameraFollow_script.togglePlayerFollow(Pump);
            }
            
            //pump to sat
            else if(pumpMove_script.toggleSelected == true){
                selectSat();
                // cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat to gears
            else if(satMove_script.toggleSelected == true){
                selectGear();
                // cameraFollow_script.togglePlayerFollow(Gears);
            }
        }
        
    }
}
