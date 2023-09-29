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