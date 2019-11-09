using Manager;
using UnityEngine;

namespace Controllers
{
    public class SwapButtonController : MonoBehaviour
    {
        [SerializeField] private ShapeManager shapeManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            shapeManager.ApplyOnEachShape(shape => shape.ChangeShape());
        }
    }
}
