using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {
    // NOT : Yeni input system i kullanabilmek için packet manager dan inputsystem i yükleyin.



    [SerializeField] InputAction movement; //Yeni input system kullanımı için.
    [SerializeField] float controlSpeed = 10f;

    // Start is called before the first frame update
    void Start() {


    }

    //Bu metodları yapmamızın nedeni inputsystem i sadece ihtiyacıız olduğunda kullanabilmek içindir.
    void OnEnable() {    // Yeni inputSystem i kullanmak için etkinleştirmemiz gerekir.

        movement.Enable();// Yeni inputsystem i etkinleştirir.
    }

    void OnDisable() {

        movement.Disable();
    }
    //----------------------------------------------------------------


    // Update is called once per frame
    void Update() {
        ////Eski input system kullanımı
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float verticalThrow = Input.GetAxis("Vertical");


        //Yeni input system kullanımı
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;

        gameObject.transform.localPosition = new Vector3(newXPos , newYPos , gameObject.transform.localPosition.z);


    }
}
