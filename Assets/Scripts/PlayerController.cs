using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpForce = 5f;
    public float boostForce = 8f;
    public float boostCooldown = 1.5f;
    
    [Header("Audio")]
    public AudioClip jumpSound;
    public AudioClip boostSound;
    public AudioClip hitMudSound;
    public AudioClip pickupSound;
    
    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private bool doubleJumpPickedUp = false;
    private bool isShielded = false;
    private float boostCharge = 0f;
    private float lastBoostTime = 0f;
    
    // Shield overlay
    private GameObject shieldOverlay;
    private AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        // Create shield overlay as child
        shieldOverlay = new GameObject("ShieldOverlay");
        shieldOverlay.transform.SetParent(transform);
        shieldOverlay.transform.localPosition = Vector3.zero;
        
        SpriteRenderer shieldRenderer = shieldOverlay.AddComponent<SpriteRenderer>();
        shieldRenderer.color = new Color(1f, 1f, 0f, 0.5f); // Semi-transparent yellow
        shieldRenderer.sortingOrder = 1;
        shieldOverlay.SetActive(false);
    }
    
    void Update()
    {
        HandleInput();
        
        // Clamp boost charge
        boostCharge = Mathf.Clamp01(boostCharge);
        
        // Update UI boost gauge
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateBoostGauge(boostCharge);
        }
    }
    
    void HandleInput()
    {
        // Primary jump/double jump on tap
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump && doubleJumpPickedUp)
            {
                Jump();
                canDoubleJump = false;
            }
        }
        
        // Boost on double tap or secondary input
        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftShift)) && 
            boostCharge >= 1.0f && Time.time > lastBoostTime + boostCooldown)
        {
            ActivateBoost();
        }
    }
    
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (audioSource && jumpSound)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
    
    void ActivateBoost()
    {
        boostCharge = 0f;
        lastBoostTime = Time.time;
        rb.AddForce(Vector2.up * boostForce, ForceMode2D.Impulse);
        
        if (audioSource && boostSound)
        {
            audioSource.PlayOneShot(boostSound);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = true;
        }
        else if (collision.gameObject.CompareTag("MudPit"))
        {
            StartCoroutine(SlowDownInMud());
            if (audioSource && hitMudSound)
            {
                audioSource.PlayOneShot(hitMudSound);
            }
        }
        else if (collision.gameObject.CompareTag("OilSlick") && !isShielded)
        {
            // Break combo and trigger game over or penalty
            if (GameManager.Instance != null)
            {
                GameManager.Instance.BreakCombo();
            }
        }
        else if (collision.gameObject.CompareTag("Ramp"))
        {
            // Award combo points and boost charge
            if (rb.velocity.y > -1f) // Not falling too fast
            {
                boostCharge += 0.25f;
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddComboPoints(50);
                }
            }
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NitroCan"))
        {
            boostCharge += 0.5f;
            PlayPickupSound();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ShieldStar"))
        {
            StartCoroutine(ActivateShield());
            PlayPickupSound();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DoubleJumpToken"))
        {
            doubleJumpPickedUp = true;
            canDoubleJump = true;
            PlayPickupSound();
            Destroy(other.gameObject);
        }
    }
    
    void PlayPickupSound()
    {
        if (audioSource && pickupSound)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
    
    IEnumerator SlowDownInMud()
    {
        float originalDrag = rb.drag;
        rb.drag = 10f; // High drag to slow down
        yield return new WaitForSeconds(0.5f);
        rb.drag = originalDrag;
    }
    
    IEnumerator ActivateShield()
    {
        isShielded = true;
        shieldOverlay.SetActive(true);
        yield return new WaitForSeconds(2f);
        isShielded = false;
        shieldOverlay.SetActive(false);
    }
    
    // Public getter for boost charge (for UI)
    public float GetBoostCharge()
    {
        return boostCharge;
    }
} 