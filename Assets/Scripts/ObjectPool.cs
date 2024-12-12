using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Havuzda kullanılacak prefab
    public int poolSize = 10; // Havuzdaki maksimum nesne sayısı

    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    private void Start()
    {
        // Havuzu önceden nesnelerle doldur
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false); // Nesneyi devre dışı bırak
            enemyPool.Enqueue(obj); // Havuza ekle
        }
    }

    public GameObject GetEnemy()
    {
        // Havuzda kullanılabilir bir nesne varsa al
        if (enemyPool.Count > 0)
        {
            GameObject obj = enemyPool.Dequeue();
            obj.SetActive(true); // Nesneyi etkinleştir
            return obj;
        }
        return null; // Havuz boşsa null döndür
    }

    public void ReturnEnemy(GameObject obj)
    {
        obj.SetActive(false); // Nesneyi devre dışı bırak
        enemyPool.Enqueue(obj); // Havuza geri koy
    }
}
