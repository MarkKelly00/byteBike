using UnityEngine;

public class DestroyOnLeftExit : MonoBehaviour
{
    [Header("Destruction Settings")]
    public float destroyXPosition = -12f;
    
    void Update()
    {
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
} 