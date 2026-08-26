using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);

    [Header("Distance")]
    [SerializeField, Min(0f)] private float cameraDistance = 5f;
    [SerializeField, Min(0f)] private float minimumDistance = 0.5f;

    [Header("Wall Clipping")]
    [SerializeField, Min(0f)] private float collisionRadius = 0.25f;
    [SerializeField, Min(0f)] private float wallPadding = 0.1f;
    [SerializeField] private LayerMask collisionLayers = ~0;

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
}
