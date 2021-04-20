using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class IDI_Base : MonoBehaviour
{
    public bool active = false;
    public string name;
    private static readonly HttpClient client = new HttpClient();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void sendState()
    {
        
        // time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var map = new MapState();
        map.name = name;
        print(map.name);
        map.itemState = new ItemState();
        map.itemState.GearsIDI_Active = active;
        
    
        string json = JsonUtility.ToJson(map);

        // var response = await client.PostAsync("http://74.207.254.19:7000/state/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/mapstate/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }
}


[Serializable]
public class MapState
{
    public string name;
    public ItemState itemState;
}

[Serializable]
public class ItemState
{
    public bool GearsIDI_Active;
}
