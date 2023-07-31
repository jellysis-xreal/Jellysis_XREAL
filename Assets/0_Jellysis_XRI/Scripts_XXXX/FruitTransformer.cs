using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTransformer : MonoBehaviour
{
    [SerializeField] private Transform[] placeTransforms;

    public void PlaceFruit(Transform fruitTransform)
    {
        // 과일 꽂기, placeTransforms수 만큼 반복
        for (int i = 0; i < placeTransforms.Length; i++)
        {
            if (placeTransforms[i].childCount != 0) continue;
            //SetLocalScale(fruitTransform);
            fruitTransform.SetParent(placeTransforms[i], false);
            fruitTransform.localScale =
                new Vector3(1f / placeTransforms[i].localScale.x, 1f / placeTransforms[i].localScale.y, 1f / placeTransforms[i].localScale.z);
            fruitTransform.localPosition = Vector3.zero;
            fruitTransform.localRotation = Quaternion.identity;
            return;
        }
    }

    private void SetLocalScale(Transform fruitTransform)
    {
        Vector3 calVec = new Vector3( transform.lossyScale.x/fruitTransform.lossyScale.x ,
            transform.lossyScale.y / fruitTransform.lossyScale.y,
            transform.lossyScale.z / fruitTransform.lossyScale.z);
        fruitTransform.localScale = calVec;
        Debug.Log(calVec);
    }
}
