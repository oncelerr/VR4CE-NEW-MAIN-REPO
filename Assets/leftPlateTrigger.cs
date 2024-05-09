using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftPlateTrigger : MonoBehaviour
{
    public float leftPlateWeight;

    public triggerZoneManager triggerZoneManager;

    int step = 1;

    private void OnTriggerEnter(Collider other)
    {
        //first question
        if (other.CompareTag("CO2_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 4;
            triggerZoneManager.firstQuestion();
        }
        //second question
        if (other.CompareTag("NO2_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 4;
            triggerZoneManager.secondQuestion();
        }
        //third question
        if (other.CompareTag("NH3_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 5;
            triggerZoneManager.thirdQuestion();
        }
        //fourth question
        if (other.CompareTag("H2O_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 8;
            triggerZoneManager.fourthQuestion();
        }
        if (other.CompareTag("C_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 1;
            triggerZoneManager.fourthQuestion();
        }
        //fifth question
        if (other.CompareTag("CS2_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 5;
            triggerZoneManager.fifthQuestion();
        }
        if (other.CompareTag("O2_molecule2"))
        {
            leftPlateWeight = leftPlateWeight + 6;
            triggerZoneManager.fifthQuestion();
        }
        //sixth question
        if (other.CompareTag("C2H4_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 10;
            triggerZoneManager.sixthQuestion();
        }
        if (other.CompareTag("O2_molecule3"))
        {
            leftPlateWeight = leftPlateWeight + 6;
            triggerZoneManager.sixthQuestion();
        }
        //seventh question
        if (other.CompareTag("NH3_molecule2"))
        {
            leftPlateWeight = leftPlateWeight + 7;
            triggerZoneManager.seventhQuestion();
        }
        if (other.CompareTag("O2_molecule7"))
        {
            leftPlateWeight = leftPlateWeight + 6;
            triggerZoneManager.seventhQuestion();
        }
        //eighth question
        if (other.CompareTag("C2H5OH_molecule"))
        {
            leftPlateWeight = leftPlateWeight + 17;
            triggerZoneManager.eighthQuestion();
        }
        if (other.CompareTag("O2_molecule8"))
        {
            leftPlateWeight = leftPlateWeight + 6;
            triggerZoneManager.eighthQuestion();
        }
        //ninth question
        if (other.CompareTag("H2O_molecule7"))
        {
            leftPlateWeight = leftPlateWeight + 7;
            triggerZoneManager.ninthQuestion();
        }
        if (other.CompareTag("N2_molecule1"))
        {
            leftPlateWeight = leftPlateWeight + 2;
            triggerZoneManager.ninthQuestion();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //first question
        if (other.CompareTag("CO2_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 4;
            triggerZoneManager.firstQuestion();
        }
        //second question
        if (other.CompareTag("NO2_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 4;
            triggerZoneManager.secondQuestion();
        }
        //third question
        if (other.CompareTag("NH3_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 5;
            triggerZoneManager.thirdQuestion();
        }
        //fourth question
        if (other.CompareTag("H2O_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 8;
            triggerZoneManager.fourthQuestion();
        }
        if (other.CompareTag("C_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 1;
            triggerZoneManager.fourthQuestion();
        }
        //fifth question
        if (other.CompareTag("CS2_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 5;
            triggerZoneManager.fifthQuestion();
        }
        if (other.CompareTag("O2_molecule2"))
        {
            leftPlateWeight = leftPlateWeight - 6;
            triggerZoneManager.fifthQuestion();
        }
        //sixth question
        if (other.CompareTag("C2H4_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 10;
            triggerZoneManager.sixthQuestion();
        }
        if (other.CompareTag("O2_molecule3"))
        {
            leftPlateWeight = leftPlateWeight - 6;
            triggerZoneManager.sixthQuestion();
        }
        //seventh question
        if (other.CompareTag("NH3_molecule2"))
        {
            leftPlateWeight = leftPlateWeight - 7;
            triggerZoneManager.seventhQuestion();
        }
        if (other.CompareTag("O2_molecule7"))
        {
            leftPlateWeight = leftPlateWeight - 6;
            triggerZoneManager.seventhQuestion();
        }
        //eighth question
        if (other.CompareTag("C2H5OH_molecule"))
        {
            leftPlateWeight = leftPlateWeight - 17;
            triggerZoneManager.eighthQuestion();
        }
        if (other.CompareTag("O2_molecule8"))
        {
            leftPlateWeight = leftPlateWeight - 6;
            triggerZoneManager.eighthQuestion();
        }
        //ninth question
        if (other.CompareTag("H2O_molecule7"))
        {
            leftPlateWeight = leftPlateWeight - 7;
            triggerZoneManager.ninthQuestion();
        }
        if (other.CompareTag("N2_molecule1"))
        {
            leftPlateWeight = leftPlateWeight - 2;
            triggerZoneManager.ninthQuestion();
        }
    }
}

