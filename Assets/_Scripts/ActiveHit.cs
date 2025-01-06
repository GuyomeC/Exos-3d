using UnityEngine;

public class ActiveHit : MonoBehaviour
{
    [SerializeField] HitEntity _hitEntity;

    
    private void ActiveAttack()
    {

        _hitEntity.PerformAttack();
    }
}
