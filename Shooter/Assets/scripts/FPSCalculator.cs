using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCalculator : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI fpsText;
    public float deltaTime;

    private void Start()
    {
        Application.targetFrameRate = 60;
        button = GameObject.Find("BackButton");
        fpsText = button.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("FPS : " + fpsText);
    }
    void FixedUpdate()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
