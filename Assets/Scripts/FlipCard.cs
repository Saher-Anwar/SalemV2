using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public float FlipSpeed = 1;

    Vector3 initialRotation;
    Vector3 targetRotation;

    private float timeElapsed = 0f;
    private bool isClicked = false;
   
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = this.gameObject.transform.eulerAngles;
        targetRotation = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z + 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            Flip();

            if (timeElapsed >= FlipSpeed)
            {
                ResetVariables();
            }
        }
    }

    private void Flip()
    {
        timeElapsed += Time.deltaTime;
        float percentageComplete = timeElapsed / FlipSpeed;
        transform.eulerAngles = Vector3.Lerp(initialRotation, targetRotation, percentageComplete);
    }

    private void ResetVariables()
    {
        initialRotation = gameObject.transform.eulerAngles;
        targetRotation = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z + 180);
        timeElapsed = 0;
        isClicked = false;
    }

    private void OnMouseDown()
    {
        isClicked = true;
    }
}
