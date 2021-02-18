using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        print("server Started");
    }
    public override void OnStopServer()
    {
        print("server Stopped");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        print("client connected");
        print(conn);
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        print("client disconnected");
        print(conn);
    }
}
