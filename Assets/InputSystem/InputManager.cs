using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UO.Singleton;

//TEST delta position & input calculation and continue...
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public static InputManager instance;

    private PointerEventData eventData;

    public bool IsFingerDown { get; private set; }
    public bool IsFingerUp { get; private set; }
    public bool IsFingerHold => IsFingerDown && !IsFingerUp;
    
    public Vector2 Input { get; private set; }
    private Vector2 deltaPosition;
    private Vector2 previousDeltaPosition;

    private void Awake() 
    {
        instance = Singleton.GetInstance<InputManager>();
    }

    private void Start() 
    {
        this.IsFingerUp = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.eventData = eventData;

        IsFingerDown = true;
        IsFingerUp = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.eventData = null;

        IsFingerDown = false;
        IsFingerUp = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        deltaPosition = eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        deltaPosition = Vector2.zero;
    }

    private void Update() 
    {
        if(eventData == null)
            return;
        
        //Calculate delta position

        Input = IsFingerHold ? GetDragInput(10f) : Vector2.zero;
        Debug.Log(Input);
    }

    private Vector2 GetDragInput(float sensitivity)
    {
        Vector2 dragInput = new Vector2();
        dragInput.x = GetDragOnSingleAxis(Vector3.right, sensitivity);
        dragInput.y = GetDragOnSingleAxis(Vector3.up, sensitivity);

        return dragInput;
    }

    private float GetDragOnSingleAxis(Vector3 axis, float sensitivity)
    {
        float input = Vector3.Dot(axis, deltaPosition) * sensitivity / Screen.width;
        return input;
    }
}
