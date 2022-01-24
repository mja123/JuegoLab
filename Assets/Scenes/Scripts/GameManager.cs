using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameOverMenu;

    public GameObject Superficie;
    public Renderer fondo;
    public List<GameObject> cols;
    public float velocidad = 2;
    public int incrementoX;
    public bool startGame = false;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 21; i+=3)
        {
            cols.Add(Instantiate(Superficie, new Vector2(-10.35f + i, -2), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    { 

        if (!startGame)
        {           
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                startGame = true;
            }
        }

        if (startGame & gameOver)
        {
            gameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (startGame & !gameOver)
        {
            startMenu.SetActive(false);
            fondo.material.mainTextureOffset += new Vector2(0.015f, 0) * Time.deltaTime;
            for (int i = 0; i < cols.Count; i++)
            {
                
                incrementoX = Random.Range(3, 6);
                if (cols[i].transform.position.x <= -10.35f)
                {
                    cols[i].transform.position = new Vector3(10.35f, -2, 0);

                    //cuando i es divisible por 3 y con un 20% de posibilidad de entrar
                    //se crea un hueco de entre 3 y 6 pixeles, lo que asegura que siempre haya aunque sea una parte de piso para caer y
                    // no hayan huecos de menos de 2 pixeles

                    if (i % 3 == 0 && Random.Range(1, 10) >= 4)
                    {
                        cols[i].transform.position = new Vector3(10.35f + incrementoX, -2, 0);
                    }

                    velocidad += 0.05f;
                }



                //movimiento del suelo

                cols[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * (velocidad);

            }
        }
    }
}

