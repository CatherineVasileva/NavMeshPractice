using UnityEngine;

public class VisitorFindTarget : MonoBehaviour, IFindTarget
{
    [SerializeField] Transform[] targets;
    public Vector3 Target { get; set; }

    public void FindTarget()
    {
        var numberOfTarget = Random.Range(0, targets.Length);
        Target = targets[numberOfTarget].position;
    }
}
