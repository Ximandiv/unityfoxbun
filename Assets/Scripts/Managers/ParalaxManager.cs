using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxManager : MonoBehaviour
{
    [SerializeField] private float backOffset;
    [SerializeField] private float midOffset;
    [SerializeField] private float frontOffset;

    [SerializeField] private Transform[] backPlane;
    [SerializeField] private Transform[] midPlane;
    [SerializeField] private Transform[] frontPlane;

    private static float _backOffset;
    private static float _midOffset;
    private static float _frontOffset;

    private static Transform[] _backPlane;
    private static Transform[] _midPlane;
    private static Transform[] _frontPlane;

    private void Awake()
    {
        _backOffset = backOffset;
        _midOffset = midOffset;
        _frontOffset = frontOffset;

        _backPlane = backPlane;
        _midPlane = midPlane;
        _frontPlane = frontPlane;
    }

    public static void DoParalax(bool? goToRight) 
    {
        if (goToRight == null) return;

        foreach(Transform plane in _backPlane) 
        {
            plane.position += (goToRight.Value ? Vector3.right : Vector3.left) * _backOffset;
        }
        foreach (Transform plane in _midPlane)
        {
            plane.position += (goToRight.Value ? Vector3.right : Vector3.left) * _midOffset;
        }
        foreach (Transform plane in _frontPlane)
        {
            plane.position += (goToRight.Value ? Vector3.right : Vector3.left) * _frontOffset;
        }        
    }

    public static IEnumerator Dashing(bool? goToRight) 
    {
        float counter = 0f;
        float final = 1f;

        while (counter < final) 
        {
            DoParalax(goToRight);

            counter += Time.fixedDeltaTime;
            yield return null;
        }
    }
}
