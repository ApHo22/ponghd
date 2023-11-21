using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Todo el script se encarga de calcular el movimiento del balon
public class BallController : MonoBehaviour
{
    public float speed;
    public float minDirection = 0.5f;

    private Vector3 direction;
    private Rigidbody rb;

//Deteccion de si la escena esta en pausa
    private bool stopped = true;
    // Start is called before the first frame update
    void Start()
    {
        //Movimiento de pelota
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        transform.position += direction * speed * Time.deltaTime;
    }
    //Se detuvo la escena
    void FixedUpdate(){
        if ( stopped )
        return;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    //Deteccion de colisiones y velocidad el balon
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Wall")){
            direction.z = -direction.z;
        }
        if(other.CompareTag("Player")){
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            direction = newDirection;
        }
    }
    //Funcion encargada de que el balon al reiniciar no salga en una direccion fija
    private void ChooseDirection(){
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX,0 ,0.5f * signZ);

    }
//Escena en pausa
    public void Stop(){
        this.stopped = true;
    }
//Play
    public void Go(){
        ChooseDirection();
        this.stopped = false;
    }
}
