using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{

    public string targetTag = "Player";
    public int rays = 8;
    public int distance = 33;
    public float angle = 40;
    public Vector3 offset;
    public Transform target;
    public NavMeshAgent Nana;
    public NaMesh movementPath;
    public PathToWaypoint pathMovement;
    AudioSource ghostAudio;

    Vector3 targetLastKnownPosition;

    private void Start() {
        ghostAudio = this.GetComponent<AudioSource>();
        ghostAudio.Play();
        ghostAudio.Pause();
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.collider.gameObject.tag == targetTag)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
                targetLastKnownPosition = target.position;
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            if (RayToScan())
            {
               Nana.enabled = true;
               movementPath.GoToTarget(target.position);   // Контакт с целью
               if(!ghostAudio.isPlaying)
                ghostAudio.UnPause();
               return;
            }
            else
            {
                if(Vector3.Distance(transform.position, targetLastKnownPosition) > 1 && Nana.enabled == true)
                {
                    movementPath.GoToTarget(targetLastKnownPosition);
                    return;
                }
                targetLastKnownPosition = Vector3.zero;
                Nana.enabled = false;
                ghostAudio.Pause();
            }
        }
        pathMovement.GoToPath();// Поиск цели...
    }
}