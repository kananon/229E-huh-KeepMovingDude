using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;     // แรงที่ใช้ในการเคลื่อนที่
    public float maxSpeed = 5f;       // จำกัดความเร็วสูงสุด

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // รับ input จาก keyboard
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        Move();
        LimitSpeed();
    }

    void Move()
    {
        // ใช้ AddForce ตามโจทย์ (Physics-based movement)
        rb.AddForce(movement * moveForce);
    }

    void LimitSpeed()
    {
        // จำกัดความเร็วไม่ให้ไวเกินไป
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}