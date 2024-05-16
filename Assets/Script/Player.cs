using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rig;
    public SpriteRenderer sprite;
    public Animator anim;
    public GameObject feetPos;
    public GameObject DialogBox;
    public TMP_Text DialogText;

    public LayerMask layer;

    public List<ObjectSO> objects;
    
    public float dir;
    public float speed = 3f;
    public float forceJump;

    public bool isGrounded;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        DialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(feetPos.transform.position, .3f, layer);
        // -1 ou 1
        Flip();

        if (Input.GetMouseButtonDown(0) && DialogBox.activeSelf)
        {
            DialogBox.SetActive(false);
        }
        
    }

    void FixedUpdate()
    {
        Mov();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Mov()
    {
        rig.velocity = new Vector2(dir * speed, rig.velocity.y);
        if (dir != 0 )
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
    }

    void Jump()
    {
        rig.velocity = Vector2.up * forceJump;
        anim.SetInteger("State", 2 );
    }

    void Flip()
    {
        if (dir != 0 )
        {
            sprite.flipX = dir < 0; 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruta"))
        {
            DialogBox.SetActive(true);
            DialogText.text = objects[0].description;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Acai"))
        {
            DialogBox.SetActive(true);
            DialogText.text = objects[1].description;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coco"))
        {
            DialogBox.SetActive(true);
            DialogText.text = objects[2].description;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Mucura"))
        {
            DialogBox.SetActive(true);
            DialogText.text = objects[3].description;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Guarana"))
        {
            DialogBox.SetActive(true);
            DialogText.text = objects[4].description;
            Destroy(other.gameObject);
        }
    }

  
}
