using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TombolStart : MonoBehaviour
{
    public void Mulai()
    {
        SceneManager.LoadScene("Level 1");
    }
}