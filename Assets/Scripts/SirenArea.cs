using UnityEngine;

public class SirenArea : MonoBehaviour
{
    [SerializeField] private Siren _siren;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && _siren.IsActive == false)
        {
            _siren.Activate();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _siren.Deactivate();
        }
    }
}
