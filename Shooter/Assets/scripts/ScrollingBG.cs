using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speed;
    public Renderer bgRenderer;
    public PlayerMovement player;
    public CameraMovement camera2;

    void FixedUpdate()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, camera2.changeInY * Time.deltaTime);
    }
}
