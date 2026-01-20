using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMover : MonoBehaviour
{
    private IFindTarget _finder;
    private NavMeshAgent _agent;
    private Coroutine _started;

    private void Start()
    {
        _finder = GetComponent<IFindTarget>();
        _agent = GetComponent<NavMeshAgent>();
        if (_finder != null)
        {
            _finder.FindTarget();
            _agent.destination = _finder.Target;
        }
    }

    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            CheckStartedCoroutine();
        }
    }
    private void CheckStartedCoroutine()
    {
        if (_started == null)
        {
            _started = StartCoroutine(WaitToMove());
        }
    }
    private IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(Random.Range(0, 8));
        _finder.FindTarget();
        _agent.destination = _finder.Target;
        _started = null;
    }
}
