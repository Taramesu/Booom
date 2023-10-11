using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInputSimulator : Singleton2Manager<KeyboardInputSimulator>
{
   

    public void PressP()
    {
        // �������д��Ҫִ�е��߼�

        // ģ�ⰴ�� "P" ��
        SimulateKeyPress(KeyCode.P);

        // ģ���ͷ� "P" ��
        SimulateKeyRelease(KeyCode.P);
    }

    private void SimulateKeyPress(KeyCode keyCode)
    {
        ExecuteEvents.Execute<IPointerDownHandler>(
            target: gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: (handler, eventData) => handler.OnPointerDown((PointerEventData)eventData)
        );

        ExecuteEvents.Execute<IPointerClickHandler>(
            target: gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: (handler, eventData) => handler.OnPointerClick((PointerEventData)eventData)
        );

        ExecuteEvents.Execute<IPointerUpHandler>(
            target: gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: (handler, eventData) => handler.OnPointerUp((PointerEventData)eventData)
        );
    }

    private void SimulateKeyRelease(KeyCode keyCode)
    {
        ExecuteEvents.Execute<IPointerDownHandler>(
            target: gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: (handler, eventData) => handler.OnPointerDown((PointerEventData)eventData)
        );

        ExecuteEvents.Execute<IPointerUpHandler>(
            target: gameObject,
            eventData: new PointerEventData(EventSystem.current),
            functor: (handler, eventData) => handler.OnPointerUp((PointerEventData)eventData)
        );
    }
}