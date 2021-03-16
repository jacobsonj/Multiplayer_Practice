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

    public float rotationSpeed = 10f;
    public Vector3 currentEulerAngles;
    

    // public Vector3 newPos;


    // Start is called before the first frame update
    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();  
    }
    private int frameCount = 0;
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        frameCount++;
       
        if(!GearMove_Script.isLocalPlayer)
        {
            // if(frameCount%30 == 0)
            // {
            updatePositions();
            // }
        }
        
    }
    

    async void updatePositions()
    {
        var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var robots = JsonUtility.FromJson<Robot>(positionResponseString);
        print(robots);
        GearMove_Script.rb.MovePosition(robots.position.position);
        Gears.transform.rotation = Quaternion.Slerp(Gears.transform.rotation, robots.position.rotation,  Time.deltaTime * rotationSpeed);
    }
}

