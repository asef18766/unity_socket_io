using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class LoginIO : MonoBehaviour
{
	private SocketIOComponent socket;

	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
		
		socket.On("open", OnOpen);
		socket.On("error", OnError);
		socket.On("close", OnClose);
		socket.On("login" , OnLogined);
	}

	void Update()
	{

	}

	# region Emit_Methods
	public void Login(string name)
	{
		Dictionary<string , string> data = new Dictionary<string, string>();
		data["playerName"] = name ;
		Debug.Log("emit" + (new JSONObject(data)).ToString());
		socket.Emit("login" , new JSONObject(data));
	}
	
	# endregion
	# region Listen_Events
	public void OnOpen(SocketIOEvent e)
	{
		Debug.Log("O" + e);
	}
	
	public void OnError(SocketIOEvent e)
	{
		Debug.Log("E" + e);
	}
	
	public void OnClose(SocketIOEvent e)
	{
		Debug.Log("C" + e);
	}
	public void OnLogined(SocketIOEvent e)
	{
		Debug.Log("L" + e);
	}
	# endregion
}