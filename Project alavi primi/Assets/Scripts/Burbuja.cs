using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Material))]
public class Burbuja : MonoBehaviour
{

    //Seteo de atributos

    [SerializeField]
    private float speed; // Velocidad de la butbuja
    public Rigidbody rb;
    public ETypeBurbuja TypeBurbuja; // Tipo de burbuja

   //ublic AudioSource bubblesound;

    private void Start()
    {

        //bblesound = GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
    }

    //llamado de los metodos cada segundo
    private void Update()
    {
        //bblesound.Play();
        rb.velocity = new Vector3(0,-speed);

        CambioVelicodad();
    }

    // Destruit lo que esta fuera de la pantalla 
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    

    // Metodo para el cambio de la velocdiad de las burbujas
    void CambioVelicodad()
    {
       if (MejoraGenerador.Timer <= 400)
        {
            speed = 10 + (((int)MejoraGenerador.Timer)/40);
        }
        if (MejoraGenerador.Timer > 400)
        {
            speed = 15;
        }
    }

}