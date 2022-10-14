using TMPro;
using UnityEngine;
using System.Collections;
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


    string[] colNames = new string[10];
    [SerializeField] float minSpeed, maxSpeed; //Velocidad m�nima y m�xima de giro de la ruleta
    [SerializeField] float minTimeToStop, maxTimeToStop; //Tiempo rotando la ruleta;
    float[] zAngle = new float[4];
    public float[] timer = new float[4];
    int[] nums = new int[4];
    bool rotating;
    bool stopSpin;
    //Testeo Lerp
    public float velocityLerp;
    public float velocityLerpStart;

    float vLerp1, vLerp2, vLerp3, vLerp4;
    float t = 0;
    public float zRotationMax;
    public float timeBrake;
    float[] zRotation = new float[4];
    bool checkCollision;
    float curX = Mathf.Infinity;
    int ball1, ball2, ball3, ball4;
    float greaterNumber;
    public bool CheckCollision { get => checkCollision; set => checkCollision = value; }

    int spin = -1;

    BoxCollider[,] allColliders = new BoxCollider[4, 10];
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
        for (int i = 0; i < colNames.Length; i++)
        {
            if (i == 0)
            {
                colNames[i] = "Cube";
            }
            else
            {
                colNames[i] = "Cube (" + i + ")";
            }

            vLerp1 = velocityLerp;
            vLerp2 = velocityLerp;
            vLerp3 = velocityLerp;
            vLerp4 = 0;
            allColliders[0, i] = roulette0Collider.transform.Find(colNames[i]).GetComponent<BoxCollider>();
            allColliders[1, i] = roulette1Collider.transform.Find(colNames[i]).GetComponent<BoxCollider>();
            allColliders[2, i] = roulette2Collider.transform.Find(colNames[i]).GetComponent<BoxCollider>();
            allColliders[3, i] = roulette3Collider.transform.Find(colNames[i]).GetComponent<BoxCollider>();
        }


        SetNumberSpins(GameManager.instance.numberSpins);
    }


    // public static int numToSection(int num)
    // {
    //     int numBottom = 5;
    //     int nSections = 10;
    //     if (num <= numBottom)
    //         return numBottom - num;

    //     else
    //         return nSections + numBottom - num;
    // }
    public static float numToAngle(int num)
    {
        float angle = 90 + (num - 5) * 36;
        return angle <= 360 ? angle : angle - 360;
    }


    public static Quaternion numToRotationCollider(int num)
    {
        switch (num)
        {
            case 0:
                return new Quaternion(0.699063838f, -0.106347486f, 0.699063838f, -0.106347486f);
            case 1:
                return new Quaternion(0.631985962f, -0.317165136f, 0.631985962f, -0.317165136f);
            case 2:
                return new Quaternion(0.503045022f, -0.496936321f, 0.503045022f, -0.496936321f);
            case 3:
                return new Quaternion(-0.32486245f, 0.628064036f, -0.32486245f, 0.628064036f);
            case 4:
                return new Quaternion(-0.11488004f, 0.697712421f, -0.11488004f, 0.697712421f);
            case 5:
                return new Quaternion(0.106347546f, 0.699063838f, 0.106347546f, 0.699063838f);
            case 6:
                return new Quaternion(0.317165136f, 0.631985962f, 0.317165136f, 0.631985962f);
            case 7:
                return new Quaternion(0.49693644f, 0.503044963f, 0.49693644f, 0.503044963f);
            case 8:
                return new Quaternion(0.628064036f, 0.32486245f, 0.628064036f, 0.32486245f);
            case 9:
                return new Quaternion(0.697712421f, 0.114880107f, 0.697712421f, 0.114880107f);

            default:
                Debug.LogError("invalid collider rotation");
                return new Quaternion(-0.11488004f, 0.697712421f, -0.11488004f, 0.697712421f);
        }
    }

    public static Quaternion numToRotation(int num)
    {
        switch (num)
        {
            case 0:
                return new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
            case 1:
                return new Quaternion(-0.321019709f, 0.321019709f, 0.630036831f, 0.630036831f);
            case 2:
                return new Quaternion(-0.110615902f, 0.110615902f, 0.698401153f, 0.698401153f);
            case 3:
                return new Quaternion(0.110615902f, -0.110615902f, 0.698401153f, 0.698401153f);
            case 4:
                return new Quaternion(0.321019709f, -0.321019709f, 0.630036831f, 0.630036831f);
            case 5:
                return new Quaternion(0.5f, -0.5f, 0.5f, 0.5f);
            case 6:
                return new Quaternion(0.630036771f, -0.630036771f, 0.321019828f, 0.321019828f);
            case 7:
                return new Quaternion(0.698401153f, -0.698401153f, 0.110615902f, 0.110615902f);
            case 8:
                return new Quaternion(0.698401153f, -0.698401153f, -0.110615768f, -0.110615768f);
            case 9:
                return new Quaternion(0.630036891f, -0.630036891f, -0.32101959f, -0.32101959f);
            default:
                Debug.LogError("Invalid rotation");
                return new Quaternion(0.630036891f, -0.630036891f, -0.32101959f, -0.32101959f);
        }
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
        state[0] = -1;
        state[1] = -1;
        state[2] = -1;
        state[3] = -1;
        /*
        timer[0] = minTimeToStop;
        timer[1] = minTimeToStop + 5;
        timer[2] = minTimeToStop + 10;
        timer[3] = minTimeToStop + 15;
        */
        switch (spin)
        {
            case -1:
                timer[0] = GameManager.instance.timeA;
                timer[1] = GameManager.instance.timeB;
                timer[2] = GameManager.instance.timeC;
                timer[3] = GameManager.instance.timeD;

                zAngle[0] = GameManager.instance.speedA;
                zAngle[1] = GameManager.instance.speedB;
                zAngle[2] = GameManager.instance.speedC;
                zAngle[3] = GameManager.instance.speedD;

                nums[0] = GameManager.instance.numA;
                nums[1] = GameManager.instance.numB;
                nums[2] = GameManager.instance.numC;
                nums[3] = GameManager.instance.numD;
                break;
            case 0:
                timer[0] = GameManager.instance.time2A;
                timer[1] = GameManager.instance.time2B;
                timer[2] = GameManager.instance.time2C;
                timer[3] = GameManager.instance.time2D;

                zAngle[0] = GameManager.instance.speed2A;
                zAngle[1] = GameManager.instance.speed2B;
                zAngle[2] = GameManager.instance.speed2C;
                zAngle[3] = GameManager.instance.speed2D;
                nums[0] = GameManager.instance.num2A;
                nums[1] = GameManager.instance.num2B;
                nums[2] = GameManager.instance.num2C;
                nums[3] = GameManager.instance.num2D;
                break;
            case 1:
                timer[0] = GameManager.instance.time3A;
                timer[1] = GameManager.instance.time3B;
                timer[2] = GameManager.instance.time3C;
                timer[3] = GameManager.instance.time3D;

                zAngle[0] = GameManager.instance.speed3A;
                zAngle[1] = GameManager.instance.speed3B;
                zAngle[2] = GameManager.instance.speed3C;
                zAngle[3] = GameManager.instance.speed3D;

                nums[0] = GameManager.instance.num3A;
                nums[1] = GameManager.instance.num3B;
                nums[2] = GameManager.instance.num3C;
                nums[3] = GameManager.instance.num3D;
                break;
            case 2:
                timer[0] = GameManager.instance.time4A;
                timer[1] = GameManager.instance.time4B;
                timer[2] = GameManager.instance.time4C;
                timer[3] = GameManager.instance.time4D;

                zAngle[0] = GameManager.instance.speed4A;
                zAngle[1] = GameManager.instance.speed4B;
                zAngle[2] = GameManager.instance.speed4C;
                zAngle[3] = GameManager.instance.speed4D;

                nums[0] = GameManager.instance.num4A;
                nums[1] = GameManager.instance.num4B;
                nums[2] = GameManager.instance.num4C;
                nums[3] = GameManager.instance.num4D;
                break;
        }

        //Randomizar tiempo de cada ruleta 
        for (int i = 0; i < zAngle.Length; i++)
        {
            //timer[i] = Random.Range(minTimeToStop, maxTimeToStop); //Por si queremos que cada ruleta tenga un tiempo de funcionamiento
            // zAngle[i] = Random.Range(minSpeed, maxSpeed); //Para variar la velocidad de cada una de las ruletas
            zRotation[i] = 0;
        }
        CheckTimer();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
                allColliders[j, i].enabled = true;
        }
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


    public static bool isApproximate(Quaternion q1, Quaternion q2, float precision)
    {
        return Mathf.Abs(Quaternion.Dot(q1, q2)) >= 1 - precision;
    }

    public static int getNumFromQuaternion(Quaternion q)
    {
        float bestProb = 0;
        int bestNum = 0;
        for (int i = 0; i < 10; i++)
        {
            Quaternion numQ = numToRotation(i);
            float prob = Mathf.Abs(Quaternion.Dot(numQ, q));
            if (bestProb < prob)
            {
                bestProb = prob;
                bestNum = i;
            }
        }
        return bestNum;
    }

    int[] state = new int[] { -1, -1, -1, -1 };
    private void Update()
    {
        if (rotating)  //Si ha empezado el giro
        {
            timer[0] -= Time.deltaTime;
            timer[1] -= Time.deltaTime;
            timer[2] -= Time.deltaTime;
            timer[3] -= Time.deltaTime;
            greaterNumber -= Time.deltaTime;
            // bool isDone = transform.rotation.x == numToAngle(GameManager.instance.numA);
            if (timer[0] > 1)
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
                Quaternion finalRot = numToRotation(nums[0]);
                int mid = nums[0] <= 5 ? nums[0] + 4 : nums[0] - 6;
                int quarter = mid <= 7 ? mid + 2 : mid - 8;
                int after = nums[0] > 0 ? nums[0] - 1 : 9;
                int before = nums[0] <= 8 ? nums[0] + 1 : 0;
                Quaternion midRot = numToRotation(mid);
                Quaternion quarterRot = numToRotation(mid);
                Quaternion afterRot = numToRotation(after);
                Quaternion beforeRot = numToRotation(before);
                Quaternion curRot = roulette0.transform.localRotation;

                if (state[0] == -1)
                {
                    // int curNum = getNumFromQuaternion(curRot);
                    if (isApproximate(curRot, afterRot, 0.001f))
                    {
                        state[0] = 1;
                    }
                    else if (zRotation[0] != 0)
                    {
                        zRotation[0] = Mathf.Lerp(zRotation[0], -50, velocityLerp / 2 * Time.deltaTime);
                        roulette0.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                        roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                    }
                }
                else
                {
                    // Debug.LogError("Speed : " + zRotation[3]);
                    if (isApproximate(curRot, finalRot, 0.001f))
                    {
                        if (zRotation[0] >= -12)
                        {
                            zRotation[0] = 0;
                            for (int i = 0; i < 10; i++)
                            {
                                state[0] = 2;
                                allColliders[0, i].enabled = false;
                            }
                        }
                    }
                    else if (zRotation[0] < -10)
                    {
                        zRotation[0] = Mathf.Lerp(zRotation[0], -10, velocityLerp * Time.deltaTime);
                    }
                    if (zRotation[0] < -6)
                    {

                        roulette0.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                        roulette0Collider.transform.Rotate(0, 0, zRotation[0] * Time.deltaTime, Space.World);
                    }
                    if (isApproximate(curRot, beforeRot, 0.001f) && zRotation[0] >= -10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            allColliders[0, i].enabled = false;
                        }
                    }
                }
                audioPitch1 = zRotation[0] / zAngle[0];
                audioRoulette1.pitch = audioPitch1;
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
                Quaternion finalRot = numToRotation(nums[1]);
                int mid = nums[1] <= 5 ? nums[1] + 4 : nums[1] - 6;
                int quarter = mid <= 7 ? mid + 2 : mid - 8;
                int after = nums[1] > 0 ? nums[1] - 1 : 9;
                int before = nums[1] <= 8 ? nums[1] + 1 : 0;
                Quaternion midRot = numToRotation(mid);
                Quaternion quarterRot = numToRotation(mid);
                Quaternion afterRot = numToRotation(after);
                Quaternion beforeRot = numToRotation(before);
                Quaternion curRot = roulette1.transform.localRotation;

                if (state[1] == -1)
                {
                    // int curNum = getNumFromQuaternion(curRot);
                    if (isApproximate(curRot, afterRot, 0.001f))
                    {
                        state[1] = 1;
                    }
                    else if (zRotation[1] != 0)
                    {
                        zRotation[1] = Mathf.Lerp(zRotation[1], -50, velocityLerp / 2 * Time.deltaTime);
                        roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                        roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                    }
                }
                else
                {
                    // Debug.LogError("Speed : " + zRotation[3]);
                    if (isApproximate(curRot, finalRot, 0.001f))
                    {
                        if (zRotation[1] >= -12)
                        {
                            state[1] = 2;
                            zRotation[1] = 0;
                            for (int i = 0; i < 10; i++)
                            {
                                allColliders[1, i].enabled = false;
                            }
                        }
                    }
                    else if (zRotation[1] < -10)
                    {
                        zRotation[1] = Mathf.Lerp(zRotation[1], -10, velocityLerp * Time.deltaTime);
                    }
                    if (zRotation[1] < -6)
                    {

                        roulette1.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                        roulette1Collider.transform.Rotate(0, 0, zRotation[1] * Time.deltaTime, Space.World);
                    }
                    if (isApproximate(curRot, beforeRot, 0.001f) && zRotation[1] >= -10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            allColliders[1, i].enabled = false;
                        }
                    }
                }

                audioPitch2 = zRotation[1] / zAngle[1];
                audioRoulette2.pitch = audioPitch2;
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
                Quaternion finalRot = numToRotation(nums[2]);
                int mid = nums[2] <= 5 ? nums[2] + 4 : nums[2] - 6;
                int quarter = mid <= 7 ? mid + 2 : mid - 8;
                int after = nums[2] > 0 ? nums[2] - 1 : 9;
                int before = nums[2] <= 8 ? nums[2] + 1 : 0;
                Quaternion midRot = numToRotation(mid);
                Quaternion quarterRot = numToRotation(mid);
                Quaternion afterRot = numToRotation(after);
                Quaternion beforeRot = numToRotation(before);
                Quaternion curRot = roulette2.transform.localRotation;

                if (state[2] == -1)
                {
                    // int curNum = getNumFromQuaternion(curRot);
                    if (isApproximate(curRot, afterRot, 0.001f))
                    {
                        state[2] = 1;
                    }
                    else if (zRotation[2] != 0)
                    {
                        zRotation[2] = Mathf.Lerp(zRotation[2], -50, velocityLerp / 2 * Time.deltaTime);
                        roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                        roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                    }
                }
                else
                {
                    // Debug.LogError("Speed : " + zRotation[3]);
                    if (isApproximate(curRot, finalRot, 0.001f))
                    {
                        if (zRotation[2] >= -12)
                        {
                            state[2] = 2;
                            zRotation[2] = 0;
                            for (int i = 0; i < 10; i++)
                            {
                                allColliders[2, i].enabled = false;
                            }
                        }
                    }
                    else if (zRotation[2] < -10)
                    {
                        zRotation[2] = Mathf.Lerp(zRotation[2], -10, velocityLerp * Time.deltaTime);
                    }
                    if (zRotation[2] < -6)
                    {

                        roulette2.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                        roulette2Collider.transform.Rotate(0, 0, zRotation[2] * Time.deltaTime, Space.World);
                    }
                    if (isApproximate(curRot, beforeRot, 0.001f) && zRotation[2] >= -10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            allColliders[2, i].enabled = false;
                        }
                    }
                }

                audioPitch3 = zRotation[2] / zAngle[2];
                audioRoulette3.pitch = audioPitch3;
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
                Quaternion finalRot = numToRotation(nums[3]);
                int mid = nums[3] <= 5 ? nums[3] + 4 : nums[3] - 6;
                int quarter = mid <= 7 ? mid + 2 : mid - 8;
                int after = nums[3] > 0 ? nums[3] - 1 : 9;
                int before = nums[3] <= 8 ? nums[3] + 1 : 0;
                Quaternion midRot = numToRotation(mid);
                Quaternion quarterRot = numToRotation(mid);
                Quaternion afterRot = numToRotation(after);
                Quaternion beforeRot = numToRotation(before);
                Quaternion curRot = roulette3.transform.localRotation;

                if (state[3] == -1)
                {
                    // int curNum = getNumFromQuaternion(curRot);
                    if (isApproximate(curRot, afterRot, 0.001f))
                    {
                        state[3] = 1;
                    }
                    else if (zRotation[3] != 0)
                    {
                        zRotation[3] = Mathf.Lerp(zRotation[3], -50, velocityLerp / 2 * Time.deltaTime);
                        roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                        roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                    }
                }
                else
                {
                    // Debug.LogError("Speed : " + zRotation[3]);
                    if (isApproximate(curRot, finalRot, 0.001f))
                    {
                        if (zRotation[3] >= -12)
                        {
                            state[3] = 2;
                            zRotation[3] = 0;
                            for (int i = 0; i < 10; i++)
                            {
                                allColliders[3, i].enabled = false;
                            }
                        }
                    }
                    else if (zRotation[3] < -10)
                    {
                        zRotation[3] = Mathf.Lerp(zRotation[3], -10, velocityLerp * Time.deltaTime);
                    }
                    if (zRotation[3] < -6)
                    {

                        roulette3.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                        roulette3Collider.transform.Rotate(0, 0, zRotation[3] * Time.deltaTime, Space.World);
                    }
                    if (isApproximate(curRot, beforeRot, 0.001f) && zRotation[3] >= -10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            allColliders[3, i].enabled = false;
                        }
                    }
                }

                audioPitch4 = zRotation[3] / zAngle[3];
                audioRoulette4.pitch = audioPitch4;
            }
            bool allDone = state[0] == 2 && state[1] == 2 && state[2] == 2 && state[3] == 2;
            if (greaterNumber < 0 && !stopSpin && allDone)
            {
                Invoke("SpinStopped", timeBrake);
                stopSpin = true;
            }
        }
    }

    private IEnumerator Rotation()
    {
        // Initialize the time variables
        float currentTime = 0f;
        float duration = 1.0f;

        // Figure out the current angle/axis
        Quaternion sourceOrientation = roulette3.transform.localRotation;
        float sourceAngle;
        Vector3 sourceAxis;
        sourceOrientation.ToAngleAxis(out sourceAngle, out sourceAxis);

        // Calculate a new target orientation
        float targetAngle = 360 + numToAngle(nums[3]); // Source +/- 1800
        Vector3 targetAxis = Random.onUnitSphere;

        while (currentTime < duration)
        {
            // Might as well wait first, especially on the first iteration where there'd be nothing to do otherwise.
            yield return null;

            currentTime += Time.deltaTime;
            float progress = currentTime / duration; // From 0 to 1 over the course of the transformation.

            // Interpolate to get the current angle/axis between the source and target.
            float currentAngle = Mathf.Lerp(sourceAngle, targetAngle, progress);
            Vector3 currentAxis = Vector3.Lerp(sourceAxis, targetAxis, progress);

            // Assign the current rotation
            roulette3.transform.localRotation = Quaternion.AngleAxis(currentAngle, currentAxis);
        }
    }

    void SpinStopped()
    {
        anim.SetTrigger("ShowNumber");
        animCanvas.SetTrigger("Show");
        rotating = false;
        stopSpin = false;
        CheckCollision = true;
        Invoke("CheckCollisionFalse", 2.8f);
        Invoke("PrintNumber", 3f);
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
            Invoke("NoShow", 0.5f);
        }
    }
    public void NoShow()
    {
        //audioSource.mute = true;
        Invoke("Outro", 0.5f);
        VoiceManager.instance.PlayVoiceManager(VoiceManager.instance.congratulations);
        //animCanvas.SetTrigger("NoShow");
        //canvasChooseSpin.SetActive(true);
    }
    public void Outro()
    {
        playOutro.PlayOutroScene();
    }
}
