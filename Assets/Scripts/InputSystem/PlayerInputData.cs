using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputData : Singleton2Manager<PlayerInputData>
{
    public Vector2 moveVal;

    public Vector2 attackVal;

    public bool dropBoomVal;

    public bool openBagVal;

    public int selectItemsVal;

    public bool useItemsVal;

    public bool pauseGameVal;

}
