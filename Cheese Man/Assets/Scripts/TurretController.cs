using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    public float waitSeconds = 2;
    public Vector2 shootAngle;

    private Rigidbody2D rb;
    private Coroutine projectileRoutine;

    // Use this for initialization
    void Start()
    {
        projectileRoutine = StartCoroutine(ProjectileSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ProjectileSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(waitSeconds);

        while (true)
        {
            projectilePrefab.shootVector = new Vector2(shootAngle.x, shootAngle.y);
            Vector2 HellLocation = new Vector2(transform.position.x, transform.position.y);
            Instantiate(projectilePrefab, HellLocation, Quaternion.identity);

            yield return wait;
        }
    }
}
