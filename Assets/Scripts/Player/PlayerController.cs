using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float Speed = 10.0f;

    [Header("Vertical Movement")]
    public float JumpForce = 2.0f;
    public Vector2 GroundCheckOffset;
    public float GroundCheckRadius;
    public LayerMask GroundMask;

    [Header("Attack")]
    public WeaponManager Weapon;


    [Header("Visuals")]
    public Animator Animator;
    public SpriteRenderer Renderer;

    [Header("Audio")]
    public VaryingPitchAudioSource JumpingSound;
    public VaryingPitchAudioSource LandingSound;

    private Rigidbody2D _rigidbody2D;
    private bool _prevIsGroundedState;
    private bool _isGrounded;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector2 relativePos = transform.position;

        Gizmos.DrawWireSphere(relativePos + GroundCheckOffset, GroundCheckRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical Movement
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            JumpingSound.Play();
        }

        if (!_prevIsGroundedState && _isGrounded)
        {
            LandingSound.Play();
        }

        // Attack
        if (Input.GetButton("Fire1"))
        {
            Weapon.Attack();
        }

        _prevIsGroundedState = _isGrounded;
        CalculateGrounded();
    }

    void FixedUpdate()
    {
        // Horizontal Movement
        float hInput = Input.GetAxisRaw("Horizontal");

        Vector2 velocity = _rigidbody2D.velocity;

        velocity.x = hInput * Speed * Time.deltaTime;
        _rigidbody2D.velocity = velocity;

        FlipSprite(hInput);

        Vector2 dir = velocity.normalized;
        Animator.SetFloat("horizontal", Mathf.Abs(dir.x));
        Animator.SetFloat("vertical", Mathf.Abs(dir.y));
    }

    void FlipSprite(float direction)
    {

        if (direction < 0.1 && direction > -0.1)
        {
            return;
        }


        float dirSign = Mathf.Sign(direction);

        Vector3 scale = transform.localScale;
        scale.x = dirSign;
        transform.localScale = scale;

        // needs to flip the sign
        Weapon.SetWeaponSortingOrder((int)dirSign * -1);
    }

    void CalculateGrounded()
    {
        var pos = (Vector2)transform.position + GroundCheckOffset;
        Collider2D col = Physics2D.OverlapCircle(pos, GroundCheckRadius, GroundMask);

        _isGrounded = col != null;
    }
}
