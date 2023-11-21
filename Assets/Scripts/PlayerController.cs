using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad de movimiento del jugador
    public float speed;
    //Controles
    public KeyCode up;
    public KeyCode down;

    private Rigidbody rb;
    //Detecta si es un jugador o no
    public bool isPlayer = true;
    public float offset = 0.2f;
    private Transform ball;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Colisiones y deteccion del balon
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Deteccion si es un jugador o la maquina
        if(this.isPlayer){
            MoveByPlayer();
        }else{
            MoveByComputer();
        }
    }
    //funcion jugador
    private void MoveByPlayer(){
        //Movimiento
        bool pressedUp = Input.GetKey(this.up);
        bool pressedDown = Input.GetKey(this.down);
        //Movimiento arriba y abajo
        if(pressedUp){
            rb.velocity = Vector3.forward * speed;
        }
        if(pressedDown){
            rb.velocity = Vector3.back * speed;
        }
        if(!pressedUp && !pressedDown){
            rb.velocity = Vector3.zero;
        }
    }
    //Funcion maquina
    private void MoveByComputer(){
        //Se mueve segun la trayectoria del balon y la velocidad del mismo
        if(ball.position.z > transform.position.z + offset){
            rb.velocity = Vector3.forward * speed;
        } else if(ball.position.z < transform.position.z - offset){
            rb.velocity = Vector3.back * speed;
        } else {
            rb.velocity = Vector3.zero;
        }
    }
}
