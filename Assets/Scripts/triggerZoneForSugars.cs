using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerZoneForSugars : MonoBehaviour
{
    public GameManager gamemanager;
        
    private int sugarCount = 0;
    private int coffeeCount = 0;
    private int waterCount = 0;

    public PlaySteps playStepsScript;
    public Transform loadingFront;
    public Transform loadingFront1;
    public Transform loadingFront2;// Reference to the loadingFront object

    private Vector3 initialScale = new Vector3(0.118000001f, 0.368537456f, 0); // Initial scale of loadingFront
    private Vector3 maxScale = new Vector3(0.118000001f, 0.368537456f, 0.883581817f); // Max scale of loadingFront
    private int maxSugarCount = 250;
    private int maxCoffeeCount = 50;
    private int maxWaterCount = 400;// Maximum sugar count to reach max scale

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sugar"))
        {
            Transform sugarParent = other.transform.parent;
            if (sugarParent != null && sugarParent.CompareTag("sugarParent"))
            {
                GameObject mugObject = GameObject.FindWithTag("mug");
                if (mugObject != null)
                {
                    GameObject fillUpObject = mugObject.transform.Find("fillUp")?.gameObject;
                    GameObject fillUpObject1 = mugObject.transform.Find("fillUp1")?.gameObject;
                    GameObject fillUpObject2 = mugObject.transform.Find("fillUp2")?.gameObject;

                    if (fillUpObject != null)
                    {
                        sugarCount++;
                        Debug.Log("Sugar count: " + sugarCount);

                        // Disable the specific sugar object that entered the trigger zone
                        other.gameObject.SetActive(false);

                        if (sugarCount <= 50)
                        {
                            fillUpObject.SetActive(true);
                            Debug.Log("1st layer");
                        }

                        if (sugarCount >= 150)
                        {
                            fillUpObject1.SetActive(true);
                            Debug.Log("2nd layer");
                        }

                        if (sugarCount == 250)
                        {
                            fillUpObject2.SetActive(true);
                            Debug.Log("3rd layer");

                            playStepsScript.PlayStepIndex(6);
                            gamemanager.IncrementUniversalScore();
                        }

                        if (sugarCount > 251)
                        {
                            gamemanager.MinusUniversalScore();
                        }

                        // Increase loadingFront scale
                        IncreaseLoadingFrontScale();
                    }
                    else
                    {
                        Debug.LogWarning("fillUp object not found as a child of mug.");
                    }
                }
                else
                {
                    Debug.LogWarning("Mug object not found.");
                }
            }
        }

        if (other.CompareTag("coffee"))
        {
            Transform coffeeParent = other.transform.parent;
            if (coffeeParent != null && coffeeParent.CompareTag("coffeeParent"))
            {
                GameObject mugObject = GameObject.FindWithTag("mug");
                if (mugObject != null)
                {
                    GameObject fillUpObject3 = mugObject.transform.Find("fillUp3")?.gameObject;
                    GameObject fillUpObject4 = mugObject.transform.Find("fillUp4")?.gameObject;
                    GameObject fillUpObject5 = mugObject.transform.Find("fillUp5")?.gameObject;

                    if (fillUpObject3 != null)
                    {
                        coffeeCount++;
                        Debug.Log("Sugar count: " + coffeeCount);

                        // Disable the specific sugar object that entered the trigger zone
                        other.gameObject.SetActive(false);

                        if (coffeeCount <= 50)
                        {
                            fillUpObject3.SetActive(true);
                            Debug.Log("1st layer");
                            if (coffeeCount == 50)
                            {
                                playStepsScript.PlayStepIndex(7);
                                gamemanager.IncrementUniversalScore();
                            }
                        }
                        if (coffeeCount < 51)
                        {
                            gamemanager.MinusUniversalScore();
                        }

                            if (coffeeCount >= 150)
                        {
                            fillUpObject4.SetActive(true);
                            Debug.Log("2nd layer");
                        }

                        if (coffeeCount == 250)
                        {
                            fillUpObject5.SetActive(true);
                            Debug.Log("3rd layer");
                        }

                        IncreaseLoadingFrontScale1();
                    }
                    else
                    {
                        Debug.LogWarning("fillUp object not found as a child of mug.");
                    }
                }
                else
                {
                    Debug.LogWarning("Mug object not found.");
                }
            }
        }

        if (other.CompareTag("dupedWater"))
        {
            GameObject mugObject = GameObject.FindWithTag("mug");
            if (mugObject != null)
            {
                GameObject fillUpObject6 = mugObject.transform.Find("fillUp6")?.gameObject;
                GameObject fillUpObject7 = mugObject.transform.Find("fillUp7")?.gameObject;
                GameObject fillUpObject8 = mugObject.transform.Find("fillUp8")?.gameObject;
                GameObject fillUpObject9 = mugObject.transform.Find("fillUp9")?.gameObject;

                if (fillUpObject6 != null)
                {
                    waterCount++;
                    Debug.Log("Water count: " + waterCount);

                    // Disable the specific sugar object that entered the trigger zone
                    other.gameObject.SetActive(false);

                    if (waterCount <= 100)
                    {
                        fillUpObject6.SetActive(true);
                        Debug.Log("2nd layer");

                        // Play particle system named "smoke"
                        ParticleSystem smokeParticleSystem = mugObject.GetComponentInChildren<ParticleSystem>();
                        if (smokeParticleSystem != null)
                        {
                            smokeParticleSystem.Play();
                        }
                        else
                        {
                            Debug.LogWarning("Particle system 'smoke' not found.");
                        }
                    }

                    if (waterCount >= 200)
                    {
                        fillUpObject7.SetActive(true);
                        Debug.Log("2nd layer");
                    }

                    if (waterCount >= 300)
                    {
                        fillUpObject8.SetActive(true);
                        Debug.Log("2nd layer");
                    }

                    if (waterCount == 400)
                    {
                        fillUpObject9.SetActive(true);
                        Debug.Log("2nd layer");
                        gamemanager.IncrementUniversalScore();
                        playStepsScript.PlayStepIndex(8);
                    }

                    IncreaseLoadingFrontScale2();
                }
                else
                {
                    Debug.LogWarning("fillUp object not found as a child of mug.");
                }
            }
            else
            {
                Debug.LogWarning("Mug object not found.");
            }
        }
    }

    private void IncreaseLoadingFrontScale()
    {
        float t = (float)sugarCount / maxSugarCount;
        Vector3 newScale = Vector3.Lerp(initialScale, maxScale, t);
        loadingFront.localScale = newScale;
    }
    private void IncreaseLoadingFrontScale1()
    {
        float t = (float)coffeeCount / maxCoffeeCount;
        Vector3 newScale = Vector3.Lerp(initialScale, maxScale, t);
        loadingFront1.localScale = newScale;
    }
    private void IncreaseLoadingFrontScale2()
    {
        float t = (float)waterCount / maxWaterCount;
        Vector3 newScale = Vector3.Lerp(initialScale, maxScale, t);
        loadingFront2.localScale = newScale;
    }
}
