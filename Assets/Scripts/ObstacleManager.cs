using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;
    public List<GameObject> obstacles;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckExplosion(Vector3 explosionPos, float radius)
    {
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            float dist = Vector3.Distance(explosionPos, obstacles[i].transform.position);

            if (dist < radius)
            {
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
            }
        }
    }
}
