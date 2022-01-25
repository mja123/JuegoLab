using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GameManager gameManager;
    public bool saltando;   
    public Text textScore;
    public float tiempo = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        textScore.text = "Time: 00:00";
    }

    // Update is called once per frame
    void Update()
    {   
        if (!gameManager.gameOver & gameManager.startGame)
        {
            textScore.text = "Time " + formatearTiempo();
        }
        

        if(Input.GetKeyDown(KeyCode.Space) & !saltando)
        {
            animator.SetBool("saltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            animator.SetBool("corriendo", false);
            saltando = true;
        }

        if(animator.transform.position.y < -4)
        {            
            gameManager.gameOver = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            animator.SetBool("saltando", false);
            animator.SetBool("corriendo", true);
            saltando = false;
        }
                   
    }
    public string formatearTiempo()
    {

		//Añado el intervalo transcurrido a la variable tiempo
		if (!gameManager.gameOver){
			tiempo += Time.deltaTime;
		}	
    
		//Formateo minutos y segundos a dos dígitos
		string minutos = Mathf.Floor(tiempo / 60).ToString("00");
 		string segundos = Mathf.Floor(tiempo % 60).ToString("00");
    
		//Devuelvo el string formateado con : como separador
		return minutos + ":" + segundos;

	}

}
//TODO: Arreglar bug animación de salto.
