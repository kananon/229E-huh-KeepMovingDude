using UnityEngine;

public class PlayerThrowProjectile : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform throwPoint;
    public float shootForce = 12f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject stone = Instantiate(stonePrefab, throwPoint.position, Quaternion.identity);

        Rigidbody2D rb = stone.GetComponent<Rigidbody2D>();

        // หาทิศทางจาก Player ไป Mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direction = (mousePos - throwPoint.position).normalized;

        // ยิงแบบ projectile
        rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
    }
}