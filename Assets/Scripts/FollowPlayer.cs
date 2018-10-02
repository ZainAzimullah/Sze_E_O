using UnityEngine;

namespace FollowPlayerNamespace
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform Player;
        private Vector3 Offset;

        public bool RotateCamera = true;
        public float RotateSpeed = 4.0f;
        public bool LookAtPlayer = false;

        void Start()
        {
            Offset = transform.position - Player.position;
        }

        // Update is called once per frame
        void Update()
        {

            Quaternion cameraAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotateSpeed, Vector3.up);
            Offset = cameraAngle * Offset;

            transform.position = Player.position + Offset;
            transform.localRotation = Player.localRotation;
            transform.LookAt(Player);
        }

    }
}


