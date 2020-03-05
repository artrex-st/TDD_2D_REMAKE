using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //  ##  ##  ##  ##  ##  ##  ## //
    void Update()
    {

        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        // Rotate around our y-axis (usar apenas para 3D)
        //float rotation = Input.GetAxis("Vertical") * rotationSpeed;
        //rotation *= Time.deltaTime;
        // transform.Rotate(0, rotation, 0);
    }
}
