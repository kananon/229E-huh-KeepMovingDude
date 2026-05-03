using UnityEngine;

public class StoneHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            GhostAI ghost = other.GetComponent<GhostAI>();
            if (ghost != null)
            {
                // หยุดผี
                ghost.enabled = false;

                // สั่งให้ผีตัวนี้กลับมาทำงานอีกครั้ง
                StartCoroutine(ResumeGhostAfterDelay(ghost, 2f));
            }

            Destroy(gameObject);
        }
    }

    System.Collections.IEnumerator ResumeGhostAfterDelay(GhostAI ghost, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (ghost != null)
        {
            ghost.enabled = true;
        }
    }
}