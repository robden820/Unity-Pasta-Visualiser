using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownController : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject pasta;
    private GameObject m_Pasta;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });

        m_Pasta = (GameObject) Instantiate(pasta, Vector3.zero, Quaternion.identity);
        m_Pasta.SetActive(false);
        m_Pasta.GetComponent<Pasta>().SetFunction(dropdown.value);
        m_Pasta.SetActive(true);
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        Destroy(m_Pasta);
        m_Pasta = (GameObject)Instantiate(pasta, Vector3.zero, Quaternion.identity);
        m_Pasta.SetActive(false);
        m_Pasta.GetComponent<Pasta>().SetFunction(dropdown.value);
        m_Pasta.SetActive(true);

    }
}
