using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public RoomType type;
    public int currentLayerID;
    public Vector2 position;
    public Transform leftDoorPoint;
    public Transform rightDoorPoint;
    public Transform topDoorPoint;
    public Transform bottomDoorPoint;

    //public Text text;

    private void Start()
    {
        //text = gameObject.AddComponent<Text>();
    }

    public void UpdateRoom(int order)
    {
       //text.text = order.ToString();
    }
}