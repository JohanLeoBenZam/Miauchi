using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;

    float h, v;

    //propiedades
    public float fuerzaMov;
    public float fuerzaSalto;
    public int saltosMax;

    public LayerMask queEsSuelo;

    private enum MovementState { idle, running, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
{


#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        h = Input.GetAxisRaw("Horizontal");
    v = Input.GetAxisRaw("Vertical");

    rb.velocity = new Vector2(h * fuerzaMov, rb.velocity.y);

    if (Input.GetButtonDown("Vertical") && IsGrounded())
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
    }

    UpdateAnimation();
}

#elif UNITY_ANDROID || UNITY_IOS
    void Update()
    {
        // Verificar entrada táctil
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Dividir la pantalla en dos zonas (izquierda y derecha)
                if (touch.position.x < Screen.width / 2)
                {
                    // Mover al personaje de izquierda a derecha
                    float moveDelta = touch.deltaPosition.x * Time.deltaTime;
                    transform.Translate(new Vector3(moveDelta, 0, 0));
                }
                else
                {
                    // Saltar al tocar la zona derecha de la pantalla
                    if (touch.phase == TouchPhase.Began)
                    {
                        Jump();
                    }
                }
            }
        }
    }
#endif

private bool IsGrounded()
{
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, queEsSuelo);
}

private void UpdateAnimation()
{
    MovementState state;
    if (h > 0f)
    {
        state = MovementState.running;
        sprite.flipX = false;
    }
    else if (h < 0f)
    {
        state = MovementState.running;
        sprite.flipX = true;
    }
    else
    {
        state = MovementState.idle;
    }
    if (rb.velocity.y > .1f)
    {
        state = MovementState.jumping;
    }
    else if (rb.velocity.y < -0.1f)
    {
        state = MovementState.falling;
    }
    anim.SetInteger("state", (int)state);
}
}
