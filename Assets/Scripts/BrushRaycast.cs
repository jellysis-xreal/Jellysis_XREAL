using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushRaycast : MonoBehaviour
{
    public Transform brush_ray;
    public Transform ears, head, body, body1, tail;

    public int resolution = 1024;

    public SkinnedTexturePaint ears_texturePaint, head_texturePaint, body_texturePaint, body1_texturePaint, tail_texturePaint;

/*    void Update()
    {
        Debug.DrawRay(brush_ray.position, brush_ray.forward);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(brush_ray.position, brush_ray.forward);
            
            bool raycast = Physics.Raycast(ray, out var hit);
            Collider col = hit.collider;

            if (raycast && col)
            {
                Debug.Log(col.name);
                if (col.transform == ears)
                {
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV *= resolution;
                    ears_texturePaint.DrawTexture(pixelUV);
                }
                if(col.transform == head)
                {
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV *= resolution;
                    head_texturePaint.DrawTexture(pixelUV);
                }
                if(col.transform == body)
                {
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV *= resolution;
                    body_texturePaint.DrawTexture(pixelUV);
                }
                if (col.transform == body1)
                {
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV *= resolution;
                    body1_texturePaint.DrawTexture(pixelUV);
                }
                if (col.transform == tail)
                {
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV *= resolution;
                    tail_texturePaint.DrawTexture(pixelUV);
                }


            }
        }
    }*/
}
