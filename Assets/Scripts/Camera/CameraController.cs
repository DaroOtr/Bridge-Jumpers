using UnityEngine;

namespace BridgeJumpers.CameraLogic
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _cameraSpeed;
        [SerializeField] private Vector2 _cameraOffset;
    
        private void FixedUpdate()
        {
            //if (_player.isGrounded())
            //{
            //    Vector3 originalPos = transform.position;
            //    Vector3 newPos = _player._visuals.transform.position;
            //    newPos.z += _cameraOffset.x;
            //    newPos.y += _cameraOffset.y;
            //    transform.position = Vector3.Lerp(originalPos, newPos,_cameraSpeed * Time.deltaTime);
            //}
        
            Vector3 originalPos = transform.position;
            Vector3 newPos = _player._visuals.transform.position;
            newPos.z += _cameraOffset.x;
            newPos.y += _cameraOffset.y;
            transform.position = Vector3.Lerp(originalPos, newPos,_cameraSpeed * Time.deltaTime);
        }
    }
}

