using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipeHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject pipe;

    private List<GameObject> pipes = new List<GameObject>();


    private void Awake()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(this.Loop());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject gameObj = Instantiate(pipe, new Vector3(8, RandomNumberGenerator.GetInt32(8, 12), 0), new Quaternion());
            pipes.Add(gameObj);

            //foreach (var item in pipes)
            //{
            //    if (item.transform.position.x > 20)
            //    {
            //        Destroy(item);
            //    }

            //    pipes.Remove(item);
            //}
        }
    }
}
