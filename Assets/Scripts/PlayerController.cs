using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Canvas gameOver;
    public Canvas score;

    public GameObject impact;
    public bool isAlive = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetFloat("Horizontal", 1);
            spriteRenderer.flipX = true;

        }
        else if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetFloat("Horizontal", 1);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        else if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        transform.position = pos;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "blast")
        {
            //score.enabled = false;
            gameOver.enabled = true;

            Destroy(collision.gameObject);

            GameObject impactInstance = Instantiate(impact, transform.position, Quaternion.identity);
            Destroy(impactInstance, 5);
            isAlive = false;
        }
    }

}