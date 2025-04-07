using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public float speed = 200f; // vì UI tính theo pixel
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        move();
        rectTransform.rotation = rotationToMouse();
        //DisplayMousePosition();
    }

    private void DisplayMousePosition()
    {
        float Height = Camera.main.orthographicSize;
        float Width = Camera.main.aspect * Height;
        Vector2 mousePosition = (Vector2)Input.mousePosition;// - new Vector2(Width,Height);
        rectTransform.position = mousePosition;
    }

    private void move()
    {
        rectTransform.position += rectTransform.up * speed * Time.deltaTime;
    }
    private Quaternion rotationToMouse()
    {
        Quaternion targetRotation;
        Vector3 mousePosition = Input.mousePosition;
        if ((mousePosition - rectTransform.position).magnitude >= 1)
        {
            Vector3 direction = mousePosition - rectTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            float outAngle = rectTransform.rotation.z;
            outAngle++;
            targetRotation = Quaternion.Euler(0, 0, outAngle);
        }
        return Quaternion.RotateTowards(rectTransform.rotation, targetRotation, 300 * Time.deltaTime);
    }
}
