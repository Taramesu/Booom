using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public RoomType type;
    public int currentLayerID;
    public int roomID;
    public Vector2 position;
    public bool isCleared;
    public Transform leftDoorPoint;
    public Transform rightDoorPoint;
    public Transform topDoorPoint;
    public Transform bottomDoorPoint;

    //public Text text;

    private void Start()
    {
        //leftDoorPoint = transform.Find("LeftDoorPoint").GetComponent<Transform>();
        //rightDoorPoint = transform.Find("RightDoorPoint").GetComponent<Transform>();
        //topDoorPoint = transform.Find("TopDoorPoint").GetComponent<Transform>();
        //bottomDoorPoint = transform.Find("BottomDoorPoint").GetComponent<Transform>();
    }

    public void UpdateRoom(int order)
    {
       //text.text = order.ToString();
    }
}