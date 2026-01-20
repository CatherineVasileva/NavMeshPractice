using UnityEngine;
using UnityEngine.AI;

public class VisitAnimController : MonoBehaviour
{
    private const string Dance = "Dance";
    private int _dancefloorZoneIndex =3;
    private Animator _agentAnimator;
    private NavMeshAgent _agent;
    private Vector3 _currentTarget;

    void Start()
    {
        _agentAnimator = GetComponent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _currentTarget = _agent.destination;
        }

        if (_agent.destination == _currentTarget)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(_agent.transform.position, out hit, 1.5f, NavMesh.AllAreas))
            {
                int areaIndex = 0;
                int tempMask = hit.mask;

                while (tempMask > 1) 
                {
                    tempMask >>= 1;
                    areaIndex++; 
                }

                if (_dancefloorZoneIndex == areaIndex)
                {
                    _agentAnimator.SetBool(Dance, true);
                }
            }
        }
        else
            _agentAnimator.SetBool(Dance, false);

    }
}
