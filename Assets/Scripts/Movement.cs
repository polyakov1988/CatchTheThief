using UnityEngine;

public class Movement : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
    
    private void Update()
    {
        Vector3 direction = transform.forward * Input.GetAxis(_vertical) + transform.right * Input.GetAxis(_horizontal);
        
        _characterController.Move(_speed * Time.deltaTime * direction);
    }
}
