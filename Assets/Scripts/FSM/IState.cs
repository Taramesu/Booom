using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态接口，所有具体子状态必须实现此接口
public interface IState
{
    public void OnEnter();

    public void OnUpdate();
    public void OnExit();
}
