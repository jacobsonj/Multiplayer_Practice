using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class UpdateMapState : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public GameObject Gears_IDI;

    public Gears_IDI GearsIDI_script;

    public int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        GearsIDI_script = Gears_IDI.GetComponent<Gears_IDI>();
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        if(frameCount%10 == 0)
        {
            updateItemStates();
        }
    }

    void FixedUpdate()
    {
        
    }    

    async void updateItemStates()
    {

        print("running function");
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/mapstates", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        print(" passed position response string");
        var map = JsonUtility.FromJson<MapStates>(positionResponseString);
        print("passed map");
        print(map.Gears_IDI.itemState);
        print(map.Gears_IDI.itemState.GearsIDI_Active);

        GearsIDI_script.active  = map.Gears_IDI.itemState.GearsIDI_Active;
        
    }
}


[Serializable]
public class MapStates
{
    public MapState Gears_IDI;
}
