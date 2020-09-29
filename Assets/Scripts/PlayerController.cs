using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Animator animator;
    public Canvas canvas;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            animator.SetFloat("Horizontal", 1);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            animator.SetFloat("Horizontal", 1);

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
            canvas.enabled = true;
            Destroy(collision.gameObject);
        }
    }

}