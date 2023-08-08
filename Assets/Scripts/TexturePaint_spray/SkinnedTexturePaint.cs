using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnedTexturePaint : MonoBehaviour
{
    public int resolution = 1024;
    [Range(0.01f, 1f)]
    public float brushSize = 0.1f;
    public Texture2D brushTexture;

    private Texture2D mainTex;
    //private MeshRenderer mr;
    private SkinnedMeshRenderer mr;

    private RenderTexture rt;

    private void Awake()
    {
        TryGetComponent(out mr);

        rt = new RenderTexture(resolution, resolution, 32);

        if (mr.material.mainTexture != null)
        {
            mainTex = mr.material.mainTexture as Texture2D;
        }
        // ���� �ؽ��İ� ���� ���, �Ͼ� �ؽ��ĸ� �����Ͽ� ���
        else
        {
            mainTex = new Texture2D(resolution, resolution);
        }

        // ���� �ؽ��� -> ���� �ؽ��� ����
        Graphics.Blit(mainTex, rt);

        // ���� �ؽ��ĸ� ���� �ؽ��Ŀ� ���
        mr.material.mainTexture = rt;

        // �귯�� �ؽ��İ� ���� ��� �ӽ� ����(red ����)
        if (brushTexture == null)
        {
            brushTexture = new Texture2D(resolution, resolution);
            for (int i = 0; i < resolution; i++)
                for (int j = 0; j < resolution; j++)
                    brushTexture.SetPixel(i, j, Color.red);
            brushTexture.Apply();
        }
    }

    private void Update()
    {
        // NOTE : �ؽ��� �������� ����� �� ��� ������Ʈ���� ����ĳ��Ʈ �˻縦 �����ϹǷ� ��ȿ�����̴�.
        // ������ ����Ϸ��� �ϳ��� ������Ʈ���� ����ĳ��Ʈ �����ϵ��� ������ �����ؾ� �Ѵ�.

        // ���콺 Ŭ�� ������ �귯�÷� �׸���
/*        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool raycast = Physics.Raycast(ray, out var hit);
            Collider col = hit.collider;

            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1f);

            // ������ ����ĳ��Ʈ�� �¾����� �׸���
            if (raycast && col && col.transform == transform)
            {
                Vector2 pixelUV = hit.lightmapCoord;
                pixelUV *= resolution;
                DrawTexture(pixelUV);
            }
        }*/
    }

    /// <summary> ���� �ؽ��Ŀ� �귯�� �ؽ��ķ� �׸��� </summary>
    public void DrawTexture(in RaycastHit hit)
    {
        Vector2 pixelUV = hit.lightmapCoord;
        pixelUV *= resolution;
        RenderTexture.active = rt; // �������� ���� Ȱ�� ���� �ؽ��� �ӽ� �Ҵ�
        GL.PushMatrix();                                  // ��Ʈ���� ���
        GL.LoadPixelMatrix(0, resolution, resolution, 0); // �˸��� ũ��� �ȼ� ��Ʈ���� ����

        float brushPixelSize = brushSize * resolution;

        // ���� �ؽ��Ŀ� �귯�� �ؽ��ĸ� �̿��� �׸���
        Graphics.DrawTexture(
            new Rect(
                pixelUV.x - brushPixelSize * 0.5f,
                (rt.height - pixelUV.y) - brushPixelSize * 0.5f,
                brushPixelSize,
                brushPixelSize
            ),
            brushTexture
        );

        GL.PopMatrix();              // ��Ʈ���� ����
        RenderTexture.active = null; // Ȱ�� ���� �ؽ��� ����
    }
}