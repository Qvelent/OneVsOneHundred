using UnityEngine;

namespace Scripts
{
    public class Rigidbodytizer : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public bool rbOn;
        public MeshRenderer _renderer;
    
        private void OnCollisionEnter()
        {
            if (_rigidbody == null && rbOn == false)
            {
                gameObject.AddComponent<Rigidbody>();
                rbOn = true;
            }
            else
            {
                var material = _renderer.material;
                material.color = new Color(0,1,1,1);
            }
        }
    }
}
