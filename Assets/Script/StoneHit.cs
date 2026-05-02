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
                ghost.enabled = false;
                Invoke("ResumeGhost", 2f);
            }

            Destroy(gameObject);
        }
    }

    void ResumeGhost()
    {
        GameObject ghost = GameObject.FindGameObjectWithTag("Ghost");
        if (ghost != null)
        {
            ghost.GetComponent<GhostAI>().enabled = true;
        }
    }
}