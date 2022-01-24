using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GameManager gameManager;
    public bool saltando;   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {        

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
}
//TODO: Arreglar bug animación de salto.
