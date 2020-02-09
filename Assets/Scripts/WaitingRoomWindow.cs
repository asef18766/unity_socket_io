using Unity;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class WaitingRoomWindow : MonoBehaviour
{
    Text nameDisplay;
    Image image;
    [SerializeField] Image unready , ready;
    public void SetplayerStatus(bool status)
    {
        if(status)
            image = ready;
        else
            image = unready;
    }
    public void SetplayerName(string name)
    {
        nameDisplay.text = name;
    }
}