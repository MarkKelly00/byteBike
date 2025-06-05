using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Movement Settings")]
    public float scrollSpeed = 4f;
    
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
    }
    
    public void SetSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
} 