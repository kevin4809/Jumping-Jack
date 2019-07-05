using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharapter : MonoBehaviour
{
    //Variables en las cuales se define la velocidad de movimiento y de salto del jugador 
    public float speedCharapter;
    public float speedJump;

    //Variable con la cual controlaremos las animaciones 
    private Animator anim;

    //Boleanos con los cuales se sabra si el personaje esta saltado o callendo 
    private bool isJumping = false;
    private bool isDown = false;

    //Variable en la cual se alamazenara la posicion del jugador en Y
    private float positionPlayerY;
  
    //Puntos de referencia de los cuales saldra tres raycast 
    public Transform groundDetection;
    public Transform enemyDetectionEnemy;
    public Transform groundDetectionDown;

    //Distancia del raycast
    public float distance;

    //Layers que los raycas podran detectar 
    public LayerMask layerWall;
    public LayerMask layerEnemy;

    //Vida jugador 
    public static int live = 5;

    //Variable con la cual controlaremos los sprites de los corazones 
    public lives currentLive;

    //Contador daño enemigos 
    private float timeForRestLive;
    public float timeForRestLiveCL;

    //Contador para diferenciar cuando el jugador esta callendo o esta saltando 
    private float timeForTouchGround;
    private float timeForTouchBeforeGround = 4;
   

    private void Start()
    {
        //Anim toma los componentes del animator y currentlive toma los componentes del scrip lives 
        anim = GetComponentInChildren<Animator>();
        currentLive = GameObject.FindObjectOfType<lives>();

        //Se da el valor de vida guardado con playerprefs 
        if (PlayerPrefs.HasKey("Live"))
        {
            PlayerPrefs.GetInt("Live", live);
        }

     

    }
    void Update()
    {
        Move();
        Jump();
        CheckDamagePlayer();
        CheckPositionPlayer();

        timeForTouchGround -= Time.deltaTime;
       
    }

    //Metodo en el cual se controla todo lo relacionado con el movimiento del jugador y sus animaciones
    private void Move()
    {
        if (Input.GetKey(KeyCode.D) && isJumping == false && isDown == false)
        {
            transform.Translate(Vector2.right * speedCharapter * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("IsMove", true);
        }
        else if (Input.GetKey(KeyCode.A) && isJumping == false && isDown == false)
        {
            transform.Translate(Vector2.right * speedCharapter * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, -180, 0);
            anim.SetBool("IsMove", true);
        }
        else { anim.SetBool("IsMove", false); }

    }

    //Metodo en el cual se controla todo lo relacionado con el salto del jugador y sus animaciones
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            anim.SetBool("Jump", true);
            StartCoroutine(TimeForJump());
            timeForTouchGround = timeForTouchBeforeGround;

        }
        else { anim.SetBool("Jump", false); }

        if (isJumping == true) { transform.Translate(Vector2.up * speedJump * Time.deltaTime); }
        if (isDown == true) { transform.Translate(Vector2.down * speedJump * Time.deltaTime); }

    }

    //Corrutina la cual se encarga de controla el tiempo por el cul el personaje puede saltar 
     IEnumerator TimeForJump()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
        Score.score += 5 * LevelManager.instance.level;
       

    }

    //Metodo el cual se encarga de revisar todas la codicciones del jugador por medio de tres raycast 
    private void CheckDamagePlayer()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.up, distance, layerWall);
        RaycastHit2D enemyDetection = Physics2D.Raycast(enemyDetectionEnemy.position, Vector2.right, distance, layerEnemy);
        RaycastHit2D groundDownInfo = Physics2D.Raycast(groundDetectionDown.position, Vector2.down, distance, layerWall);

        if (groundInfo.collider) { Time.timeScale = 0.0F; currentLive.ChangeLive(0); PlayerPrefs.DeleteAll(); SceneManager.LoadScene("1");  }
        

        if (!groundDownInfo.collider && timeForTouchGround <= 0 )
        {
            StartCoroutine(TimeForDown());
          
        }
        
        timeForRestLive -= Time.deltaTime;

        if (enemyDetection.collider && timeForRestLive <= 0)
        {
                live -= 1;
                currentLive.ChangeLive(live);
                timeForRestLive = timeForRestLiveCL;         
        }

        if(live <= 0) { Time.timeScale = 0.0F; PlayerPrefs.DeleteAll(); SceneManager.LoadScene("1");  }
    }

    //Dibuja un gizmo que ayuda a medir la distancia de los raycast
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * transform.localScale.x  * distance);

    }

    //Corrutina con la cual se controla el tiempo de caida del jugador 
    IEnumerator TimeForDown()
    {
        isDown = true;
        yield return new WaitForSeconds(0.41f);
        isDown = false;
    }

    //Metodo en el cual se controla las posciones del jugador y se activa el paso al siguiente nivel 
    private void CheckPositionPlayer()
    {

        positionPlayerY = transform.position.y;

        if(transform.position.x <= -6.76f)
        {
            transform.position = new Vector3(6.72f, positionPlayerY, 0f);
        }
        if (transform.position.x >= 6.76f)
        {
            transform.position = new Vector3(-6.72f, positionPlayerY, 0f);
        }


        if(transform.position.y >= 5.5) { LevelManager.instance.checkForNextLevel(); }
    }

   


}
