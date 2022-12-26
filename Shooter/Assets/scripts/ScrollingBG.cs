using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speed;
    public Renderer bgRenderer;
    public PlayerMovement player;

    void FixedUpdate()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, -player.rb.velocity.y * Time.deltaTime);
    }
}
