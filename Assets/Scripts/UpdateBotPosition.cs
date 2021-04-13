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
        frameCount++;
        // if(frameCount%30 == 0)
        // {
            updatePositions();
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
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
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
    async void updatePositionsNotGears()
    {
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        // GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        // Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
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
    async void updatePositionsNotLuz()
    {
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        // LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        // Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
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
    async void updatePositionsNotBrute()
    {
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
        // Brute
        // BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
        // Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
        // Pump
        PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
        Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
        // Sat
        SatMove_Script.rb.MovePosition(robots.Sat.position.position);
        Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    }
    async void updatePositionsNotPump()
    {
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
        // Brute
        BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
        Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
        // Pump
        // PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
        // Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
        // Sat
        SatMove_Script.rb.MovePosition(robots.Sat.position.position);
        Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    }
    async void updatePositionsNotSat()
    {
        var positionResponse = await client.PostAsync("http://74.207.254.19:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robots>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robots>("{ \"Gears\":{\"name\":\"Gears\"}}");
        print(robots);
        // Gears
        GearMove_Script.rb.MovePosition(robots.Gears.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.Gears.position.rotation,  Time.deltaTime * rotationSpeed);
        // Luz
        LuzMove_Script.rb.MovePosition(robots.Luz.position.position);
        Luz.transform.rotation = Quaternion.Slerp(Luz.transform.rotation, robots.Luz.position.rotation,  Time.deltaTime * rotationSpeed);
        // Brute
        BruteMove_Script.rb.MovePosition(robots.Brute.position.position);
        Brute.transform.rotation = Quaternion.Slerp(Brute.transform.rotation, robots.Brute.position.rotation,  Time.deltaTime * rotationSpeed);
        // Pump
        PumpMove_Script.rb.MovePosition(robots.Pump.position.position);
        Pump.transform.rotation = Quaternion.Slerp(Pump.transform.rotation, robots.Pump.position.rotation,  Time.deltaTime * rotationSpeed);
        // Sat
        // SatMove_Script.rb.MovePosition(robots.Sat.position.position);
        // Sat.transform.rotation = Quaternion.Slerp(Sat.transform.rotation, robots.Sat.position.rotation,  Time.deltaTime * rotationSpeed);
    }
}

[Serializable]
public class Robots
{
    public Robot Gears;
    public Robot Luz;
    public Robot Brute;
    public Robot Pump;
    public Robot Sat;
}
