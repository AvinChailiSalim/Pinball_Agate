using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    public float score;

    public Material offMaterial;
    public Material onMaterial;

    public Collider bola;

    public ScoreManager scoreManager;
    public AudioManager audioManager;
        
    public GameObject switchVfx;
    public VfxManager vfxManager;

    private enum SwitchState{
        Off,
        On,
        Blink
    }

    private bool isOn;
    
    private Renderer renderer;

    private SwitchState state;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = offMaterial;

        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other){
        if(other == bola){
            Toggle();
            scoreManager.AddScore(score);
            audioManager.PlaySFX(other.transform.position);
            vfxManager.vfxSource = switchVfx;
            vfxManager.PlayVFX(other.transform.position);

            Debug.Log("Hitted");
        }
    }

    private void Toggle(){
        if(state == SwitchState.On){
            Set(false);
        }
        else{
            Set(true);
        }
    }

    private void Set(bool active){
        if(active == true){
            state = SwitchState.On;
            renderer.material = onMaterial;
        
            StopAllCoroutines();
        }
        else{
            state = SwitchState.Off;
            renderer.material = offMaterial;

            StartCoroutine(BlinkTimerStart(5));
        }
    }


    private IEnumerator Blink(int times){
        state = SwitchState.Blink;

        for(int i = 0;i<times;i++){
            renderer.material = onMaterial;
            yield return new WaitForSeconds(.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time){
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
