using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    //Public
    public float multiplier; 
    public float score;    

    public Color color;

    public AudioManager audioManager;
    public ScoreManager scoreManager;

    public GameObject bumperVfx;
    public VfxManager vfxManager;

    public Collider bola;

    //Private
    private Animator animator;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();

        renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider == bola){
            animator.SetTrigger("hit");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            
            scoreManager.AddScore(score);
            audioManager.PlaySFX(collision.transform.position);
            vfxManager.vfxSource = bumperVfx;
            vfxManager.PlayVFX(collision.transform.position);
            Debug.Log("Collided");
        }
    }
}
