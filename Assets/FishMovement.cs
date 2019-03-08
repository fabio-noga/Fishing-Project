﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public Vector2 pivot = new Vector2(0.5f, 0.5f);
    // Update is called once per frame
    void Update()
    {
        //if (!isWalking)
        //{
        if (!isWandering) StartCoroutine(Walking());
        //}
        /*if (!isWandering) StartCoroutine(Wander());
        if (isRotatingRight) transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        if (isRotatingLeft) transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        if (isWalking) transform.position += transform.forward * Time.deltaTime * moveSpeed;*/
    }
    IEnumerator Walking(){
        isWandering = true;
        isWalking = true;
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        int walkWait = Random.Range(1, 4);
        yield return new WaitForSeconds(walkWait);
        int turning = Random.Range(-300, 300);
        transform.Rotate(transform.up * Time.deltaTime * turning);
        isWalking = false;
        isWandering = false;
    }
    /*IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(0, 3);
        int rotateLorR = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);
        isWandering = true;
        //yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        //yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if(rotateLorR==2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }*/
}
