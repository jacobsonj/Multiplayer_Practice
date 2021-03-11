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


    // Start is called before the first frame update
    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();  
    }
    private int frameCount = 0;
    // Update is called once per frame
    void Update()
    {
        frameCount++;
        if(frameCount%30 == 0)
        {
            updatePositions();
        }
    }

    async void updatePositions()
    {
        var robotGears = new Robot();
        var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        // var robots = JsonUtility.FromJson<Dictionary<string, Dictionary<string, string>>>(positionResponseString);
        var robots = JsonUtility.FromJson<Bots>(positionResponseString);
        JsonUtility.FromJsonOverwrite(positionResponseString, robotGears);
        print(positionResponseString[20]);
        print(robots);
        // var newPosition = new Vector3(float.Parse(robots["Gears"]["x"]), float.Parse(robots["Gears"]["y"]), float.Parse(robots["Gears"]["z"]));
        // var newPosition = new Vector3(1,1,1);
        // GearMove_Script.rb.MovePosition(newPosition);
        
        // print(newPosition);
        // Gears.transform.position = newPosition;
    }
}

