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
    
    }

    public void printthething()
    {
        print("print the thing!!!!!!!!!!!!!!!");
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
    
    public async void sendState()
    {
        print("player toggle selected" + toggleSelected);
        
        // print(name);
        time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new RobotState();
        robot.name = name;
        robot.state = new State();
        robot.state.isBeingCarried = isBeingCarried;
        robot.state.toggleSelected = toggleSelected;
    
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
        if (isLocalPlayer == true)
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
        print(toggleSelected);
        sendState();
    }

    public void toggleIsBeingCarried()
    {
        if(!isBeingCarried)
        {
            isBeingCarried = !isBeingCarried;
            sendState();   
        }
        else if(isBeingCarried)
        {
            if(isLocalPlayer)
            {
                isBeingCarried = !isBeingCarried;
                sendState();   
            }
            else if(!isLocalPlayer)
            {
                StartCoroutine(ExecuteAfterTime(3));
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
        {

            var rb = GetComponent<Rigidbody>();
            isBeingCarried = !isBeingCarried;
            sendPos();
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            isLocalPlayer = true;
            sendState();
            yield return new WaitForSeconds(time);
            isLocalPlayer = false;
            rb.constraints = RigidbodyConstraints.None;
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
    public bool toggleSelected;
}

