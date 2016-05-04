using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {
	//variables salto
	public float fuerzaSalto = 400f;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 0.1f;
	public LayerMask mascaraSuelo;
	private Animator animator;

	//variables correr
	private bool corriendo = false;
	public float velocidad = 5f;
	private bool rotarPjizq = false;
	private bool rotarPjder = true;

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
		/*if (corriendo) 
		{
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
		}
        animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo);*/
	}

	// Update is called once per frame
	void Update() 
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
		{
            GetComponent<Rigidbody2D>().velocity = Vector2.left* velocidad;
			if (rotarPjizq == false) 
			{
				transform.Rotate(30f,180f,0f);
				rotarPjizq = true;
			}

			rotarPjder = false;
        }
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
			
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
			if (rotarPjder == false) {
				transform.Rotate (30f, 180f, 0f);
				rotarPjder = true;
			}
			rotarPjizq = false;
        }
        else if (Input.GetKey(KeyCode.Space)) 
        {
			if (corriendo) {
				if (enSuelo) {
					GetComponent<Rigidbody2D> ().AddForce ((new Vector2 (0, fuerzaSalto)));
				}
			} 
			else 
			{
				corriendo = true; 
			}
        }
        else 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero * 0;
        }
	}
		
		
}
