using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteRotator : MonoBehaviour
{
    //Ruleta 1: Gameobject graficos + collider
    [SerializeField]GameObject roulette0;
    [SerializeField]GameObject roulette0Collider;

    //Ruleta 1: Gameobject graficos + collider
    [SerializeField] GameObject roulette1;
    [SerializeField] GameObject roulette1Collider;

    //Ruleta 1: Gameobject graficos + collider
    [SerializeField] GameObject roulette2;
    [SerializeField] GameObject roulette2Collider;

    //Ruleta 1: Gameobject graficos + collider
    [SerializeField] GameObject roulette3;
    [SerializeField] GameObject roulette3Collider;

    [SerializeField] float minSpeed, maxSpeed; //Velocidad mínima y máxima de giro de la ruleta
    [SerializeField] float minTimeToStop, maxTimeToStop; //Tiempo rotando la ruleta;
    float[] zAngle = new float[4];
    float[] timer = new float[4];

    bool rotating;

    //Testeo Lerp
    public float velocityLerp;
    public float zRotationMax;
    public float zRotation;
    public void StartSpin()
    {
        //Randomizar tiempo de cada ruleta 
        for (int i = 0; i < timer.Length; i++)
        {
            timer[i] = Random.Range(minTimeToStop, maxTimeToStop); //Por si queremos que cada ruleta tenga un tiempo de funcionamiento
            zAngle[i] = Random.Range(minSpeed, maxSpeed); //Para variar la velocidad de cada una de las ruletas
        }
        rotating = true;
    }
    private void Update()
    {
        if (rotating)
        {
            //Si ha empezado el giro
            
        }
        zRotation = Mathf.Lerp(zRotation, zRotationMax, velocityLerp * Time.deltaTime);
        roulette0.transform.Rotate(0, 0, zRotation,Space.World);
        roulette0Collider.transform.Rotate(0, 0, zRotation,Space.World);
    }
}
