using UnityEngine;
using UnityEngine.AI;

public class VisitorFindRandomTarget : MonoBehaviour, IFindTarget
{
    [SerializeField] float _minBound;
    [SerializeField] float _maxBound;
    public Vector3 Target { get; set; }
    private Vector3 _randomPoint;

    public void FindTarget()
    {
        RandomPoint();
        NavMeshHit hit;
        if (NavMesh.SamplePosition(_randomPoint, out hit, 5f, NavMesh.AllAreas))
        {
            Target = hit.position;
        }
        else
            FindTarget();
    }

    private void RandomPoint()
    {
        _randomPoint = new Vector3 (Random.Range(_minBound, _maxBound), 0, Random.Range(_minBound, _maxBound));
    }
}
