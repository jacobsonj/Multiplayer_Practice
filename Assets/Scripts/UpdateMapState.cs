using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class UpdateMapState : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();

    public GameObject[] items;
    public List<IDI_Base> item_scripts;

    public int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("IDI");
        print(items.Length-1);
        // List<IDI_Base> item_scripts = new List<IDI_Base>();
        for(int i = 0; i<items.Length; i++)
        {
            item_scripts.Add(items[i].GetComponent<IDI_Base>());
        }
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
        var emptyMap = new MapState();
        emptyMap.name = "empty";
        emptyMap.itemState = new ItemState();
        emptyMap.itemState.PlayerIDI_Active = false;
        return emptyMap;
        // return false;
    }

    async void updateItemStates()
    {

        print("running function");
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/mapstates", new StringContent("{}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        var response = JsonUtility.FromJson<MapStateResponse>(positionResponseString);
        foreach(IDI_Base script in item_scripts)
        {
            script.active = getMapState(response.mapStates, script.name).itemState.PlayerIDI_Active;
        }
    }
}


[Serializable]
public class MapStateResponse
{
    public MapState[] mapStates;
}
