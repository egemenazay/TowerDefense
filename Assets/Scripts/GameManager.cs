using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject tower;
    
    public void SpawnTower(Vector3 pos)
    {
        Instantiate(tower, pos, Quaternion.identity);
    }
}
