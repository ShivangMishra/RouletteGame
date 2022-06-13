using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteRotator : MonoBehaviour
{
    //Ruleta 1: Gameobject graficos + collider
    [SerializeField]GameObject roulette0;
    [SerializeField]GameObject roulette0Collider;

    //Ruleta 2: Gameobject graficos + collider
    [SerializeField] GameObject roulette1;
    [SerializeField] GameObject roulette1Collider;

    //Ruleta 3: Gameobject graficos + collider
    [SerializeField] GameObject roulette2;
    [SerializeField] GameObject roulette2Collider;

    //Ruleta 4: Gameobject graficos + collider
    [SerializeField] GameObject roulette3;
    [SerializeField] GameObject roulette3Collider;

   

    [SerializeField] float minSpeed, maxSpeed; //Velocidad mínima y máxima de giro de la ruleta
    [SerializeField] float minTimeToStop, maxTimeToStop; //Tiempo rotando la ruleta;
    float[] zAngle = new float[4];
    float timer;

    bool rotating;
    bool stopSpin;
    //Testeo Lerp
    public float velocityLerp;
    public float velocityLerpStart;
    public float zRotationMax;
    public float timeBrake;
    float[] zRotation = new float[4];
    private void Start()
    {
        StartSpin();
    }
    public void StartSpin()
    {
        //Randomizar tiempo de cada ruleta 
        for (int i = 0; i < zAngle.Length; i++)
        {
            timer = Random.Range(minTimeToStop, maxTimeToStop); //Por si queremos que cada ruleta tenga un tiempo de funcionamiento
            zAngle[i] = Random.Range(minSpeed, maxSpeed); //Para variar la velocidad de cada una de las ruletas
            zRotation[i] = 0;
        }
        rotating = true;
    }
   
    private void Update()
    {
        if (rotating)  //Si ha empezado el giro
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                //RULETA 1
                zRotation[0] = Mathf.Lerp(zRotation[0], zAngle[0], velocityLerpStart * Time.deltaTime);
                roulette0.transform.Rotate(0, 0, zRotation[0], Space.World);
                roulette0Collider.transform.Rotate(0, 0, zRotation[0], Space.World);
                //RULETA 2
                zRotation[1] = Mathf.Lerp(zRotation[1], zAngle[1], velocityLerpStart * Time.deltaTime);
                roulette1.transform.Rotate(0, 0, zRotation[1], Space.World);
                roulette1Collider.transform.Rotate(0, 0, zRotation[1], Space.World);
                //RULETA 3
                zRotation[2] = Mathf.Lerp(zRotation[2], zAngle[2], velocityLerpStart * Time.deltaTime);
                roulette2.transform.Rotate(0, 0, zRotation[2], Space.World);
                roulette2Collider.transform.Rotate(0, 0, zRotation[2], Space.World);
                //RULETA 4
                zRotation[3] = Mathf.Lerp(zRotation[3], zAngle[3], velocityLerpStart * Time.deltaTime);
                roulette3.transform.Rotate(0, 0, zRotation[3], Space.World);
                roulette3Collider.transform.Rotate(0, 0, zRotation[3], Space.World);
            }
            else //PARANDO
            {
                if (!stopSpin)
                {
                    Invoke("SpinStopped", timeBrake);
                    stopSpin = true;
                }
                //RULETA 1
                zRotation[0] = Mathf.Lerp(zRotation[0], 0, velocityLerp * Time.deltaTime);
                roulette0.transform.Rotate(0, 0, zRotation[0], Space.World);
                roulette0Collider.transform.Rotate(0, 0, zRotation[0], Space.World);
                //RULETA 2
                zRotation[1] = Mathf.Lerp(zRotation[1], 0, velocityLerp * Time.deltaTime);
                roulette1.transform.Rotate(0, 0, zRotation[1], Space.World);
                roulette1Collider.transform.Rotate(0, 0, zRotation[1], Space.World);
                //RULETA 3
                zRotation[2] = Mathf.Lerp(zRotation[2], 0, velocityLerp * Time.deltaTime);
                roulette2.transform.Rotate(0, 0, zRotation[2], Space.World);
                roulette2Collider.transform.Rotate(0, 0, zRotation[2], Space.World);
                //RULETA 4
                zRotation[3] = Mathf.Lerp(zRotation[3], 0, velocityLerp * Time.deltaTime);
                roulette3.transform.Rotate(0, 0, zRotation[3], Space.World);
                roulette3Collider.transform.Rotate(0, 0, zRotation[3], Space.World);
            }
        }
    }
    void SpinStopped()
    {
        rotating = false;
        stopSpin = false;
    }
}
