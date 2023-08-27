using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CubeBoss : ExplosiveEnemy
{   
    
    public GameObject meleeEnemyPrefab;
    public int numEnemiesToSpawn = 5;
    public float spawnRadius = 10f;
    public float bombDuration = 2f;
    protected override void ExplosiveAttack()
    {
        if (_targetAttack != null)
        {
            IDamageable damageable = _targetAttack.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(typeDamage, damage);
            }
        }
    }
    
    public void OnBossDestroyed()
    {
        for (int i = 0; i < numEnemiesToSpawn; i++)
        {
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject meleeEnemy = Instantiate(meleeEnemyPrefab, transform.position, Quaternion.identity);

            Vector3 direction = (randomPosition - transform.position).normalized;
            meleeEnemy.transform.DOMove(randomPosition, bombDuration).SetEase(Ease.Linear);
        }
    }
    
    

    protected override void Die()
    { 
        DestroyGO();
       OnBossDestroyed();
       
    }
}
