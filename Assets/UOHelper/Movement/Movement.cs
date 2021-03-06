using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace UO.MovementManagement
{
    public class Movement
    {
        protected Transform transformToMove;

        public Movement(Transform transformToMove)
        {
            this.transformToMove = transformToMove;
        }

        #region Position
            public void MoveTo(Vector3 targetPosition, float smoothness)
            {
                Vector3 currentPosition = transformToMove.position;

                Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * smoothness);
                transformToMove.position = smoothedPosition;
            }
            
            public IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
            {
                Vector3 currentPosition = transformToMove.position;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.position = targetPosition;
            }

            public IEnumerator MoveToTarget(Vector3 targetPosition, float duration, Action endAction)
            {
                Vector3 currentPosition = transformToMove.position;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.position = targetPosition;

                endAction.Invoke();
            }

            public IEnumerator MoveToTarget(Transform targetTransform, float duration)
            {
                Vector3 currentPosition = transformToMove.position;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.position = Vector3.Lerp(currentPosition, targetTransform.position, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.position = targetTransform.position;
            }

            public IEnumerator MoveToTarget(Transform targetTransform, float duration, Action endAction)
            {
                Vector3 currentPosition = transformToMove.position;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.position = Vector3.Lerp(currentPosition, targetTransform.position, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.position = targetTransform.position;

                endAction.Invoke();
            }
            
            /// <param name="endDistance">Stopping distance.</param>
            public IEnumerator MoveToTarget(Vector3 targetPosition, float smoothness, float endDistance)
            {
                Vector3 currentPosition = transformToMove.position;

                while(Vector3.Distance(transformToMove.position, targetPosition) > endDistance)
                {
                    currentPosition = transformToMove.position;
                    transformToMove.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * smoothness);

                    yield return null;
                }
                transformToMove.position = targetPosition;
            }
        #endregion
        
        #region Rotation
            public IEnumerator RotateTo(float duration, Vector3 targetAngles)
            {
                Quaternion currentRotation = transformToMove.rotation;
                Quaternion targetRotation = Quaternion.Euler(targetAngles);

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.rotation = Quaternion.Lerp(currentRotation, targetRotation, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.rotation = targetRotation;
            }

            public IEnumerator RotateTo(float duration, Vector3 targetAngles, Action endAction)
            {
                Quaternion currentRotation = transformToMove.rotation;
                Quaternion targetRotation = Quaternion.Euler(targetAngles);

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.rotation = Quaternion.Lerp(currentRotation, targetRotation, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.rotation = targetRotation;

                endAction.Invoke();
            }

            public IEnumerator Rotate(float duration, Vector3 axis, float speed)
            {
                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.Rotate(axis * Time.deltaTime * speed);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
            }

            public void Rotate(Vector3 axis, float rotateSpeed)
            {
                transformToMove.Rotate(axis * Time.deltaTime * rotateSpeed);
            }
        
            public IEnumerator RotateToLocal(float duration, Vector3 targetAngles)
            {
                Quaternion currentRotation = transformToMove.localRotation;
                Quaternion targetRotation = Quaternion.Euler(targetAngles);

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.localRotation = Quaternion.Lerp(currentRotation, targetRotation, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.localRotation = targetRotation;
            }

            public IEnumerator RotateToLocal(float duration, Vector3 targetAngles, Action endAction)
            {
                Quaternion currentRotation = transformToMove.localRotation;
                Quaternion targetRotation = Quaternion.Euler(targetAngles);

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.localRotation = Quaternion.Lerp(currentRotation, targetRotation, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.localRotation = targetRotation;

                endAction.Invoke();
            }

            public IEnumerator RotateLocal(float duration, Vector3 axis, float speed)
            {
                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.Rotate(axis * Time.deltaTime * speed, Space.Self);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
            }

            public void RotateLocal(Vector3 axis, float rotateSpeed)
            {
                transformToMove.Rotate(axis * Time.deltaTime * rotateSpeed, Space.Self);
            }
        #endregion

        #region Scale
            public void Scale(Vector3 targetScale, float sensitivity)
            {
                Vector3 smoothedScale = Vector3.Lerp(transformToMove.localScale, targetScale, Time.deltaTime * sensitivity);
                transformToMove.localScale = smoothedScale;
            }

            public IEnumerator Scale(float duration, Vector3 targetScale)
            {
                Vector3 currentScale = transformToMove.localScale;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.localScale = Vector3.Lerp(currentScale, targetScale, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.localScale = targetScale;
            }

            public IEnumerator Scale(float duration, Vector3 targetScale, Action endAction)
            {
                Vector3 currentScale = transformToMove.localScale;

                float elapsedTime = 0f;

                while(elapsedTime < duration)
                {
                    transformToMove.localScale = Vector3.Lerp(currentScale, targetScale, elapsedTime/duration);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }
                transformToMove.localScale = targetScale;

                endAction.Invoke();
            }
        #endregion
    }
}

