using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Plants : MonoBehaviour
{
    private int PlantSpwanOdds1;
    private int PlantSpwanOdds2;
    private int FlowerOdds; //4개
    private int GrassOdds; //4개
    private int TreeIsOn; //10%
    private int TreeOdds; //2개
    private int ArchitechOdds;
    private int ArchitechIsOn;
    private Transform plantsFlower;
    private Transform plantsGrass;
    private Transform PlantsTree;
    private Transform Architech;
    void Start()
    {
        
        //ArchitechIsOn = Random.Range(1, 4);
        ArchitechIsOn = 2;
        ArchitechOdds = Random.Range(1, 7);
        PlantSpwanOdds1 = Random.Range(1, 3);
        PlantSpwanOdds2 = Random.Range(1, 3);
        FlowerOdds = Random.Range(1, 5);
        GrassOdds = Random.Range(1, 5);
        TreeIsOn = Random.Range(1, 50);
        TreeOdds = Random.Range(1, 3);

        if(PlantSpwanOdds1==1){
            if(FlowerOdds==1){
                plantsFlower = transform.Find("Flower1");
                plantsFlower.gameObject.SetActive(true);
                }
            else if(FlowerOdds==2){
                plantsFlower = transform.Find("Flower2");
                plantsFlower.gameObject.SetActive(true);
                }
            else if(FlowerOdds==3){
                plantsFlower = transform.Find("Flower3");
                plantsFlower.gameObject.SetActive(true);
                }
            else if(FlowerOdds==4){
                plantsFlower = transform.Find("Flower4");
                plantsFlower.gameObject.SetActive(true);
                }
        }

        if(PlantSpwanOdds2==2){
            if(GrassOdds==1){
                plantsGrass= transform.Find("Grass1");
                plantsGrass.gameObject.SetActive(true);
                }
            else if(GrassOdds==2){
                plantsGrass = transform.Find("Grass2");
                plantsGrass.gameObject.SetActive(true);
                }
            else if(GrassOdds==3){
                plantsGrass = transform.Find("Grass3");
                plantsGrass.gameObject.SetActive(true);
                }
            else if(GrassOdds==4){
                plantsGrass = transform.Find("Grass4");
                plantsGrass.gameObject.SetActive(true);
                }
        }

        if(TreeIsOn==2){
            if(TreeOdds==1){
                PlantsTree = transform.Find("Tree1");
                PlantsTree.gameObject.SetActive(true);
            }
            else if(TreeOdds==2){
                PlantsTree = transform.Find("Tree2");
                PlantsTree.gameObject.SetActive(true);
            }
        }

        if(ArchitechIsOn==2){
            if(ArchitechOdds!=2){
                Architech = transform.Find("Fence");
                if(Architech!=null){
                    Architech.gameObject.SetActive(true);
                }

            }
            if(ArchitechOdds==2){
                Architech = transform.Find("Well");
                if(Architech!=null){
                    Architech.gameObject.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
