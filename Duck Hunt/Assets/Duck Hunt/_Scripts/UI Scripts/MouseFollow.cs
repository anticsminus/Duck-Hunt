using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f;
    [SerializeField] private float clampAngle = 80.0f;
    private Vector3 currentRotation;
    bool visible = true;

        public static MouseFollow instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentRotation = transform.localRotation.eulerAngles;
    }

    private bool lockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        return false;
    }

    private bool unlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        return true;
    }

	private void Update ()
	{

        if (Input.GetKeyDown(KeyCode.T))
        {
            visible = lockMouse();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            visible = unlockMouse();
        }
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, -Vector3.up, 10 * Input.GetAxis("Mouse X"));
            transform.RotateAround(transform.position, transform.right, 10 * Input.GetAxis("Mouse Y"));
        }
        switch (visible)
        {
            case true: // this is commented out due to not wanting it to be tracked unless mouse click is pressed
                //transform.RotateAround(transform.position, -Vector3.up, mouseSensitivity * Input.GetAxis("Mouse X"));
                //transform.RotateAround(transform.position, transform.right, mouseSensitivity * Input.GetAxis("Mouse Y"));
                break;

            case false://free movement with mouse lock
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = -Input.GetAxis("Mouse Y");

                currentRotation.y += mouseX * mouseSensitivity * Time.deltaTime;
                currentRotation.x += mouseY * mouseSensitivity * Time.deltaTime;

                currentRotation.x = Mathf.Clamp(currentRotation.x, -clampAngle, clampAngle);

                Quaternion localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0.0f);
                transform.rotation = localRotation;
                break;
        }
    }
}




