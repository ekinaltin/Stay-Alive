using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;
    private Renderer backgroundRenderer;

    private void Awake()
    {
        backgroundRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
