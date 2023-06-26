using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc;
    public GameObject pfLaser;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Método Star de"+this.name);
        veloc = 3.0f;
        transform.position = new Vector3(-6.0f,-3.0f,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.Movimento();

        if ( Input.GetKeyDown(KeyCode.Space)){
            Instantiate(pfLaser,transform.position + new Vector3(0,1f,0),Quaternion.identity);
        }
    }
    private void Movimento()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * entradaHorizontal * Time.deltaTime * veloc);
        if(transform.position.y > 2f){
            transform.position = new Vector3(transform.position.x,2f,0);
        }else if (transform.position.y < -5.5){
            transform.position = new Vector3(transform.position.x,-5.5f,0);
        }

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime * veloc);
        if(transform.position.x > 9.68f){
            transform.position = new Vector3(-9.68f,transform.position.y,0);
        }else if (transform.position.x < -9.68f){
            transform.position = new Vector3(9.68f,transform.position.y,0);
        }
    }
}