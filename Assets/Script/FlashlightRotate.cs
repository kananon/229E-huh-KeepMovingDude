using UnityEngine;

public class FlashlightRotate : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        // สมมติว่ารูปเดิมชี้ขึ้นข้างบน ให้ลบออก 90 องศาเพื่อให้ตรงกับเมาส์


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        float offset = -90f; 
        transform.rotation = Quaternion.Euler(0, 0, angle + offset);
    }
}