using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    cube.Activate();
                }
            }
        }
    }
}