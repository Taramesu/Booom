using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInputSimulator : Singleton2Manager<KeyboardInputSimulator>
{
   

    public void PressP()
    {
        // 在这里编写需要执行的逻辑

        // 模拟按下 "P" 键
        SimulateKeyPress(KeyCode.P);

        // 模拟释放 "P" 键
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