using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    public Camera MainCamera => _mainCamera;
}
