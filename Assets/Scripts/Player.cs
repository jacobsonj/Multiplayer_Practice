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

    public string name;

    

    void Start()
    {
        
    }
    async void HandleMovement()
    {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        // Vector3 Movement = new Vector3(moveHorizontal * 0.1f, 0, moveVertical * 0.1f);
        // transform.position = transform.position + Movement;
        
        
        // if(Movement == new Vector3(0,0,0) )
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
        print(time);
        sendPos();
        
    }

    async void sendPos()
    {
        // print(name);
        time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new Robot();
        robot.name = name;
        robot.position = new Position();
        robot.position.position = transform.position;
        robot.position.rotation = transform.rotation;
    
        string json = JsonUtility.ToJson(robot);

        var response = await client.PostAsync("http://localhost:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }

    async void FixedUpdate()
    {
        if (toggleSelected == true)
        {
            HandleMovement();  
        }
        
        
        
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }

}

[Serializable]
public class Position
{
    public Vector3 position;
    public Quaternion rotation;
}

[Serializable]
public class Robot
{
    public string name;
    public Position position;
}

[Serializable]
public class Bots
{
    public Robot robot;
}

