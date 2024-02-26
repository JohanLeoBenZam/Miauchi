using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;

    float h, v;
    
    //propiedades
    [SerializeField] float fuerzaMov;
    [SerializeField] float fuerzaSalto;
    [SerializeField] int saltosMax;
   
    int saltosDisponibles;

    
    [SerializeField] LayerMask queEsSuelo;

    private enum MovementState {idle, running, jumping, falling }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //rb.AddForce(new Vector3(h, 0, 0) * fuerzaMov, ForceMode2D.Force);
        rb.velocity = new Vector2(h * fuerzaMov, rb.velocity.y);
        

        if (Input.GetButtonDown("Vertical") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,fuerzaSalto);
        }

        UpdateAnimation();
    }

    private bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(pies.position, radioDeteccion, queEsSuelo);
        //if (coll != null)//hay algo debajo de mis pies
        //{
        //    if (rb.velocity.y <= 0)//solo si estoy cayendo
        //    {
        //        saltosDisponibles = saltosMax;//reseteo los saltos
        //    }
        //    anim.SetBool("falling", false);
        //    return true;//devuelvo true
        //}
        //else //si estoy en el aire
        //{
        //    if (rb.velocity.y <= 0)
        //    {
        //        anim.SetBool("falling", true);
        //    }
        //    return false; //devuelvo false 
        //}
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
