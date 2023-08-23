using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float springPower;

    public KeyCode input;

    private HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput(){

        JointSpring joint = hinge.spring;

        if(Input.GetKey(input)){
            Debug.Log("Clicked: " + input);
            joint.spring = springPower;
        }
        else{
            joint.spring = 0;
        }

        hinge.spring = joint;
    }

    private void MovePaddle(){
          
    }
}
