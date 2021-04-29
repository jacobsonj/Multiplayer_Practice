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
    public GameObject Luz_IDI;

    public Gears_IDI GearsIDI_script;
    public Luz_IDI LuzIDI_script;

    public int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        GearsIDI_script = Gears_IDI.GetComponent<Gears_IDI>();
        LuzIDI_script = Luz_IDI.GetComponent<Luz_IDI>();
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

    MapState getMapState(MapState[] states, string name)
    {
        foreach(MapState state in states)
        {
            if(state.name == name)
            {
                return state;
            }
        }
        return new MapState();
    }

    async void updateItemStates()
    {

        print("running function");
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/mapstates", new StringContent("{}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var response = JsonUtility.FromJson<MapStateResponse>(positionResponseString);
        
        GearsIDI_script.active = getMapState(response.mapStates, "Gears_IDI").itemState.PlayerIDI_Active;
        print(GearsIDI_script.active);
        // GearsIDI_script.active  = map.Gears_IDI.itemState.PlayerIDI_Active;

        LuzIDI_script.active  = getMapState(response.mapStates, "Luz_IDI").itemState.PlayerIDI_Active;
        
    }
}


[Serializable]
public class MapStateResponse
{
    public MapState[] mapStates;
}
