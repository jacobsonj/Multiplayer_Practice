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

    public float rotationSpeed = 10;
    public Vector3 currentEulerAngles;

    // public Vector3 newPos;


    // Start is called before the first frame update
    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();  
    }
    private int frameCount = 0;
    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        frameCount++;
        // if(frameCount%5 == 0)
        // {
        //     getPositions();
        // }
        if(!GearMove_Script.isLocalPlayer)
        {
            // if(frameCount%30 == 0)
            // {
            updatePositions();
            
        }
        
    }
    

    async void getPositions()
    {
        // var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        // var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        // // var robots = JsonUtility.FromJson<Dictionary<string, Dictionary<string, string>>>(positionResponseString);
        // var robots = JsonUtility.FromJson<Robot>(positionResponseString);
        // var x = float.Parse(robots.position.x);
        // var y = float.Parse(robots.position.y);
        // var z = float.Parse(robots.position.z);
        // print(x);
        // print(y);
        // print(z);
        // newPos = new Vector3(x, y, z);
    }

    async void updatePositions()
    {

        var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        // var robots = JsonUtility.FromJson<Dictionary<string, Dictionary<string, string>>>(positionResponseString);
        var robots = JsonUtility.FromJson<Robot>(positionResponseString);
        var x = float.Parse(robots.position.x);
        var y = float.Parse(robots.position.y);
        var z = float.Parse(robots.position.z);
        var rotx = float.Parse(robots.position.rotx);
        var roty = float.Parse(robots.position.roty);
        var rotz = float.Parse(robots.position.rotz);
        
        
        var newX = x.ToString("0.00");
        var newY = y.ToString("0.00");
        var newZ = z.ToString("0.00");
        var newXF = float.Parse(newX);
        var newYF = float.Parse(newY);
        var newZF = float.Parse(newZ);
        print(newXF);
        // print(newY);
        // print(newZ);
        // x = float.Parse(x);
        // y = Math.Round(y * 100f) / 100f ;
        // z = Math.Round(z * 100f) / 100f ;
        // print(Math.Round(x * 100f) / 100f);
        // print(y);
        // print(z);
        // newPos = new Vector3(newX, newY, newZ);
        var newPos = new Vector3(x,y,z);
        var newRot = new Vector3(rotx, roty, rotz);

        // var currentEulerAngles;
        currentEulerAngles += new Vector3(rotx, roty, rotz) * Time.deltaTime * rotationSpeed;
        
        
        // JsonUtility.FromJsonOverwrite(positionResponseString, robotGears);
        // print(positionResponseString);
        
        
        // var newPosition = new Vector3(1,1,1);
        GearMove_Script.rb.MovePosition(newPos);
        
        // print(newPosition);
        // Gears.transform.eulerAngles = currentEulerAngles;
    }
}

