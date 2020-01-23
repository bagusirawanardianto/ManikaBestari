using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LadyController : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    bool isSuperJump = false;

    int idMove = 0;
    int superJump = 0;

    Animator anim;

    public AudioClip audioEarnCoint;
    private AudioSource MPEarnCoint;

    public AudioClip audioEarnItems;
    private AudioSource MPEarnItems;

    public AudioClip audioUseItems;
    private AudioSource MPUseItems;

    public AudioClip audioPeluruItems;
    private AudioSource MPPeluruItems;

    public Rigidbody2D rbd;

    public GameObject p1, p2, p3, p4, p5, b1;

    public static GameManager GM;

    public KeyCode jump { get; set; }
    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }

    public GameObject[] Items;
    public string nextScene;

    void Awake()
    {
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
    }

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        Coins.scene = SceneManager.GetActiveScene().buildIndex;

        MPEarnCoint = gameObject.AddComponent<AudioSource>();
        MPEarnCoint.clip = audioEarnCoint;

        MPEarnItems = gameObject.AddComponent<AudioSource>();
        MPEarnItems.clip = audioEarnItems;

        MPUseItems = gameObject.AddComponent<AudioSource>();
        MPUseItems.clip = audioUseItems;

        MPPeluruItems = gameObject.AddComponent<AudioSource>();
        MPPeluruItems.clip = audioPeluruItems;
    }

    // Update is called once per frame
    void Update()
    {  
            if (Input.GetKeyDown(backward))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(forward))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(jump))
            {
                Jump();
            }
            if (Input.GetKeyUp(forward))
            {
                Idle();
            }
            if (Input.GetKeyUp(backward))
            {
                Idle();
            }
            Move();
            Dead();

        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        isJump = true;
    }

    public void MoveRight()
    {
        idMove = 1;
    }

    public void MoveLeft()
    {
        idMove = 2;
    }

    private void Move()
    {
            if (idMove == 1 && !isDead)
            {
                // Kondisi ketika bergerak ke kekanan
                if (!isJump) anim.SetTrigger("run");
                transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
                transform.localScale = new Vector3(0.8f, 0.7f, 1f);
            }
            if (idMove == 2 && !isDead)
            {
                // Kondisi ketika bergerak ke kiri
                if (!isJump) anim.SetTrigger("run");
                transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
                transform.localScale = new Vector3(-0.8f, 0.7f, 1f);
            }
    }

    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat      
            if (isSuperJump == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400f);
                isSuperJump = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Police"))
        {
            StartCoroutine(ExampleCoroutine());
            Debug.Log("Ketemu Polisi!");
        }

        if (collision.transform.tag.Equals("SpecialItem"))
        {
            superJump = 1;
            Destroy(collision.gameObject);
            MPEarnItems.Play();
        }

        if (collision.transform.tag.Equals("Bullet"))
        {
            rbd.velocity = new Vector2(6f, rbd.velocity.y);
            MPPeluruItems.Play();
        }
    }

    public void Idle()
    {
        // kondisi ketika idle/diam
        if (!isJump)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }
        idMove = 0;
    }

    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                // kondisi ketika jatuh
                isDead = true;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void useSpecialItem()
    {
        if (superJump > 0)
        {
            isSuperJump = true;
            superJump = 0;
            MPUseItems.Play();
        }
    }

    IEnumerator ExampleCoroutine()
    {
        for(int i = 0; i < Items.Length; i++){
           
            if(i == Items.Length-1)
            {
                Items[i].active = true;
                yield return new WaitForSeconds(2);
                Items[i].active = false;
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Items[i].active = true;
                yield return new WaitForSeconds(2);
                Items[i].active = false;
            }
        }

        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
