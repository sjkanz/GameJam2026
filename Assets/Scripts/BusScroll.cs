using UnityEngine;

public class BusScroll : MonoBehaviour
{
    public float speed = 5f;
    public float resetPositionX = -1f; // -20f
    public float startPositionX = 1f;  // 20f

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}