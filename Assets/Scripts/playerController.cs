using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float Velocidade;
    public Animator anim;
    public Camera MainCamera;
    public float VelocidadeCamera;
    public float VelocidadeRotacaoCamera;
    public Vector3 CameraOffset; 

    float InputX; // A,D 
    float InputZ; // W,S
    Vector3 Direcao;

    void Start() {
        
    }

    void Update() {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        Direcao = new Vector3(InputX,0,InputZ);

        if(InputX != 0 || InputZ != 0 ) {
            var camrot = MainCamera. transform. rotation;
            camrot.x = 0;
            camrot.y = 0;

            transform.Translate(0,0,Velocidade * Time.deltaTime);
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direcao)* camrot, 5 * Time.deltaTime);
        }
        if(InputX == 0 && InputZ == 0 ) {
            anim.SetBool("walk", false);
        }

        MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, transform.rotation, VelocidadeRotacaoCamera * Time.deltaTime);
    }

    private void LateUpdate() {
        var pos = transform.position - MainCamera.transform.forward * CameraOffset.z + MainCamera.transform.up * CameraOffset.y + MainCamera.transform.right * CameraOffset.x;
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, pos, VelocidadeCamera * Time.deltaTime);
    }
}
