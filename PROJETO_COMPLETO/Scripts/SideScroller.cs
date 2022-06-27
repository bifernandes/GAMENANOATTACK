using UnityEngine;

public class SideScroller : MonoBehaviour
{
    private Rigidbody2D sceneRb;
    private static float sceneSpeed = 50f;

    private void Awake()
    {
        sceneRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        sceneRb.velocity = new Vector2(-sceneSpeed * Time.deltaTime, 0);        
    }

    public static float SetSceneSpeed(float val)
    {
        sceneSpeed = val;
        return sceneSpeed;
    }
}
