using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        transform.Translate(cameraSpeed * Time.deltaTime, 0f, 0f);
    }
}
