using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource audioSource;

    public float moveThreshold = 0.1f; // ความเร็วขั้นต่ำถึงจะมีเสียง

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        if (speed > moveThreshold)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}