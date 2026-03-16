using UnityEngine;

public class FishManager : MonoBehaviour
{
    public FishObj fishData;

    public enum FishState
    {
        Idle,
        Lured,
        Hooked,
        Running
    }
    
    public FishState currentState = FishState.Idle;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        
        switch (currentState)
        {
            case FishState.Idle:
                UpdateIdleState();
                break;
        }
    }

    private void CheckBounds()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        bool moved = false;

        if (viewportPos.x < 0)
        {
            viewportPos.x = 1;
            moved = true;
        }
        else if (viewportPos.x > 1)
        {
            viewportPos.x = 0;
            moved = true;
        }

        if (viewportPos.y < 0)
        {
            viewportPos.y = 1;
            moved = true;
        }
        else if (viewportPos.y > 1)
        {
            viewportPos.y = 0;
            moved = true;
        }

        if (moved)
        {
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
            worldPos.z = 0; // Maintain 2D Z position
            transform.position = worldPos;
        }
    }

    private void UpdateIdleState()
    {
        if (fishData != null && rb != null)
        {
            // Simple random movement for testing idle state and bounds
            rb.linearVelocity = transform.right * fishData.speed;
        }
    }
    
}
