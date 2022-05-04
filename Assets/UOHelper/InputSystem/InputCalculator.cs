using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UO.Singleton;

public class InputCalculator : MonoBehaviour
{
    public static InputCalculator instance;

    private Vector2 pointerPosition;

    private void Update() 
    {    
        UOInput.IsPointerDown = Input.GetMouseButtonDown(0);
        UOInput.IsPointerUp = Input.GetMouseButtonUp(0);
        UOInput.IsPointerHold = Input.GetMouseButton(0);

        if (UOInput.IsPointerDown)
        {
            pointerPosition = UOInput.PointerPosition;
            UOInput.PointerPreviousPosition = pointerPosition;
            UOInput.PointerDownPosition = pointerPosition;
            UOInput.CanSwipe = true;
            return;
        }

        UOInput.PointerPreviousPosition = pointerPosition;
        pointerPosition = UOInput.PointerPosition;
    }
}
