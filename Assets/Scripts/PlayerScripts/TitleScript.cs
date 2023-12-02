using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI start;

    private float time = 0;
    private bool small;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5)
        {
            if (small)
            {
                start.fontSize = 50;
                time = 0;
            }
            else
            {
                start.fontSize = 40;
                time = 0;
            }
            small = !small;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }

    }
}
