using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // --- Unity Lifecycle ---

    // PlayerCamera.LateUpdate
    private void LateUpdate()
        {
            if (target == null)
                return;
    
            Vector3 focusPoint = target.position + targetOffset;
            Vector3 desiredDirection = -target.forward;
            float safeDistance = FindSafeDistance(focusPoint, desiredDirection);
    
            transform.position = focusPoint + desiredDirection * safeDistance;
            transform.LookAt(focusPoint);
        }

    // --- Methods ---

    // PlayerCamera.FindSafeDistance
    private float FindSafeDistance(Vector3 focusPoint, Vector3 direction)
        {
            if (!Physics.SphereCast(
                    focusPoint,
                    collisionRadius,
                    direction,
                    out RaycastHit hit,
                    cameraDistance,
                    collisionLayers,
                    QueryTriggerInteraction.Ignore))
            {
                return cameraDistance;
            }
    
            return Mathf.Clamp(
                hit.distance - wallPadding,
                minimumDistance,
                cameraDistance);
        }

    // --- Other ---

    // PlayerCamera.Imported1
    [Header("Target")]
        [SerializeField] private Transform target;

    // PlayerCamera.Imported2
    [SerializeField] private Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);

    // PlayerCamera.Imported3
    [Header("Distance")]
        [SerializeField, Min(0f)] private float cameraDistance = 10f;

    // PlayerCamera.Imported4
    [SerializeField, Min(0f)] private float minimumDistance = 0.5f;

    // PlayerCamera.Imported5
    [Header("Wall Clipping")]
        [SerializeField, Min(0f)] private float collisionRadius = 0.25f;

    // PlayerCamera.Imported6
    [SerializeField, Min(0f)] private float wallPadding = 0.1f;

    // PlayerCamera.Imported7
    [SerializeField] private LayerMask collisionLayers = ~0;
}
