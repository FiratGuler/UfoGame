using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour{
    public static UfoScript instance;
    [SerializeField]
    private Rigidbody2D myrigidbody;
    [SerializeField]
    private Animator anim;
    private float speed = 3f;
    private float bouncespeed = 4f;
    private bool didgas;
    public bool isCrash;
    public int score;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip gasClip,crahsClip,poinClip;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        isCrash = true;
        setCameraX();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCrash)
        {
            Vector3 temp = transform.position;
            temp.x+= speed * Time.deltaTime;
            transform.position = temp;
            if (didgas)
            {
                didgas = false;
                myrigidbody.velocity =new Vector2(0, bouncespeed);
                audioSource.PlayOneShot(gasClip);
                anim.SetTrigger("gas");
            }
            if (myrigidbody.velocity.y>=0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90,-myrigidbody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0,angle);
            }
        }
    }
    void setCameraX()
    {
        CameraScript.setX = (Camera.main.transform.position.x-transform.position.x) - 1f;
    }
 
    public void Uc()
    {
        didgas = true;
    }

    internal float GetPositionX()
    {
        return transform.position.x;
    }
    void OnCollisionEnter2D(Collision2D hedef)
    {
        if (hedef.gameObject.tag=="Cube" || hedef.gameObject.tag=="Meteor")
        {
            if (isCrash)
            {
                isCrash = false;
                anim.SetTrigger("crash");

                GamePlayController.ornek.skoruGoster(score);

                audioSource.PlayOneShot(crahsClip);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hedef)
    {
        if (hedef.gameObject.tag=="MeteorHolder")
        {
            score++;
            GamePlayController.ornek.SetScore(score);
            audioSource.PlayOneShot(poinClip);   
        }
    }
}
