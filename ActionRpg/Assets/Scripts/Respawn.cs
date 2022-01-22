using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    // Update is called once per frame
    void Update()
    {
        GameObject playerObj = GameObject.Find(playerPrefab.name);

        if (playerObj == null)
        {
            GameObject newPlayerObj = Instantiate(playerPrefab);
            newPlayerObj.name = playerPrefab.name;
        }
    }
}
