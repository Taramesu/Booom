using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//״̬�ӿڣ����о�����״̬����ʵ�ִ˽ӿ�
public interface IState
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}
