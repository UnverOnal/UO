using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UO.MovementManagement
{
    public class Movement3D : Movement
    {
        public Movement3D(Transform transformToMove) : base(transformToMove){}

        public void MoveForward(Vector3 direction, float moveFactor, float smoothness = 1.5f)
        {
            Vector3 targetPosition = transformToMove.position + direction * moveFactor;

            MoveToTarget(targetPosition, smoothness);
        }

        public void MoveSides(float input ,Vector3 axis, float moveFactor, float border, Transform platform, float smoothness = 3f)
        {
            Vector3 targetPosition = transformToMove.position + axis * input * moveFactor;
            targetPosition.x = Mathf.Clamp(targetPosition.x, platform.position.x - border, platform.position.x + border);

            MoveToTarget(targetPosition, smoothness);
        }
    }
}
