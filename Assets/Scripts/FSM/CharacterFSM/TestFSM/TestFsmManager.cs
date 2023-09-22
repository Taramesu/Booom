using Parameter;
using StateType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ű����Ϊ״̬��������������ע��״̬������״̬�ȹ���
namespace FsmManager
{
    public class TestFsmManager : MonoBehaviour
    {
        private IState currentState;
        private Dictionary<TestST, IState> states = new Dictionary<TestST, IState>();

        public TestParameter parameter = new TestParameter();

        // Start is called before the first frame update
        void Start()
        {
            //�˴�ע��״̬
            states.Add(TestST.Empty, new TestEmptyState(this));

            /*------------------------------------------------------------------*/

            TransitionState(TestST.Empty);//ѡ��һ����ʼ״̬�������г�ʼʱת�루һ��ΪIdle״̬��
        }

        // ���е�ǰ��״̬�ĸ��º���ʵ�ֵ�ǰ״̬��ʵʱ����
        void Update()
        {
            currentState.OnUpdate();
        }

        //״̬ת������
        public void TransitionState(TestST type)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }
            currentState = states[type];
            currentState.OnEnter();
        }
    }
}
