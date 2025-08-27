using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstaclePool obstaclePool;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Random.Range(30f, 80f)) * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestructiveBorder"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = obstaclePool.SetRandomPosition();
        }

        else if (collision.CompareTag("Player"))
        {
            GameManager.Instance.gameOver = true;
        }
    }
}
