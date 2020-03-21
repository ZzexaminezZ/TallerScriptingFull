using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMeter : MonoBehaviour
{
    public Transform needleheartmove;
    private GameObject needle;
    public const float maxAngle = -77;
    public const float minAngle = 80;

    private float speedmax;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += 50f * Time.deltaTime;
        if(speed> speedmax)
        {
            speed = speedmax;
        }

        needleheartmove.eulerAngles = new Vector3(0, 0, GetRotationSpeed());
    }

    public void Awake()
    {
        needleheartmove = transform.Find("Aguja");

        speed = 0f;
        speedmax = 500f;

    }

    private float GetRotationSpeed()
    {
        float tamñoAngulo = minAngle - maxAngle;
        float normSpeed = speed / speedmax;
        return minAngle - normSpeed * tamñoAngulo;
    }
}
