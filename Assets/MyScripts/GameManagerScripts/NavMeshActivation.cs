using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshActivation : MonoBehaviour
{
    CharacterController characterController;
    public GameObject[] navMeshDirections; 
    // Start is called before the first frame update

    private void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActivateNavMesh();
    }

    void ActivateNavMesh()
    {
        if (characterController.myNormal == new Vector3(0, 1, 0))
        {
            navMeshDirections[0].SetActive(true);
            navMeshDirections[1].SetActive(false);
            navMeshDirections[2].SetActive(false);
            navMeshDirections[3].SetActive(false);
            navMeshDirections[4].SetActive(false);
            navMeshDirections[5].SetActive(false);

        }
        else if (characterController.myNormal == new Vector3(0, -1, 0))
        {
            navMeshDirections[0].SetActive(false);
            navMeshDirections[1].SetActive(true);
            navMeshDirections[2].SetActive(false);
            navMeshDirections[3].SetActive(false);
            navMeshDirections[4].SetActive(false);
            navMeshDirections[5].SetActive(false);
        }
        else if (characterController.myNormal == new Vector3(-1, 0, 0))
        {
            navMeshDirections[0].SetActive(false);
            navMeshDirections[1].SetActive(false);
            navMeshDirections[2].SetActive(true);
            navMeshDirections[3].SetActive(false);
            navMeshDirections[4].SetActive(false);
            navMeshDirections[5].SetActive(false);
        }
        else if (characterController.myNormal == new Vector3(1, 0, 0))
        {
            navMeshDirections[0].SetActive(false);
            navMeshDirections[1].SetActive(false);
            navMeshDirections[2].SetActive(false);
            navMeshDirections[3].SetActive(true);
            navMeshDirections[4].SetActive(false);
            navMeshDirections[5].SetActive(false);
        }
        else if (characterController.myNormal == new Vector3(0, 0, -1))
        {
            navMeshDirections[0].SetActive(false);
            navMeshDirections[1].SetActive(false);
            navMeshDirections[2].SetActive(false);
            navMeshDirections[3].SetActive(false);
            navMeshDirections[4].SetActive(true);
            navMeshDirections[5].SetActive(false);
        }
        else if (characterController.myNormal == new Vector3(0, 0, 1))
        {
            navMeshDirections[0].SetActive(false);
            navMeshDirections[1].SetActive(false);
            navMeshDirections[2].SetActive(false);
            navMeshDirections[3].SetActive(false);
            navMeshDirections[4].SetActive(false);
            navMeshDirections[5].SetActive(true);
        } 
        else
        {
            navMeshDirections[0].SetActive(true);
            navMeshDirections[1].SetActive(true);
            navMeshDirections[2].SetActive(true);
            navMeshDirections[3].SetActive(true);
            navMeshDirections[4].SetActive(true);
            navMeshDirections[5].SetActive(true);
        }
    }
}
