using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UO.Singleton;

//TEST current features & continue ...
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static InputManager instance;

    private PointerEventData eventData;

    public bool isFingerDown;
    public bool isFingerUp;
    public bool isFingerHold => isFingerDown && !isFingerUp;

    private void Awake() 
    {
        instance = Singleton.GetInstance<InputManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.eventData = eventData;

        isFingerDown = true;
        isFingerUp = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.eventData = null;

        isFingerDown = false;
        isFingerUp = true;
    }
}
