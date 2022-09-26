using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOutro : MonoBehaviour
{

    public void PlayOutroScene()
    {
        SceneManager.LoadScene(3);
    }
}
