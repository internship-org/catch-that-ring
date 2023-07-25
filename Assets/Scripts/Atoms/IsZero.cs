using UnityAtoms.BaseAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Unity Atoms/Conditions/IsZero")]
public class IsZero : IntCondition
{
    public override bool Call(int t)
    {
        return t == 0;
    }
}
