using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using SocketIO;
struct Playerinfo
{
    public string uuid;
    public string displayName;
    public bool ready;
}
public class WaitingRoomIO : MonoBehaviour
{
    Playerinfo[] playerinfos;
    [SerializeField] WaitingRoomWindow[] windows;
    private SocketIOComponent socket;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("waiting", OnWaiting);
        socket.On("enterGame", OnEnterGame);
        playerinfos = new Playerinfo[windows.Length];
        StartCoroutine(GetWaiting());
    }

    void updateWindows()
    {
        for (int u = 0; u != windows.Length; ++u)
        {
            windows[u].isReady = playerinfos[u].ready;
            windows[u].setDisplayName(playerinfos[u].displayName);
        }
    }
    public void OnWaiting(SocketIOEvent e)
    {
        Debug.Log("Waiting : " + e);
        JSONObject jobj = e.data;
        var players = jobj["players"].list;
        for (int u = 0; u < windows.Length; ++u)
        {
            if (u < players.Count)
            {
                playerinfos[u].uuid = players[u]["uuid"].str;
                playerinfos[u].displayName = players[u]["playerName"].str;
                playerinfos[u].ready = players[u]["ready"].ToString() == "true"; // trap in javascript...QQ
            }
            else
            {
                playerinfos[u].uuid = "";
                playerinfos[u].displayName = "";
                playerinfos[u].ready = false;
            }
        }
        updateWindows();
    }
    public void OnEnterGame(SocketIOEvent e)
    {
        Debug.Log("EnterGame : " + e);
        SceneManager.LoadScene("BattleGround");
    }
    IEnumerator GetWaiting()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            socket.Emit("waiting");
        }
    }
}
