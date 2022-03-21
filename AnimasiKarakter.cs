using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiKarakter : MonoBehaviour
{
    public float jumpForce = 200f; // kekuatan lompatan
    public float speed = 1f; // akselerasi
    public float rotSpeed = 30f; // kecepatan memutar

    Animator anim;
    Rigidbody rb;
    float xAxis, zAxis, rot; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
                
        // memutar
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

    }

    private void FixedUpdate()
    {
        // lompat
        if (Input.GetKeyDown("space") && (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jumping"))
        {
            anim.SetTrigger("Melompat");
        }

        // jalan
        if (zAxis != 0)
            anim.SetBool("sedangJalan", true); // aktifkan animasi berjalan
        else
            anim.SetBool("sedangJalan", false); // berhenti animasi berjalan

        if(zAxis != 0)
            rb.MovePosition(transform.position + (Time.deltaTime * speed *
                transform.TransformDirection(new Vector3(xAxis, 0, zAxis))));
    }

}
