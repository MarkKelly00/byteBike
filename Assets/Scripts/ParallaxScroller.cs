using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [Header("Parallax Settings")]
    public float scrollSpeed = 0.2f; // Relative to player speed
    public float baseScrollSpeed = 4f; // Base speed matching obstacles
    public bool isRepeating = true;
    public float textureUnitSizeX = 10f; // Size of one texture unit for seamless scrolling
    
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        float moveAmount = baseScrollSpeed * scrollSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * moveAmount);
        
        if (isRepeating && transform.position.x <= startPosition.x - textureUnitSizeX)
        {
            transform.position = startPosition;
        }
    }
    
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
} 