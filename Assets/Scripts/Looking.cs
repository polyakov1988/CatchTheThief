using UnityEngine;

public class Looking : MonoBehaviour
{
    private readonly string _mouseX = "Mouse X";
    private readonly string _mouseY = "Mouse Y";
    
    [SerializeField] private Transform _body;
    [SerializeField] private float _speed;
    
    private void Update()
    {
        _body.Rotate(Input.GetAxis(_mouseX) * _speed * Time.deltaTime * Vector3.up);
        transform.Rotate(- Input.GetAxis(_mouseY) * _speed * Time.deltaTime * Vector3.right);
    }
}
