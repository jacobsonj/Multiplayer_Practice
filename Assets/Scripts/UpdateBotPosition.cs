using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;


public class UpdateBotPosition : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public GameObject Gears;
    public GameObject Luz;
    public GameObject Brute;
    public GameObject Pump;
    public GameObject Sat;

    private GearMove GearMove_Script;
    private LuzMove LuzMove_Script;
    private BruteMove BruteMove_Script;
    private PumpMove PumpMove_Script;
    private SatMove SatMove_Script;

    public float rotationSpeed = 10f;
    public Vector3 currentEulerAngles;
    

    // public Vector3 newPos;


    // Start is called before the first frame update
    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();  
        LuzMove_Script = Luz.GetComponent<LuzMove>();  
        BruteMove_Script = Brute.GetComponent<BruteMove>();  
        PumpMove_Script = Pump.GetComponent<PumpMove>();  
        SatMove_Script = Sat.GetComponent<SatMove>();  
    }
    private int frameCount = 0;
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        // frameCount++;
        // if(frameCount%10 == 0)
        // {
            updatePositions();
            updateStates();
        // }
       
        // if(GearMove_Script.isLocalPlayer)
        // {
        //     // if(frameCount%30 == 0)
        //     // {
        //     updatePositionsNotGears();
        //     // }
        // }
        // if(LuzMove_Script.isLocalPlayer)
        // {
        //     // if(frameCount%30 == 0)
        //     // {
        //     updatePositionsNotLuz();
        //     // }
        // }
        // if(BruteMove_Script.isLocalPlayer)
        // {
        //     // if(frameCount%30 == 0)
        //     // {
        //     updatePositionsNotBrute();
        //     // }
        // }
        // if(PumpMove_Script.isLocalPlayer)
        // {
        //     // if(frameCount%30 == 0)
        //     // {
        //     updatePositionsNotPump();
        //     // }
        // }
        // if(SatMove_Script.isLocalPlayer)
        // {
        //     // if(frameCount%30 == 0)
        //     // {
        //     updatePositionsNotSat();
        //     // }
        // }
        
    }

    
    

    async void updatePositions()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<RobotsPositions>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
        // LuzMove_Script.isBeingCarried = robots.Luz.state.isBeingCarried;
        // Brute
        BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
        Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
        // Pump
        PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
        Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
        // Sat
        SatMove_Script.rb.MovePosition(robots.Sat.position.position);
        Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    }
    async void updateStates()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<RobotsStates>(positionResponseString);
        
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        // print("CHEEEECK THIIIIIIIS" + robots.Gears.position.rotation);
        // Gears
        GearMove_Script.isBeingCarried = robots.Gears.state.isBeingCarried;
        GearMove_Script.toggleSelected = robots.Gears.state.toggleSelected;
        // Luz
        LuzMove_Script.isBeingCarried = robots.Luz.state.isBeingCarried;
        LuzMove_Script.toggleSelected = robots.Luz.state.toggleSelected;
        // Brute
        BruteMove_Script.isBeingCarried = robots.Brute.state.isBeingCarried;
        BruteMove_Script.toggleSelected = robots.Brute.state.toggleSelected;
        // Pump
        PumpMove_Script.isBeingCarried = robots.Pump.state.isBeingCarried;
        PumpMove_Script.toggleSelected = robots.Pump.state.toggleSelected;
        // Sat
        SatMove_Script.isBeingCarried = robots.Sat.state.isBeingCarried;
        SatMove_Script.toggleSelected = robots.Sat.state.toggleSelected;
    }
    // async void updatePositionsNotGears()
    // {
    //     var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

    //     var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
    //     var robots = JsonUtility.FromJson<Robots>(positionResponseString);
    //     // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
    //     print(robots);
    //     // Gears
    //     // GearMove_Script.rb.MovePosition(robots.Gears.position.position);
    //     // Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Luz
    //     LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
    //     Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Brute
    //     BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
    //     Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Pump
    //     PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
    //     Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Sat
    //     SatMove_Script.rb.MovePosition(robots.Sat.position.position);
    //     Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    // }
    // async void updatePositionsNotLuz()
    // {
    //     var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

    //     var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
    //     var robots = JsonUtility.FromJson<Robots>(positionResponseString);
    //     // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
    //     print(robots);
    //     // Gears
    //     GearMove_Script.rb.MovePosition(robots.Gears.position.position);
    //     Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Luz
    //     // LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
    //     // Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Brute
    //     BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
    //     Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Pump
    //     PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
    //     Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Sat
    //     SatMove_Script.rb.MovePosition(robots.Sat.position.position);
    //     Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    // }
    // async void updatePositionsNotBrute()
    // {
    //     var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

    //     var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
    //     var robots = JsonUtility.FromJson<Robots>(positionResponseString);
    //     // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
    //     print(robots);
    //     // Gears
    //     GearMove_Script.rb.MovePosition(robots.Gears.position.position);
    //     Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Luz
    //     LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
    //     Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Brute
    //     // BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
    //     // Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Pump
    //     PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
    //     Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Sat
    //     SatMove_Script.rb.MovePosition(robots.Sat.position.position);
    //     Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    // }
    // async void updatePositionsNotPump()
    // {
    //     var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

    //     var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
    //     var robots = JsonUtility.FromJson<Robots>(positionResponseString);
    //     // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
    //     print(robots);
    //     // Gears
    //     GearMove_Script.rb.MovePosition(robots.Gears.position.position);
    //     Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Luz
    //     LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
    //     Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Brute
    //     BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
    //     Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Pump
    //     // PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
    //     // Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Sat
    //     SatMove_Script.rb.MovePosition(robots.Sat.position.position);
    //     Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    // }
    // async void updatePositionsNotSat()
    // {
    //     var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

    //     var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
    //     var robots = JsonUtility.FromJson<Robots>(positionResponseString);
    //     // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
    //     print(robots);
    //     // Gears
    //     GearMove_Script.rb.MovePosition(robots.Gears.position.position);
    //     Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Luz
    //     LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
    //     Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Brute
    //     BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
    //     Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Pump
    //     PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
    //     Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
    //     // Sat
    //     // SatMove_Script.rb.MovePosition(robots.Sat.position.position);
    //     // Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    // }
}

[Serializable]
public class RobotsPositions
{
    public RobotPosition Gears;
    public RobotPosition Luz;
    public RobotPosition Brute;
    public RobotPosition Pump;
    public RobotPosition Sat;
}
[Serializable]
public class RobotsStates
{
    public RobotState Gears;
    public RobotState Luz;
    public RobotState Brute;
    public RobotState Pump;
    public RobotState Sat;
}
