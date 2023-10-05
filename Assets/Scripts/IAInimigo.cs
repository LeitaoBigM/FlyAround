using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    private float _velocidade = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);
        if(transform.position.x < -10.9f)
        {
            transform.position = new Vector3(10.9f, Random.Range(-4.0f, 4.0f), 0);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("O objeto "+ other.name +" colidiu com o objeto "+ other.name);
        if(other.tag == "tiro")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.DanoAoPlayer();
            }
        }
        Destroy(this.gameObject);
    }
}
