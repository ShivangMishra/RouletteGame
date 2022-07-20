using TMPro;
using UnityEngine;
public class RouletteRotator : MonoBehaviour
{
    public AudioSource audioRoulette1;
    public AudioSource audioRoulette2;
    public AudioSource audioRoulette3;
    public AudioSource audioRoulette4;
    float audioPitch1;
    float audioPitch2;
    float audioPitch3;
    float audioPitch4;
    AudioSource audioSource;
    public PlayOutro playOutro;
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
        audioSource = FindObjectOfType<AudioSource>();
    }
    private void Start()
    {
        SetNumberSpins(GameManager.instance.numberSpins);
    }

    public void SetNumberSpins(int spins)
    {
        canvasChooseSpin.SetActive(false);
        numberSpins = spins;
        Invoke("ZoomIn", 4f);
        Invoke("StartSpin", 8f);
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
        /*
        timer[0] = minTimeToStop;
        timer[1] = minTimeToStop + 5;
        timer[2] = minTimeToStop + 10;
        timer[3] = minTimeToStop + 15;
        */
        timer[0] = GameManager.instance.timeA;
        timer[1] = GameManager.instance.timeB;
        timer[2] = GameManager.instance.timeC;
        timer[3] = GameManager.instance.timeD;

        zAngle[0] = GameManager.instance.speedA;
        zAngle[1] = GameManager.instance.speedB;
        zAngle[2] = GameManager.instance.speedC;
        zAngle[3] = GameManager.instance.speedD;
        //Randomizar tiempo de cada ruleta 
        for (int i = 0; i < zAngle.Length; i++)
        {
            //timer[i] = Random.Range(minTimeToStop, maxTimeToStop); //Por si queremos que cada ruleta tenga un tiempo de funcionamiento
            // zAngle[i] = Random.Range(minSpeed, maxSpeed); //Para variar la velocidad de cada una de las ruletas
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
        audioRoulette1.Play();
        audioRoulette2.Play();
        audioRoulette3.Play();
        audioRoulette4.Play();
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
                audioPitch1 = zRotation[0] / zAngle[0];
                //RULETA 1
                if (zRotation[0] != zAngle[0])
                {
                    zRotation[0] = Mathf.Lerp(zRotation[0], zAngle[0], velocityLerpStart * Time.deltaTime);
                    audioRoulette1.pitch = audioPitch1;
                }
                roulette0.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);

            }
            else
            {
                audioPitch1 = zRotation[0] / zAngle[0];
                Debug.Log(zRotation[0]);
                zRotation[0] = Mathf.Lerp(zRotation[0], 0, velocityLerp * Time.deltaTime);
                audioRoulette1.pitch = audioPitch1;
                //PARAR CUANDO LA ROTACION SEA MUY LENTA
                if (zRotation[0] < -6)
                {
                    roulette0.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                    roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                }

            }
            if (timer[1] > 0)
            {
                audioPitch2 = zRotation[1] / zAngle[1];
                //RULETA 2
                if (zRotation[1] != zAngle[1])
                {
                    zRotation[1] = Mathf.Lerp(zRotation[1], zAngle[1], velocityLerpStart * Time.deltaTime);
                    audioRoulette2.pitch = audioPitch2;
                }
                roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
            }
            else
            {
                audioPitch2 = zRotation[1] / zAngle[1];
                audioRoulette2.pitch = audioPitch2;
                zRotation[1] = Mathf.Lerp(zRotation[1], 0, velocityLerp * Time.deltaTime);
                if (zRotation[1] < -6)
                {
                    roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                    roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);

                }

            }
            if (timer[2] > 0)
            {
                audioPitch3 = zRotation[2] / zAngle[2];
                //RULETA 3
                if (zRotation[2] != zAngle[2])
                {
                    zRotation[2] = Mathf.Lerp(zRotation[2], zAngle[2], velocityLerpStart * Time.deltaTime);
                    audioRoulette3.pitch = audioPitch3;
                }

                roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
            }
            else
            {
                audioPitch3 = zRotation[2] / zAngle[2];
                audioRoulette3.pitch = audioPitch3;
                zRotation[2] = Mathf.Lerp(zRotation[2], 0, velocityLerp * Time.deltaTime);
                if (zRotation[2] < -6)
                {
                    roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                    roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                }

            }
            if (timer[3] > 0)
            {
                audioPitch4 = zRotation[3] / zAngle[3];

                //RULETA 4
                if (zRotation[3] != zAngle[3])
                {

                    zRotation[3] = Mathf.Lerp(zRotation[3], zAngle[3], velocityLerpStart * Time.deltaTime);
                    audioRoulette4.pitch = audioPitch4;
                }
                roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
            }
            else
            {
                audioPitch4 = zRotation[3] / zAngle[3];
                audioRoulette4.pitch = audioPitch4;
                zRotation[3] = Mathf.Lerp(zRotation[3], 0, velocityLerp * Time.deltaTime);
                if (zRotation[3] < -6)
                {
                    roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                    roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                }

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
        Invoke("CheckCollisionFalse", 2.2f);
        Invoke("PrintNumber", 2.5f);
        VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.winnerNumbers);
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
        Invoke("PrintSpin4Win", 6f);

        Invoke("VoiceNumbers1", 2f);
        Invoke("VoiceNumbers2", 3f);
        Invoke("VoiceNumbers3", 4f);
        Invoke("VoiceNumbers4", 5f);

    }
    void VoiceNumbers1()
    {
        switch (ball1)
        {
            case 0:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number0);
                break;
            case 1:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number1);
                break;
            case 2:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number2);
                break;
            case 3:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number3);
                break;
            case 4:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number4);
                break;
            case 5:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number5);
                break;
            case 6:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number6);
                break;
            case 7:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number7);
                break;
            case 8:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number8);
                break;
            case 9:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number9);
                break;

        }
    }
    void VoiceNumbers2()
    {
        switch (ball2)
        {
            case 0:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number0);
                break;
            case 1:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number1);
                break;
            case 2:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number2);
                break;
            case 3:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number3);
                break;
            case 4:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number4);
                break;
            case 5:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number5);
                break;
            case 6:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number6);
                break;
            case 7:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number7);
                break;
            case 8:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number8);
                break;
            case 9:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number9);
                break;

        }
    }
    void VoiceNumbers3()
    {
        switch (ball3)
        {
            case 0:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number0);
                break;
            case 1:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number1);
                break;
            case 2:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number2);
                break;
            case 3:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number3);
                break;
            case 4:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number4);
                break;
            case 5:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number5);
                break;
            case 6:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number6);
                break;
            case 7:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number7);
                break;
            case 8:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number8);
                break;
            case 9:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number9);
                break;

        }
    }
    void VoiceNumbers4()
    {
        switch (ball4)
        {
            case 0:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number0);
                break;
            case 1:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number1);
                break;
            case 2:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number2);
                break;
            case 3:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number3);
                break;
            case 4:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number4);
                break;
            case 5:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number5);
                break;
            case 6:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number6);
                break;
            case 7:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number7);
                break;
            case 8:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number8);
                break;
            case 9:
                VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.number9);
                break;

        }
    }
    public void PrintSpin4Win()
    {
        //textTop.text = "SPIN 4 WIN";

        if (spin < numberSpins)
        {
            StartSpin();
            anim.SetTrigger("ReSpin");
            animCanvas.SetTrigger("NoShow");
        }
        else
        {
            anim.SetTrigger("StopSpin");
            Invoke("NoShow", 3f);
        }
    }
    public void NoShow()
    {
        //audioSource.mute = true;
        Invoke("Outro", 1.5f);
        VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.congratulations);
        //animCanvas.SetTrigger("NoShow");
        //canvasChooseSpin.SetActive(true);
    }
    public void Outro()
    {
        playOutro.PlayOutroScene();
    }
}
