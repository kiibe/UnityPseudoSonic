using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {
	//variables salto
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 0.1f;
	public LayerMask mascaraSuelo;
	private Animator animator;

	//variables correr
	private bool corriendo = false;
	private bool rotarPjizq = false;
	private bool rotarPjder = true;

    // bONUS
    public float moveSpeed = 10f;
    public float jumpSpeed = 5f;

	// Use this for initialization
	void Start () 
	{


	}

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
        if (corriendo)
        {
            animator.SetFloat("VelX", moveSpeed);
            enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
            //animator.SetBool("isGrounded", enSuelo);
        }
        else 
        {
            animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
            enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
            //animator.SetBool("isGrounded", enSuelo);
        }
        
	}

	// Update is called once per frame
	void Update() 
	{
        //Next two if statements are for moving left and right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
            if (rotarPjder == false)
            {
                transform.Rotate(30f, 180f, 0f);
                rotarPjder = true;
            }
            rotarPjizq = false;
            corriendo = true;
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
            if (rotarPjizq == false)
            {
                transform.Rotate(30f, 180f, 0f);
                rotarPjizq = true;
            }

            rotarPjder = false;
            corriendo = true;
        }
        else
        {
            corriendo = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Jump Script
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }


}