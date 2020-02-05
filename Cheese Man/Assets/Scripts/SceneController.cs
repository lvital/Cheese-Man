using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float waitSeconds;
    public Vector3 screenBounds;
    public FloorController floorPrefab;
    public TurretController turretPrefab;
    public bool fireFromEveryone = false;
    public Vector2 shootAngle;

    public Vector2 floorLenght = new Vector2(1, 10);

    private Coroutine floorCoroutine;

    // Use this for initialization
    void Start()
    {
        screenBounds = GetScreenBounds();

        float spriteSize = transform.localScale.x;

        //floorCoroutine = StartCoroutine(ToddMcFarlaner(spriteSize));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !turretPrefab.fireSameDirection)
        {
            turretPrefab.fireSameDirection = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && turretPrefab.fireSameDirection)
        {
            turretPrefab.fireSameDirection = false;
        }

    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    private IEnumerator PlatformToddMcFarlaner(float spriteSize)
    {
        WaitForSeconds wait = new WaitForSeconds(waitSeconds);

        while (true)
        {
            float randomLength = Random.Range(floorLenght.x, floorLenght.y);
            float verticalRandomPosition = UnityEngine.Random.Range(-screenBounds.y, screenBounds.y);

            for (int i = 0; i < randomLength; i++)
            {
                Vector2 AlSimmonsLocation = new Vector2(screenBounds.x + (spriteSize * i), verticalRandomPosition);

                Instantiate(floorPrefab, AlSimmonsLocation, Quaternion.identity);
            }
            yield return wait;
        }
    }
}
