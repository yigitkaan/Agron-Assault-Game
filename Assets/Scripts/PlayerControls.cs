using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {
    // NOT : Yeni input system i kullanabilmek için packet manager dan inputsystem i yükleyin.



    [SerializeField] InputAction movement; //Yeni input system kullanımı için.
    [SerializeField] float controlSpeed = 10f;
    //Player karakterimizin ekranın dışına yönlendirirken çıkmaması için kullanacağımız değişken.
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawfactor = 2f;
    [SerializeField] float controlRollFactor = 5f;

    float yThrow, xThrow;

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

    void ProcessTranslation() {

        ////Eski input system kullanımı
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float verticalThrow = Input.GetAxis("Vertical");


        //Yeni input system kullanımı
         xThrow = movement.ReadValue<Vector2>().x;
         yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //Player i ekranda gideceği yön miktarını kısıtlar.

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        gameObject.transform.localPosition = new Vector3(clampedXPos, clampedYPos, gameObject.transform.localPosition.z);
    }

    void ProcessRotation() {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;


        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawfactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);

    }

    // Update is called once per frame
    void Update() {
        
        ProcessTranslation();
        ProcessRotation();

    }
}
