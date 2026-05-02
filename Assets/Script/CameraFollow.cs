using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Player
    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        // ตำแหน่งที่กล้องควรไป
        Vector3 desiredPosition = target.position + offset;

        // ทำให้กล้องเคลื่อนแบบนุ่มๆ
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}