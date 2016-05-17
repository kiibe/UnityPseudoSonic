using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorPersonaje : MonoBehaviour {
	//variables salto
	private bool enSuelo = true;
	public Transform comprobadorSuelo;
    public Transform spawnPoint;
	float comprobadorRadio = 1f;
	public LayerMask mascaraSuelo;
	private Animator animator;

	//variables correr
	private bool corriendo = false;
	private bool rotarPjizq = false;
	private bool rotarPjder = true;


	// bONUS
	public float moveSpeed = 10f;
	public float jumpSpeed = 26f;

	// Puntos acumulados
	private int score = 0;

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
			animator.SetBool("isGrounded", enSuelo);
		}
		else 
		{
			animator.SetFloat("VelX", GetComponent<Rigidbody2D>().velocity.x);
			enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
			animator.SetBool("isGrounded", enSuelo);
		}

	}

	// Update is called once per frame
	void Update() 
	{
		//Next two if statements are for moving left and right
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
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
		if (Input.GetKey (KeyCode.Space) && enSuelo) 
		{
            //Jump Script
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
            animator.SetBool ("isGrounded", false);

		}
		else 
		{
			animator.SetBool ("isGrounded", true);

		}
	}

    // Die
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pinchos")
        {
            // Aplicar animación GameOver
            //animator.SetTrigger("GameOver");
            SceneManager.LoadScene("gameOver");
        }
    }

    // Recoge los items, suma puntos y actualiza marcador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            this.score++;
            TextMesh marcador = GameObject.Find("Score").GetComponent<TextMesh>();
            marcador.text = this.score.ToString();

        }
    }


}


