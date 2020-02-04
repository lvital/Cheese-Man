using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float waitSeconds;
    public Vector3 screenBounds;
    public FloorController floorPrefab;

    private Coroutine floorCoroutine;

    // Use this for initialization
    void Start()
    {
        screenBounds = GetScreenBounds();
        floorCoroutine = StartCoroutine(ToddMcFarlaner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    private IEnumerator ToddMcFarlaner()
    {
        WaitForSeconds wait = new WaitForSeconds(waitSeconds);

        while (true)
        {
            float verticalRandomPosition = UnityEngine.Random.Range(-screenBounds.y, screenBounds.y);
            Vector2 AlSimmonsLocation = new Vector2(screenBounds.x, verticalRandomPosition);

            Instantiate(floorPrefab, AlSimmonsLocation, Quaternion.identity);

            yield return wait;
        }
    }
}
