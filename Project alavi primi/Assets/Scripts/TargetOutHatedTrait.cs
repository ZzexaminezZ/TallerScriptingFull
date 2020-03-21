using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOutHatedTrait : TargetInt
{
    //Seteo de atributos

    public AudioSource bubblesound;
    public AudioSource lovesound;
    public AudioSource greysound;
    public AudioSource inteligensound;

    public bool Estoyvivo = false;
    private float SumaExpectation;
    private float StandarPoints;
    private int count;
    private float burbujasperdidas;
    private float Contador = 10;// cada cuanto va a bajar interes por no explotar burbujas
                                //Seteo de atributos

    public void Awake()
    {

        
        SumaExpectation = 8f;
        Estoyvivo = true;
    }
    //Seteo de atributos
    public void Start()
    {
        
        UiGame.get.Burbujahit += Recibirobj;
        InteresActual = 100;
        InteresMaximo = 100;
        Expectation = 0;
        ExpectativaMeta = 1000;
       
        StandarPoints = SumaExpectation;
    }

    public void Update()
    {
        perdervidaPorPerdidadeburbujas();  
    }

    override public  void perdervidaPorPerdidadeburbujas()
    {
        burbujasperdidas += Time.deltaTime;

        if ((int)burbujasperdidas > Contador)
        {
            InteresActual -= 2;
            burbujasperdidas = 0;
        }
    }
    // Metodos que son los gustos de la chicha
    override public void PreferredTrait()
    {
        Expectation += SumaExpectation +(SumaExpectation*0.2f);
    }
    override public void DislikedTrait()
    {

        Expectation += SumaExpectation - (SumaExpectation * 0.55f);

    }
    override public void HatedTrait()
    {




    }



    

    private void Recibirobj(GameObject go)
    {
        
        Burbuja actual = go.GetComponent<Burbuja>();
       

        switch (actual.TypeBurbuja)
        {


            case ETypeBurbuja.Flirt:
                PreferredTrait();
                burbujasperdidas = 0;
                Destroy(actual.gameObject);
                bubblesound.Play();
                break;
            case ETypeBurbuja.Love:
                Expectation += SumaExpectation;
                burbujasperdidas = 0;
                DislikedTrait();
                Destroy(actual.gameObject);
                lovesound.Play();
                break;
            case ETypeBurbuja.Intelligence:
                Expectation += SumaExpectation;
                burbujasperdidas = 0;
                Destroy(actual.gameObject);
                inteligensound.Play();
                break;
            case ETypeBurbuja.Intimacy:
                InteresActual += 5;
                if (InteresActual > 100)
                {
                    InteresActual = 100;
                }
                Destroy(actual.gameObject);
                bubblesound.Play();
                break;
            case ETypeBurbuja.Affection:

                count += 1;
                if (count / 3 > 0 && count / 3 <= 10)
                {
                    SumaExpectation += (SumaExpectation * 0.05f);
                }
                Destroy(actual.gameObject);
                bubblesound.Play();
                break;
            case ETypeBurbuja.Boorish:
                StandarPoints = StandarPoints * 0.75f;
                Expectation -= StandarPoints;
                if (Expectation < 0)
                {
                    Expectation = 0f;
                }
                InteresActual -= InteresActual * 0.05f;

                Destroy(actual.gameObject);
                greysound.Play();
                break;
            default:
                break;
        }
       
    }
}
