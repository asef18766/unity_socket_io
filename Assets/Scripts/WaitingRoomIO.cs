using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
struct playerifo
{
    public string uuid;
    public string displayName;
}
public class WaitingRoomIO : MonoBehaviour
{
    [SerializeField] WaitingRoomWindow[] windows;
    private SocketIOComponent socket;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
        socket.On("waiting" , OnWaiting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnWaiting(SocketIOEvent e)
	{
		Debug.Log("O" + e);
	}
}
