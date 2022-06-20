using TMPro;
using UnityEngine;
public class RouletteRotator : MonoBehaviour
{
    public TMP_Text textTop0;
    public TMP_Text textTop1;
    public TMP_Text textTop2;
    public TMP_Text textTop3;
    public TMP_Text textTop4;

    public Animator anim;
    public Animator animCanvas;
    //Ruleta 1: Gameobject graficos + collider
    public GameObject canvasChooseSpin;

    [SerializeField] GameObject roulette0;
    [SerializeField] GameObject roulette0Collider;

    //Ruleta 2: Gameobject graficos + collider
    [SerializeField] GameObject roulette1;
    [SerializeField] GameObject roulette1Collider;

    //Ruleta 3: Gameobject graficos + collider
    [SerializeField] GameObject roulette2;
    [SerializeField] GameObject roulette2Collider;

    //Ruleta 4: Gameobject graficos + collider
    [SerializeField] GameObject roulette3;
    [SerializeField] GameObject roulette3Collider;

    [SerializeField] GameObject[] imagesResult;
    public int numberSpins;

    [SerializeField] float minSpeed, maxSpeed; //Velocidad mínima y máxima de giro de la ruleta
    [SerializeField] float minTimeToStop, maxTimeToStop; //Tiempo rotando la ruleta;
    float[] zAngle = new float[4];
    public float[] timer = new float[4];

    bool rotating;
    bool stopSpin;
    //Testeo Lerp
    public float velocityLerp;
    public float velocityLerpStart;
    public float zRotationMax;
    public float timeBrake;
    float[] zRotation = new float[4];
    bool checkCollision;

    int ball1, ball2, ball3, ball4;
    float greaterNumber;
    public bool CheckCollision { get => checkCollision; set => checkCollision = value; }

    int spin = -1;
    private void Awake()
    {
        for (int i = 0; i < imagesResult.Length; i++)
        {
            imagesResult[i].SetActive(false);
        }
    }
   
    public void SetNumberSpins(int spins)
    {
        canvasChooseSpin.SetActive(false);
        numberSpins = spins;
        Invoke("ZoomIn", 0.5f);
        Invoke("StartSpin", 4.5f);
        for (int i = 0; i <= numberSpins; i++)
        {
            imagesResult[i].SetActive(true);
        }
    }
    public void ZoomIn()
    {
        anim.SetTrigger("StartSpin");
    }
    public void StartSpin()
    {
        //Randomizar tiempo de cada ruleta 
        for (int i = 0; i < zAngle.Length; i++)
        {
            timer[i] = Random.Range(minTimeToStop, maxTimeToStop); //Por si queremos que cada ruleta tenga un tiempo de funcionamiento
            zAngle[i] = Random.Range(minSpeed, maxSpeed); //Para variar la velocidad de cada una de las ruletas
            zRotation[i] = 0;
        }
        CheckTimer();
        spin++;
    }
    public void CheckTimer()
    {
        for (int i = 0; i < timer.Length; i++)
        {
            if (timer[i] > greaterNumber)
            {
                greaterNumber = timer[i];
            }

        }
        rotating = true;
    }
    private void Update()
    {
        if (rotating)  //Si ha empezado el giro
        {
            timer[0] -= Time.deltaTime;
            timer[1] -= Time.deltaTime;
            timer[2] -= Time.deltaTime;
            timer[3] -= Time.deltaTime;
            greaterNumber -= Time.deltaTime;
            if (timer[0] > 0)
            {
                //RULETA 1
                zRotation[0] = Mathf.Lerp(zRotation[0], zAngle[0], velocityLerpStart * Time.deltaTime);
                roulette0.transform.Rotate(0, 0, zRotation[0]*Time.deltaTime, Space.World);
                roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);

            }
            else
            {
                zRotation[0] = Mathf.Lerp(zRotation[0], 0, velocityLerp * Time.deltaTime);
                roulette0.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
            }
            if (timer[1] > 0)
            {
                //RULETA 2
                zRotation[1] = Mathf.Lerp(zRotation[1], zAngle[1], velocityLerpStart * Time.deltaTime);
                roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
            }
            else
            {
                zRotation[1] = Mathf.Lerp(zRotation[1], 0, velocityLerp * Time.deltaTime);
                roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
            }
            if (timer[2] > 0)
            {
                //RULETA 3
                zRotation[2] = Mathf.Lerp(zRotation[2], zAngle[2], velocityLerpStart * Time.deltaTime);
                roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
            }
            else
            {
                zRotation[2] = Mathf.Lerp(zRotation[2], 0, velocityLerp * Time.deltaTime);
                roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
            }
            if (timer[3] > 0)
            {
                //RULETA 4
                zRotation[3] = Mathf.Lerp(zRotation[3], zAngle[3], velocityLerpStart * Time.deltaTime);
                roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
            }
            else
            {
                zRotation[3] = Mathf.Lerp(zRotation[3], 0, velocityLerp * Time.deltaTime);
                roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
            }

            if (greaterNumber < 0 && !stopSpin)
            {
                Invoke("SpinStopped", timeBrake);
                stopSpin = true;
            }
        }
    }
    void SpinStopped()
    {
        anim.SetTrigger("ShowNumber");
        animCanvas.SetTrigger("Show");
        rotating = false;
        stopSpin = false;
        CheckCollision = true;
        Invoke("CheckCollisionFalse", 0.5f);
        Invoke("PrintNumber", 1.2f);
    }

    void CheckCollisionFalse()
    {
        CheckCollision = false;
    }
    public void RegisterNumber(int ballNumber, int result)
    {

        switch (ballNumber)
        {
            case 0:
                ball1 = result;
                break;
            case 1:
                ball2 = result;
                break;
            case 2:
                ball3 = result;
                break;
            case 3:
                ball4 = result;
                break;
        }
    }

    public void PrintNumber()
    {
        
        switch (spin)
        {
            case 0:
                textTop0.text = ball1 + " " + ball2 + " " + ball3 + " " + ball4;
                break;
            case 1:
                textTop1.text = ball1 + " " + ball2 + " " + ball3 + " " + ball4;
                break;
            case 2:
                textTop2.text = ball1 + " " + ball2 + " " + ball3 + " " + ball4;
                break;
            case 3:
                textTop3.text = ball1 + " " + ball2 + " " + ball3 + " " + ball4;
                break;
            case 4:
                textTop4.text = ball1 + " " + ball2 + " " + ball3 + " " + ball4;
                break;
        }
        Invoke("PrintSpin4Win", 3f);
    }
    public void PrintSpin4Win()
    {
        //textTop.text = "SPIN 4 WIN";
        
        if (spin < numberSpins)
        {
            StartSpin();
            anim.SetTrigger("ReSpin");
        }
        else
        {
            anim.SetTrigger("StopSpin");
            Invoke("NoShow", 4f);
        }
    }
    public void NoShow()
    {
        animCanvas.SetTrigger("NoShow");
        canvasChooseSpin.SetActive(true);
    }
}
