using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;

public class Box_Base : MonoBehaviour
{
    public bool activeBox = false;
    public string name;
    public Rigidbody rb;

    public GameObject Brute;
    public Player BruteMove_Script;
    private static readonly HttpClient client = new HttpClient();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public async void sendBox()
    {
        print("sending the box State");
        var box = new BoxState();
        box.name = name;
        box.position = new Position();
        box.position.position = transform.position;
        box.position.rotation = transform.rotation;
    
        string json = JsonUtility.ToJson(box);

        // var response = await client.PostAsync("http://74.207.254.19:7000/boxstate/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/boxstate/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }
}

// [Serializable]
// public class Position
// {
//     public Vector3 position;
//     public Quaternion rotation;
// }

[Serializable]
public class BoxState
{
    public string name;
    public Position position;
}
