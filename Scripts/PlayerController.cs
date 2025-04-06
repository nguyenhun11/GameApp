using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerController : MonoBehaviour
{
    private GameObject Bullet; //The bullet
    public float MaxSpeed = 5f; //To move with speed
    public float acceleration = 15f; //Gia tooc
    public float friction = 15f;//ma sat
    private Vector3 velocity = Vector3.zero;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Debug.Log("Start");
        Bullet = PoolingPlayerBullet1.instance.Bullet1Prefaps;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GetComponent<PlayerHealth>().IsFainted)
        if (Time.timeScale == 0) return;
        HandleMove();
        RotationToMouse();
        ShootBullet();
        

    }
    private void HandleMove()
    {

        Vector3 inputDirection = Vector3.zero;//Vecto huong di

        if (Input.GetKey(KeyCode.W)) inputDirection.y++;
        if (Input.GetKey(KeyCode.S)) inputDirection.y--;
        if (Input.GetKey(KeyCode.D)) inputDirection.x++;
        if (Input.GetKey(KeyCode.A)) inputDirection.x--;
        inputDirection = (inputDirection.magnitude != 0) ? inputDirection.normalized : Vector3.zero;
        if (inputDirection.magnitude != 0)
        {
            velocity += inputDirection * acceleration * Time.deltaTime;
            if (velocity.magnitude > MaxSpeed)
            {
                velocity = velocity.normalized * MaxSpeed;
            }
        }
        else
        {
            float newSpeed = velocity.magnitude - (friction * Time.deltaTime);
            velocity = velocity.magnitude > 0 ? velocity.normalized * Mathf.Max(newSpeed, 0) : Vector3.zero;

        }
        transform.position += velocity * Time.deltaTime;
        OnTheScreen();
    }
    private void RotationToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
    private void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {

            GameObject bullet = PoolingPlayerBullet1.instance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            
        }
    }
    private void OnTheScreen()
    {
        float height = Camera.main.orthographicSize; //1/2 height, from center to edge
        float width = height * Camera.main.aspect; //aspect = width/height
        Renderer renderer = GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size / 2;//size of object (vector3)
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -width + size.x, width - size.x);
        pos.y = Mathf.Clamp(pos.y, -height + size.y, height - size.y);
        transform.position = pos;

    }

    
}
