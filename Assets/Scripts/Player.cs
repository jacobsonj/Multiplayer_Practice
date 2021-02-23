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
    public float rotateSpeed = 10;
    private long time = 0;
    private static readonly HttpClient client = new HttpClient();

    public bool toggleSelected;

    

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


        if(time == 0)
        {
            time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
        if(time == new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
        {
            return;
        }
        // print(time);
        sendPos();
        
    }

    async void sendPos()
    {
        time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var posx = transform.position.x.ToString();
        var posy = transform.position.y.ToString();
        var posz = transform.position.z.ToString();
        
        var rotx = transform.position.x.ToString();
        var roty = transform.position.y.ToString();
        var rotz = transform.position.z.ToString();
        
        var robot = new Robot();
        robot.name = "gears";
        robot.position = new Position();
        robot.position.x = posx;
        robot.position.y = posy;
        robot.position.z = posz;
        robot.position.rotx = rotx;
        robot.position.roty = roty;
        robot.position.rotz = rotz;
    
        var values = new Dictionary<string, string>
        {
            // {name: "gears"}
            { "posx", posx },
            { "posy", posy },
            { "posz", posz },
            { "rotx", rotx },
            { "roty", roty },
            { "rotz", rotz }
        };
        // print(transform.position);
        
        // var json = new JavaScriptSerializer().Serialize(robot);
        string json = JsonUtility.ToJson(robot);
        // print(json);
        
        // var content = new FormUrlEncodedContent(json);

        var response = await client.PostAsync("http://localhost:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
        
        var positionResponse = await client.PostAsync("http://localhost:7000/positions", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        print(positionResponseString);
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
    public string x;
    public string y;
    public string z;
    public string rotx;
    public string roty;
    public string rotz;

}

[Serializable]
public class Robot
{
    public string name;
    public Position position;
}
