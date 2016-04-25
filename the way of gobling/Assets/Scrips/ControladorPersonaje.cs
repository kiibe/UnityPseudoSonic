using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {
	//variables salto
	public float fuerzaSalto = 400f;
	public Rigidbody2D rb;
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio = 0.1f;
	public LayerMask mascaraSuelo;
	private Animator animator;

	//variables correr
	private bool corriendo = false;
	public float velocidad = 5f;

	// Use this for initialization
	void Start () 
	{
		// Get the instance here and stores it as a class member.
		rb = GetComponent<Rigidbody2D>();
	}

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		if (corriendo) 
		{
			rb.velocity = new Vector2 (velocidad, rb.velocity.y);
		}
		animator.SetFloat ("VelX", rb.velocity.x);
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool ("isGrounded", enSuelo);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			if (corriendo) {
				//hacer que salte si puede saltar
				if (enSuelo) 
				{
					rb.AddForce (new Vector2 (0, fuerzaSalto));
				}
			} 
			else 
			{
				corriendo = true;
			}
		
		}
	}
}
