using UnityEngine;
using TMPro;

public class RotateDiskLeft : MonoBehaviour
{
    private Touch touch;
    private Vector3 oldTouchPosition;
    private Vector3 NewTouchPosition;
    public TMP_Text leftText;
    private int randomNumber;
    [SerializeField]
    private float keepRotateSpeed = 10f;
    private float rotationAngle;

    private void Start()
    {
        RandomGenerator();
    }

    private void RandomGenerator()
    {
        randomNumber = Random.Range(2, 13);
        leftText.text = randomNumber.ToString();
    }

    private void Update()
    {
        RotateThings();
    }
    private void RotateThings()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                oldTouchPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                if (isDragging)
                {
                    float swipeValue = touch.position.x - oldTouchPosition;
                    if (swipeValue < 0)
                    {
                        //Disk will rotate right
                        transform.Rotate(Vector3.forward, swipeValue * 1.5f, Space.World);
                        randomNumber++;
                        if (randomNumber > 12)
                        {
                            randomNumber = 2;
                        }
                        leftText.text = randomNumber.ToString();
                    }
                    else if (swipeValue > 0)
                    {
                        //Disk will rotate left
                        transform.Rotate(Vector3.forward, swipeValue * 1.5f, Space.World);
                        randomNumber--;
                        if (randomNumber < 2)
                        {
                            randomNumber = 12;
                        }
                        leftText.text = randomNumber.ToString();
                    }

                    oldTouchPosition = touch.position.x;
                }
            }

            Vector3 rotDirection = oldTouchPosition - NewTouchPosition;
            Debug.Log(rotDirection);
            if (rotDirection.z < 0)
            {
                RotateRight();
            }
            else if (rotDirection.z > 0)
            {
                RotateLeft();
            }
        }
    }

    void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(0f, 1.5f * keepRotateSpeed, 0f) * transform.rotation;
        randomNumber--;
        leftText.text = randomNumber.ToString();
        Debug.Log("I'm decreasing");
    }

    void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0f, -1.5f * keepRotateSpeed, 0f) * transform.rotation;
        randomNumber++;
        leftText.text = randomNumber.ToString();
        Debug.Log("I'm increasing");
    }

}
