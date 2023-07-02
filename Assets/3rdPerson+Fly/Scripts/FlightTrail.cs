using UnityEngine;

public class FlightTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform playerTransform;
    public float trailLength = 10f;
    public Color startColor = Color.white;
    public Color endColor = new Color(1f, 1f, 1f, 0f);

    private float currentTrailTime;
    private float trailTimeStep;
    private int trailPointsCount;
    private bool isMoving;

    private void Start()
    {
        trailPointsCount = Mathf.RoundToInt(trailLength / Time.fixedDeltaTime);
        trailTimeStep = trailLength / trailPointsCount;

        lineRenderer.positionCount = trailPointsCount;
        lineRenderer.SetPositions(new Vector3[trailPointsCount]);

        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }

    private void Update()
    {
        isMoving = playerTransform.GetComponent<Rigidbody>().velocity.magnitude > 0.1f;
        lineRenderer.enabled = isMoving;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            currentTrailTime += Time.fixedDeltaTime;

            for (int i = 0; i < trailPointsCount; i++)
            {
                float t = currentTrailTime - i * trailTimeStep;
                float alpha = Mathf.Clamp01(1f - (t / trailLength));
                Color color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                lineRenderer.SetPosition(i, playerTransform.position - playerTransform.forward * i * trailTimeStep);
                lineRenderer.SetColors(color, color);
            }
        }
    }
}
