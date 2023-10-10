using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerParameter
{
    public float currentHP;

    public float ATK;

    public float speed;

    public float shootRate;

    public bool attacking;

    public string headSpritePath;

    public Animator animator;

    public Transform transform;

    public Vector3 currentPosition;

    public int currentRoomID;

    public SpriteRenderer headSpriteRenderer;
}  
