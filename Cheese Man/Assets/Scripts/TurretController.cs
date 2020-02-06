using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public float waitSeconds = 2;

    

    private Rigidbody2D rb;
    private Coroutine projectileRoutine;
    private Vector2 shootAngle;

    // Use this for initialization
    void Start()
    {
        projectileRoutine = StartCoroutine(ProjectileSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        shootAngle = new Vector2(FindObjectOfType<SceneController>().shootAngle.x, FindObjectOfType<SceneController>().shootAngle.y);
        if (FindObjectOfType<SceneController>().fireSameDirection && !FindObjectOfType<SceneController>().fireIndividualDirection)
        {
            projectilePrefab.shootVector = new Vector2(shootAngle.x, shootAngle.y);
        }
        else if (!FindObjectOfType<SceneController>().fireSameDirection && FindObjectOfType<SceneController>().fireIndividualDirection)
        {
            projectilePrefab.shootVector = new Vector2(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2));
        }
    }

    private IEnumerator ProjectileSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(waitSeconds);

        while (true)
        {
            //projectilePrefab.shootVector = new Vector2(shootAngle.x, shootAngle.y);
            Vector2 HellLocation = new Vector2(transform.position.x, transform.position.y);
            Instantiate(projectilePrefab, HellLocation, Quaternion.identity);

            yield return wait;
        }


    }
}
