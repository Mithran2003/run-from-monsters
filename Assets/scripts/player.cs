using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    
    [SerializeField]
    private float moveForce=10f;
    [SerializeField]
    private float jumpForce= 12f;
    private float movementX;
    private float movementY;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string Walk_ANIMATION = "walk";
    private bool isGrounded = true;
    
    private string ENEMY_TAG = "Enemy";
   
   
   

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void FixedUpdate() 
    {   
       
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        
    }
    void PlayerMoveKeyboard( )
    {
        movementX=Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    
    }
    void AnimatePlayer()
    {
        if(movementX>0)
        {
            anim.SetBool(Walk_ANIMATION,true);
            sr.flipX= false;
            //we are moving towards right

        }
        else if (movementX<0)
        {
            anim.SetBool(Walk_ANIMATION,true);
            sr.flipX=true;
            // we are moving towards left 
        }
        else
        {
            anim.SetBool(Walk_ANIMATION,false);
            // we are standing ideal
            
        }

    }
    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
           
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
            isGrounded = false;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
           // Debug.Log("we landed on ground");
        }
        if (other.gameObject.CompareTag(ENEMY_TAG)){
             Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}   
    
    
 
    


