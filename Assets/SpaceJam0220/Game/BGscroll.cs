﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour
{
    public float scroll_Speed = 0.1f;
    
    private MeshRenderer mesh_Renderer;
    
    private float x_Scroll;
    
    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }
    
    void scroll()
    {
        x_Scroll = Time.time * scroll_Speed;
        
        Vector2 offset = new Vector2(x_Scroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    
    // Update is called once per frame
    void Update()
    {
        scroll();
    }
    

}
