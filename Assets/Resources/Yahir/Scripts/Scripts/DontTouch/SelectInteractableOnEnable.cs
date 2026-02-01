using UnityEngine;
using UnityEngine.EventSystems;

public class SelectInteractableOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    private void OnDisable()
    {
        
    }
}
