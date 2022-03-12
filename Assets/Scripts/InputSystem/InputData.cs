using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UO.InputSystem
{
    //DELTA POSITION IS NOT WORKING PROPERLY!!!
    //EXPLORE WORKING LOGIC FOR SWIPE!!!
    public static class InputData
    {
        public static bool isFingerDown => Input.GetMouseButtonDown(0);
        public static bool isFingerHold => Input.GetMouseButton(0);
        public static bool isFingerReleased => Input.GetMouseButtonUp(0);

        public static Vector3 deltaPosition = Vector3.one;
        private static Vector3 previousPosition;

        public static Vector2 input;

        public static void Update()
        {
            deltaPosition = GetDeltaPosition();

            input.x = GetDrag(Vector3.right);
            input.y = GetDrag(Vector3.up);
        }

        private static Vector3 GetDeltaPosition()
        {
            Vector3 deltaPos = default(Vector3);

            if(isFingerDown)
                previousPosition = Input.mousePosition;

            if(isFingerHold)
            {
                deltaPos = Input.mousePosition - previousPosition;
                previousPosition = Input.mousePosition;
            }
            else
                deltaPos = Vector3.zero;

            return deltaPos;
        }
    
        private static float GetDrag(Vector3 axis, float sensitivity = 10f)
        {
            float value = Vector3.Dot(axis, deltaPosition) * sensitivity / Screen.width;
            return value;
        }

        private static int GetSwipe(Vector3 axis)
        {
            float swipe = GetDrag(axis);

            if(swipe == 0)
                return 0;

            return (int)Mathf.Sign(swipe);
        }
    }
}

