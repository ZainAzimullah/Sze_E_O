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
            PlayerManager player=PlayerManager.Instance;
            //Debug.Log(player.camPos);
            if (player.camAngle == Vector3.zero)
            {
                //player.camAngle = this.transform.eulerAngles;
            }
            else
            {
                //transform.eulerAngles = player.camAngle;
            }

            if (player.camPos == Vector3.zero)
            {
                //player.camPos = this.transform.position;
            }
            else
            {
                //transform.position = player.camPos;
            }

            Debug.Log("IN");

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


