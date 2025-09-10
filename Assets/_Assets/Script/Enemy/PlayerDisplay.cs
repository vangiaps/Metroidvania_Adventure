using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyListChild = new();

    public GameObject item;
    public bool isSpawn = false;
    private Vector3 pos;

    private void Start()
    {
        int count = transform.childCount;
        this.UpdateChildList();
        Transform lastChild = transform.GetChild(count - 1);
        pos = lastChild.position;
        pos.y += 0.5f;
    }
    void OnTransformChildrenChanged()
    {
        UpdateChildList();
    }
    private void Update()
    {
    }
    void UpdateChildList()
    {
        enemyListChild.Clear();
        foreach (Transform child in transform)
        {
            enemyListChild.Add(child.gameObject);
        }
        this.SpawnItem();       
    }
    void SpawnItem()
    {
        if(enemyListChild.Count == 0 && isSpawn == false)
        {
            Instantiate(item, pos , Quaternion.identity);
            isSpawn = true;
        }
    }
}
