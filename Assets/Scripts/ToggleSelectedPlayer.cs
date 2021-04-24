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

    public GameObject[] gameObjects;
    public Player[] players;

    public int isLocalPlayerInt;

    public int frameCount;

    // Start is called before the first frame update
    void Start()
    {

        getMoveScripts();
        cameraFollow_script = Main_Camera.GetComponent<CamerFollow>();
        gameObjects = new GameObject[] {Gears, Luz, Brute, Pump, Sat};
        players = new Player[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};
        setSelected(isLocalPlayerInt);
        selectCameraFollow();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount ++;
        if (Input.GetKeyDown("t"))
        {
            if(playerCount >= 5)
            {
                return;
            }
            Toggle();
        }

        if(frameCount%20 == 0 )
        {
            updatePlayerCount();
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
        for (int i = 0; i < players.Length; i++) 
        {
            var p = players[i];
            if(p.isLocalPlayer)
            {
                cameraFollow_script.togglePlayerFollow(gameObjects[i]);
            }
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

    public void updatePlayerCount()
    {
        playerCount = 0;
        //note for how to refactor. 
        for(int i = 0; i<=5; i++)
        {
            if(players[i].toggleSelected)
            {
                playerCount ++;
            }
        }
    }

    public void Toggle()
    {
        players[isLocalPlayerInt].toggleSelected = false;
        checkAndSelect();   
    }
    
    public void setSelected(int newLocalPlayer)
    {
        deselectMove();
        print("loook heeere" + newLocalPlayer);
        players[newLocalPlayer].isLocalPlayer = true;
        players[newLocalPlayer].toggleSelected = true;
        print(players[newLocalPlayer].toggleSelected);
        cameraFollow_script.togglePlayerFollow(gameObjects[newLocalPlayer]);
        sendAllState();
    }

    public void checkAndSelect()
    {
        if(isLocalPlayerInt < players.Length - 1)
        {
            isLocalPlayerInt ++;  
        }
        else
        {
            isLocalPlayerInt = 0;
        }

        if(!players[isLocalPlayerInt].toggleSelected)
        {
            setSelected(isLocalPlayerInt);
        }
        else
        {
            checkAndSelect();
        }
    }
}
