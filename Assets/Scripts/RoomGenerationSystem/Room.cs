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


    private void Start()
    {
      
    }

    public void UpdateRoom(int order)
    {

    }
}