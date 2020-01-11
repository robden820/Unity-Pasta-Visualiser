using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastaFunctionParameters : MonoBehaviour
{

    public static Vector3 getParameters(PastaFunctionName pasta)
    {
        Vector3 parameters = Vector3.zero;

        switch (pasta)
        {
            case PastaFunctionName.Buccoli:
                parameters.x = 200;
                parameters.y = 25;
                parameters.z = 7500;
                break;
            case PastaFunctionName.Cappelletti:
                parameters.x = 40;
                parameters.y = 120;
                parameters.z = 5000;
                break;
            case PastaFunctionName.Fusilli:
                parameters.x = 200;
                parameters.y = 25;
                parameters.z = 5000;
                break;
            case PastaFunctionName.Gigli:
                parameters.x = 150;
                parameters.y = 40;
                parameters.z = 10000;
                break;
            case PastaFunctionName.Spirali:
                parameters.x = 100;
                parameters.y = 120;
                parameters.z = 15000;
                break;
        }

        return parameters;
    }
}