using UnityEngine;
using UnityEngine.UI;
using SocketIO;
public class WaitingRoomWindow : MonoBehaviour
{
    public bool _isReady;
    public bool isReady
    {
        set
        {
            if (value)
            {
                print("value:"+value.ToString());
                image.sprite = _ready;
                print("set ready image");

            }
            else
            {
                image.sprite = _unready;
                print("set unready image");
            }
            _isReady = value;
        }
    }
    [SerializeField] Text nameDisplay;
    [SerializeField] Image image;
    [SerializeField] Sprite unready = null, ready = null;
    static Sprite _unready = null, _ready = null;
    void Start()
    {
        if (_unready == null && unready != null)
        {
            _unready = unready;
        }
        if (_ready == null && ready != null)
        {
            _ready = ready;
        }
        isReady = false;
    }
    public void setDisplayName(string name)
    {
        nameDisplay.text = name;
    }
}