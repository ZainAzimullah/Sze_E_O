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
            Tracker tracker = player.GetTracker(LevelManager.Instance.currentLevel);
            if (tracker.camAngle == Vector3.zero)
            {
                tracker.camAngle = this.transform.eulerAngles;
            }
            else
            {
                transform.eulerAngles = tracker.camAngle;
            }

            if (tracker.camPos == Vector3.zero)
            {
                tracker.camPos = this.transform.position;
            }
            else
            {
                transform.position = tracker.camPos;
            }

            Offset = transform.position - Player.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!LevelUIManager.Instance.isCamFreeze)
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
}


