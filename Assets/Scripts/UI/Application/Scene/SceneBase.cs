using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBase
{
    //场景进入时
    public abstract void OnEnter();
    //场景离开时
    public abstract void OnExit();

}
