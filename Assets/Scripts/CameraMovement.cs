using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private float cameraSpeed = 1;
    private float xMax;
    private float yMin;
    private float swipeThreshold;
    private Vector2 touchStartPos;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else 
            {
                Vector2 swipeDelta = touch.position - touchStartPos;

                if (Mathf.Abs(swipeDelta.x) > swipeThreshold || Mathf.Abs(swipeDelta.y) > swipeThreshold)
                {
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if (swipeDelta.x < 0)
                        {
                            // Swipe right
                            mainCamera.transform.Translate(cameraSpeed * Time.deltaTime * Vector3.right);
                            Debug.Log("Swipe right");
                        }
                        else
                        {
                            // Swipe left
                            mainCamera.transform.Translate(cameraSpeed  * Time.deltaTime * Vector3.left);
                            Debug.Log("Swipe left");
                        }
                    }
                    else
                    {
                        if (swipeDelta.y < 0)
                        {
                            // Swipe up
                            mainCamera.transform.Translate(cameraSpeed  * Time.deltaTime * Vector3.up);
                            Debug.Log("Swipe up");
                        }
                        else
                        {
                            // Swipe down
                            mainCamera.transform.Translate(cameraSpeed  * Time.deltaTime * Vector3.down);
                            Debug.Log("Swipe down");
                        }
                    }
                }
            }
        }

        // Clamp camera position
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMax), Mathf.Clamp(transform.position.y, yMin, 0), -10);

    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMax), Mathf.Clamp(transform.position.y, yMin, 0), -10);
    }

    public void SetLimits(Vector3 maxTile)
    {
        Vector3 wP = Camera.main.ViewportToWorldPoint(new Vector3(1,0));
        xMax = maxTile.x - wP.x-1;
        yMin = maxTile.y - wP.y+1;
    }
}
