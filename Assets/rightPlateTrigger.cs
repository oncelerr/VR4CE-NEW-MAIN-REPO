using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightPlateTrigger : MonoBehaviour
{
    public triggerZoneManager triggerZoneManager;

    int stepRight = 1;

    public float rightPlateWeight;
    private void OnTriggerEnter(Collider other)
    {
        //first question
        if (other.CompareTag("O2_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 2;
            triggerZoneManager.firstQuestion();
        }
        if (other.CompareTag("CO_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 3;
            triggerZoneManager.firstQuestion();
        }
        //second question
        if (other.CompareTag("NO_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 3;
            triggerZoneManager.secondQuestion();
        }
        if (other.CompareTag("O2_molecule1"))
        {
            rightPlateWeight = rightPlateWeight + 2;
            triggerZoneManager.secondQuestion();
        }
        //third question
        if (other.CompareTag("N2_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 4;
            triggerZoneManager.thirdQuestion();
        }
        if (other.CompareTag("H2_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 2;
            triggerZoneManager.thirdQuestion();
        }
        //fourth question
        if (other.CompareTag("CH4_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 13;
            triggerZoneManager.fourthQuestion();
        }
        if (other.CompareTag("CO2_molecule1"))
        {
            rightPlateWeight = rightPlateWeight + 5;
            triggerZoneManager.fourthQuestion();
        }
        //fifth question
        if (other.CompareTag("CO2_molecule2"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.fifthQuestion();
        }
        if (other.CompareTag("SO2_molecule"))
        {
            rightPlateWeight = rightPlateWeight + 8;
            triggerZoneManager.fifthQuestion();
        }
        //sixth question
        if (other.CompareTag("H2O_molecule1"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.sixthQuestion();
        }
        if (other.CompareTag("CO2_molecule3"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.sixthQuestion();
        }
        //seventh question
        if (other.CompareTag("H2O_molecule5"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.seventhQuestion();
        }
        if (other.CompareTag("NO_molecule2"))
        {
            rightPlateWeight = rightPlateWeight + 4;
            triggerZoneManager.seventhQuestion();
        }
        //eighth question
        if (other.CompareTag("H2O_molecule6"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.eighthQuestion();
        }
        if (other.CompareTag("CO2_molecule4"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.eighthQuestion();
        }
        //ninth question
        if (other.CompareTag("NO_molecule3"))
        {
            rightPlateWeight = rightPlateWeight + 4;
            triggerZoneManager.ninthQuestion();
        }
        if (other.CompareTag("NH3_molecule3"))
        {
            rightPlateWeight = rightPlateWeight + 7;
            triggerZoneManager.ninthQuestion();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //first question
        if (other.CompareTag("O2_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 2;
            triggerZoneManager.firstQuestion();
        }
        if (other.CompareTag("CO_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 3;
            triggerZoneManager.firstQuestion();
        }
        //second question
        if (other.CompareTag("NO_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 3;
            triggerZoneManager.secondQuestion();
        }
        if (other.CompareTag("O2_molecule1"))
        {
            rightPlateWeight = rightPlateWeight - 2;
            triggerZoneManager.secondQuestion();
        }
        //third question
        if (other.CompareTag("N2_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 4;
            triggerZoneManager.thirdQuestion();
        }
        if (other.CompareTag("H2_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 2;
            triggerZoneManager.thirdQuestion();
        }
        //fourth question
        if (other.CompareTag("CH4_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 13;
            triggerZoneManager.fourthQuestion();
        }
        if (other.CompareTag("CO2_molecule1"))
        {
            rightPlateWeight = rightPlateWeight - 5;
            triggerZoneManager.fourthQuestion();
        }
        //fifth question
        if (other.CompareTag("CO2_molecule2"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.fifthQuestion();
        }
        if (other.CompareTag("SO2_molecule"))
        {
            rightPlateWeight = rightPlateWeight - 8;
            triggerZoneManager.fifthQuestion();
        }
        //sixth question
        if (other.CompareTag("H2O_molecule1"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.sixthQuestion();
        }
        if (other.CompareTag("CO2_molecule3"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.sixthQuestion();
        }
        //seventh question
        if (other.CompareTag("H2O_molecule5"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.seventhQuestion();
        }
        if (other.CompareTag("NO_molecule2"))
        {
            rightPlateWeight = rightPlateWeight - 4;
            triggerZoneManager.seventhQuestion();
        }
        //eighth question
        if (other.CompareTag("H2O_molecule6"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.eighthQuestion();
        }
        if (other.CompareTag("CO2_molecule4"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.eighthQuestion();
        }
        //ninth question
        if (other.CompareTag("NO_molecule3"))
        {
            rightPlateWeight = rightPlateWeight - 4;
            triggerZoneManager.ninthQuestion();
        }
        if (other.CompareTag("NH3_molecule3"))
        {
            rightPlateWeight = rightPlateWeight - 7;
            triggerZoneManager.ninthQuestion();
        }
    }
}
