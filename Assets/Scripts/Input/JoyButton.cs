using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool IsPressed { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressed = true;
            Debug.Log(IsPressed);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressed = false;
            Debug.Log(IsPressed);
        }
    }
}