using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horixontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horixontalThrow);

        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
    }
}
