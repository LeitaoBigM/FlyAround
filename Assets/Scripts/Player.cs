using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _veloc;
    [SerializeField]
    private GameObject _pfLaser;
    [SerializeField]
    public float tempoDeDisparo = 0.3f;
    public float podeDisparar = 0.0f;
    public bool possoDarDisparoTriplo = false;
    [SerializeField]
    private GameObject _disparoTriploPrefab;
    public int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Método Star de"+this.name);
        _veloc = 3.0f;
        transform.position = new Vector3(-6f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.Movimento();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            if(Time.time > podeDisparar)
            {
                Disparo();
            }
        }
    }
    private void Movimento()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * entradaHorizontal * Time.deltaTime * _veloc);
        if(transform.position.y > 2f){
            transform.position = new Vector3(transform.position.x,2f,0);
        }else if (transform.position.y < -5.5){
            transform.position = new Vector3(transform.position.x,-5.5f,0);
        }

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime * _veloc);
        if(transform.position.x > 9.68f){
            transform.position = new Vector3(-9.68f,transform.position.y,0);
        }else if (transform.position.x < -9.68f){
            transform.position = new Vector3(9.68f,transform.position.y,0);
        }
    }


    private void Disparo()
    {
    if(Time.time > podeDisparar)
        {
            if(possoDarDisparoTriplo == true)
        {
            Instantiate(_disparoTriploPrefab,transform.position,Quaternion.identity);
        }
        else
        {
            Instantiate(_pfLaser, transform.position + new Vector3(0,1.1f,0), Quaternion.identity);
        }
        podeDisparar = Time.time + tempoDeDisparo;
        }
    }
    public void LigarPUDisparoTriplo()
    {
        possoDarDisparoTriplo = true;
        StartCoroutine(DisparoTriploRotina());
    }
    public IEnumerator DisparoTriploRotina()
    {
        yield return new WaitForSeconds(7.0f);
        possoDarDisparoTriplo = false;
    }
    public void DanoAoPlayer()
    {
        vidas--;
        if(vidas < 1)
        {
            Destroy(this.gameObject);
        }
    }
}