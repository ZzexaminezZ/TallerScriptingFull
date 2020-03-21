using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UiGame : MonoBehaviour
{


    public static UiGame get; // 

    public delegate void _BurbujaHit(GameObject go); //Delegado

    public event _BurbujaHit Burbujahit; //Evento del raycast de la burbuja

    public GameObject TargetNice; // Mujer 1

    public GameObject TargetMedium;// Mujer 2

    public GameObject TargetHard;// Mujer 3

   
    public Text Expectativa; // Texto Expectativa parcial
    public Text InterestParcial; // Texto de interes parcial
   

    private float Expectation;// inicializacion de la expectativa
    private float ExpectativaVictoria;  // Expectativa necesaria para ganar
    private float InteresMaximo;  //Interes maximo que se puede tener
    private float interesInicial; //Interes desde el inicio
    private float Restaporperdida; // El daño que se resta al perder 6 burbujas de las 3 principales

    public float InteresInicial { get => interesInicial; set => interesInicial = value; }

    private void Awake()
    {

        get = this;

    }

    public void Start()
    {

      
    }

    // Update is called once per frame
    public void Update()
    {



        //Tiempo de la partida 
        TimeTake();
        
        //Raycast
        if (Input.GetMouseButtonDown(0))
        {
            Raycasting();
        }
        //Actualizacion de datos dependiendo de la cita
        TargetOutHatedTrait cita1 = TargetNice.GetComponent<TargetOutHatedTrait>();
        if (cita1.Estoyvivo == true)
        {
            TargetintNice();
        }
        TargetWithAllTraits cita2 = TargetMedium.GetComponent<TargetWithAllTraits>();
        if (cita2.Estoyvivo == true)
        {
            TargetIntMed();
        }
        TargetWithOnlyHatedTrait cita3 = TargetHard.GetComponent<TargetWithOnlyHatedTrait>();
        if (cita3.Estoyvivo == true)
        {
            TargetIntHard();
        }
        if (Expectation >= ExpectativaVictoria)
        {
            SceneManager.LoadScene("Victoria");
        }
        if (InteresInicial <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
     

    }
    //********************************************************************************

    // Trae los datos uniciales de las citas para comenzar a jugar;
    private void TargetintNice()
    {
        TargetOutHatedTrait cita = TargetNice.GetComponent<TargetOutHatedTrait>();

        InteresInicial = cita.InteresActual;
        InteresMaximo = cita.InteresMaximo;
        Expectation = cita.Expectation;
        ExpectativaVictoria = cita.ExpectativaMeta;
    }
    private void TargetIntMed()
    {
        TargetWithAllTraits cita1 = TargetMedium.GetComponent<TargetWithAllTraits>();

        InteresInicial = cita1.InteresActual;
        InteresMaximo = cita1.InteresMaximo;
        Expectation = cita1.Expectation;
        ExpectativaVictoria = cita1.ExpectativaMeta;
    }

    private void TargetIntHard()
    {
        TargetWithOnlyHatedTrait cita2 = TargetHard.GetComponent<TargetWithOnlyHatedTrait>();

        InteresInicial = cita2.InteresActual;
        InteresMaximo = cita2.InteresMaximo;
        Expectation = cita2.Expectation;
        ExpectativaVictoria = cita2.ExpectativaMeta;
    }
    //********************************************************************************

    //Contador del tiempo
   

    //Contruccion de los contadores de prueba
    private void TimeTake()
    {
        InterestParcial.text = " " + (int)InteresInicial + "/ " + InteresMaximo;
      
        Expectativa.text = " " + (int)Expectation + "/ " + ExpectativaVictoria ;
       
    }

    //Raycast
    void Raycasting()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit tempHit;


        if (Physics.Raycast(ray, out tempHit))
        {

            if (tempHit.collider.GetComponent<Burbuja>() != null)
            {
                Burbujahit?.Invoke(tempHit.collider.gameObject);
            }


        }
    }
    
    
}
