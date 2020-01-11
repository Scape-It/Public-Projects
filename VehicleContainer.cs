using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VehicleContainer
    {
    Vehicle vehicle;

    public void makeShip(string type)
        {
        type = type.ToUpper();

        if (type == "CARAVEL")
            vehicle = new Caravel();
        else if (type == "KOGGE")
            vehicle = new Kogge();
        else 
            makeShip();
        }


    public void makeShip()
        {
        vehicle = new Ship();
        }


    public void setVehicle(VehicleContainer s)
        {
        vehicle = s.transferVehicle();
        }


    public Vehicle transferVehicle()
        {
        if (hasVehicle())
            {
            var result = vehicle;
            vehicle = null;
            return result;
            }
        else
            return null;
        }


    public Vehicle getVehicle()
        {
        return vehicle;
        }


    public bool hasVehicle()
        {
        if (vehicle != null)
            return true;

        return false;
        }


    [System.Serializable]
    public abstract class Vehicle : SkaldObject
        {
        protected string modelPath;
        protected bool chartered = false;

        protected Vehicle() : base() {}

        public string getModelPath()
            {
            return modelPath;
            }

        public bool isChartered()
            {
            return chartered;
            }

        public bool charterVehicle()
            {
            chartered = true;

            return chartered;
            }
        }


    [System.Serializable]
    protected class Ship : Vehicle
        {
        public Ship() : base() 
            {
            description = "A ship lies at anchor.";
            modelPath = "Models/Caravel";
            }

        public override string getDescription()
            {
            string result = base.getDescription();

            if (chartered)
                result += "\n\nThis ship has been been chartered and you may come onboard!";
            else
                result += "\n\nYou may charter this ship if you can afford it";

            return result;
            }
        }


    [System.Serializable]
    protected class Caravel : Ship
        {
        public Caravel() : base() 
            {
            description = "A caravel lies at anchor.";
            modelPath = "Models/Caravel";
            }
        }


    [System.Serializable]
    protected class Kogge : Ship
        {
        public Kogge() : base() 
            {
            description = "A kogge lies at anchor.";
            modelPath = "Models/Kogge";
            }
        }
    }


