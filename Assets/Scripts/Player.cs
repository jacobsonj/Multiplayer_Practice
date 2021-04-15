// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Text;
// using System.Web.Script.Serialization;


public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 direction;
    public float moveSpeed = 10;
    public float rotateSpeed = 10f;
    private long time = 0;
    private static readonly HttpClient client = new HttpClient();

    public bool toggleSelected;
    public bool isLocalPlayer;
    public bool isBeingCarried;

    public string name;
    public GameObject Brute;
    public Vector3 liftPos;

    

    void Start()
    {
        liftPos = new Vector3(0,1,0);
    }
    async void HandleMovement()
    {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        // Vector3 Movement = new Vector3(moveHorizontal * 0.1f, 0, moveVertical * 0.1f);
        // transform.position = transform.position + Movement;
        
        
        // if(direction != Vector3.zero)
        // {
        //     return;
        // }

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);


        // if(time == 0)
        // {
        //     time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        // }
        // if(time == new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
        // {
        //     return;
        // }
        // print(time);
        
        // if(!isBeingCarried)
        // {
            sendPos();
        // }
        
        
    }

    async void sendPos()
    {
        var currentPos = transform.position.Round(2);
        print("LOOOOOOOOK HEEEEEEEEERE" + currentPos);
        // var currentRot = transform.rotation.Round(2)
        // print(name);
        time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new RobotPosition();
        robot.name = name;
        robot.position = new Position();
        robot.position.position = currentPos;
        robot.position.rotation = transform.rotation;
    
        string json = JsonUtility.ToJson(robot);

        // var response = await client.PostAsync("http://74.207.254.19:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }
    
    async void sendState()
    {
        var currentPos = transform.position.Round(2);
        
        // print(name);
        time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new RobotState();
        robot.name = name;
        robot.state = new State();
        robot.state.isBeingCarried = isBeingCarried;
    
        string json = JsonUtility.ToJson(robot);

        // var response = await client.PostAsync("http://74.207.254.19:7000/state/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/state/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }

    void Update()
    {

        // print("LOOOOOOOOK HEEEEEEEEERE");
       // if(time == 0)
        // {
        //     time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        // }
        // if(time == new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
        // {
        //     return;
        // }
        // print(time);
        
        // if(!isBeingCarried)
        // {
            // sendPos();
        // } 
    }

    

    async void FixedUpdate()
    {
        if (toggleSelected == true)
        {
            HandleMovement();  
        }

        
        
        if(isBeingCarried)
        {
            transform.position = Brute.transform.TransformPoint(liftPos);
            GetComponent<Rigidbody>().useGravity = false;
        }
        else if(!isBeingCarried)
        {
           GetComponent<Rigidbody>().useGravity = true; 
        }
        
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }

    public void toggleIsBeingCarried()
    {
        isBeingCarried = !isBeingCarried;
        sendPos();
        sendState();
    }
}

[Serializable]
public class Position
{
    public Vector3 position;
    public Quaternion rotation;
}

[Serializable]
public class RobotPosition
{
    public string name;
    public Position position;
}

[Serializable]
public class RobotState
{
    public string name;
    public State state;
}

// [Serializable]
// public class Bots
// {
//     public Robot robot;
// }

[Serializable]
public class State
{
    // public bool isLocalPlayer;
    // public bool toggleSelected;
    public bool isBeingCarried;
}

