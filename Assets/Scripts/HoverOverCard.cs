using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverCard : MonoBehaviour
{
    public Vector3 newPos;
    public float heightIncrease = 1f;
    private Vector3 prevPos;
    private Vector3 startPosition;

    public float lerpTimeInSeconds = 1f;
    private float timeElapsed = 0;
    private bool isMouseExit = false;

    private void Start()
    {
        prevPos = startPosition = transform.position;

        newPos = new Vector3(transform.position.x, transform.position.y + heightIncrease, transform.position.z);
    }

    private void OnMouseOver()
    {
        timeElapsed += Time.deltaTime;
        float percentageComplete = timeElapsed / lerpTimeInSeconds;
        transform.position = Vector3.Lerp(startPosition, newPos, percentageComplete);
    }

    private void Update()
    {
        if (isMouseExit)
        {
            timeElapsed -= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, prevPos, 0.01f / timeElapsed);

            if (timeElapsed <= 0)
            {
                isMouseExit = false;
            }
        }
    }

    private void OnMouseExit()
    {
        isMouseExit = true;
    }
}
