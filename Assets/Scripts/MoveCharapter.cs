using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharapter : MonoBehaviour
{
    public float speedCharapter;
    public float speedJump;
    private Animator anim;
    private bool isJumping = false;

    private float positionPlayerY;
    public float distance;
    public Transform groundDetection;
    public Transform enemyDetectionDown;
    public LayerMask layerWall;
    public LayerMask layerEnemy;

    public static int live = 5;
    public lives currentLive;
    public LevelManager pasLevl;
    

    private float timeForRestLive;
    public float timeForRestLiveCL;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentLive = GameObject.FindObjectOfType<lives>();
        pasLevl = GameObject.FindObjectOfType<LevelManager>();


    }
    void Update()
    {
        Move();
        Jump();
        CheckDamagePlayer();
        CheckPositionPlayer();

       
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.D) && isJumping == false)
        {
            transform.Translate(Vector2.right * speedCharapter * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("IsMove", true);
        }
        else if (Input.GetKey(KeyCode.A) && isJumping == false)
        {
            transform.Translate(Vector2.right * speedCharapter * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, -180, 0);
            anim.SetBool("IsMove", true);
        }
        else { anim.SetBool("IsMove", false); }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            anim.SetBool("Jump", true);
            StartCoroutine(TimeForJump());
           
        }
        else { anim.SetBool("Jump", false); }

        if (isJumping == true) { transform.Translate(Vector2.up * speedJump * Time.deltaTime); }
    }

     IEnumerator TimeForJump()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        Score.score += 5;
        isJumping = false;
       
    }


    private void CheckDamagePlayer()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.up, distance, layerWall);
        RaycastHit2D enemyDetection = Physics2D.Raycast(enemyDetectionDown.position, Vector2.right, distance, layerEnemy);

        if (groundInfo.collider) { Time.timeScale = 0.0F; currentLive.ChangeLive(0); }

        timeForRestLive -= Time.deltaTime;

        if (enemyDetection.collider && timeForRestLive <= 0)
        {
                live -= 1;
                currentLive.ChangeLive(live);
                timeForRestLive = timeForRestLiveCL;         
        }

        if(live <= 0) { Time.timeScale = 0.0F; }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * transform.localScale.x  * distance);

    }


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


        if(transform.position.y >= 5.5f) { pasLevl.checkForNextLevel(); }
    }

   


}
