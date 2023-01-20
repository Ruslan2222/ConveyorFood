using System.Collections;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [Header("FoodArray")]
    [Space]
    [SerializeField] private GameObject[] _food;

    private void Start()
    {
        StartCoroutine(FoodSpawner(30));
    }

    public IEnumerator FoodSpawner(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            int randomIndex = Random.Range(0, _food.Length);
            Instantiate(_food[randomIndex], new Vector3(6, 2, 0), Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(5f);
        }
    }

}
