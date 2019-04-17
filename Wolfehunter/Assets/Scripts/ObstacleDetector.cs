using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    public Transform playerTrans;
    private Obstacle lastObstacle;

    void Start()
    {
        //		StartCoroutine(DetectPlayerObstructions());
    }

    IEnumerator DetectPlayerObstructions()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            Vector3 direction = (playerTrans.position - Camera.main.transform.position).normalized;
            RaycastHit rayCastHit;

            if (Physics.Raycast(Camera.main.transform.position, direction, out rayCastHit, Mathf.Infinity))
            {
                Obstacle Obstacle = rayCastHit.collider.gameObject.GetComponent<Obstacle>();
                if (Obstacle)
                {
                    Obstacle.SetTransparent();
                    lastObstacle = Obstacle;
                }
                else
                {
                    if (lastObstacle)
                    {
                        lastObstacle.SetToNormal();
                        lastObstacle = null;
                    }
                }
            }

        }
    }

    public void StartRayCast()
    {
        StopCoroutine("DetectPlayerObstructions");
        StartCoroutine(DetectPlayerObstructions());
    }

    public void StopRayCast()
    {
        StopCoroutine("DetectPlayerObstructions");
    }
}
