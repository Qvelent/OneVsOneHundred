using UnityEngine;
using UnityEngine.UIElements;

namespace Scripts
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float posX, posY, posZ;

        private void LateUpdate()
        {
            transform.position = player.transform.position + new Vector3(posX,posY,posZ);
        }
    }
}

