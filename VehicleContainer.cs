using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkaldRPG
{
    [System.Serializable]
    public class VehicleContainer
    {

        Vehicle vehicle;

        // https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions for all of these public methods and properties
        public void MakeShip(string type)
        {
            // You could use a switch/case here, especially if you're going to add more
            switch (type.ToUpper())
            {
                case "CARAVEL":
                    vehicle = new Caravel();
                    break;
                case "KOGGE":
                    vehicle = new Kogge();
                    break;
                default:
                    MakeShip();
                    break;
            }
        }


        public void MakeShip()
        {
            vehicle = new Ship();
        }


        public void SetVehicle(VehicleContainer s)
        {
            vehicle = s.TransferVehicle();
        }


        public Vehicle TransferVehicle()
        {
            if (this.HasVehicle)
            {
                var result = vehicle;
                vehicle = null;
                return result;
            }
            // No need for the else 
            return null;
        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }

        public bool HasVehicle => vehicle != null;


        [System.Serializable]
        public abstract class Vehicle : SkaldObject
        {
            protected Vehicle() : base() { }

            private string _modelPath = string.Empty;
            public string ModelPath
            {
                get
                {
                    return _modelPath;
                }
                set
                {
                    _modelPath = value;
                }
            }


            private bool _isChartered = false;
            public bool IsChartered
            {
                get
                {
                    return _isChartered;
                }

                set
                {
                    _isChartered = value;
                }
            }

            public void CharterVehicle()
            {
                IsChartered = true;
            }
        }


        [System.Serializable]
        protected class Ship : Vehicle
        {
            public Ship() : base()
            {
                description = "A ship lies at anchor.";
                ModelPath = "Models/Caravel";
            }

            public override string getDescription()
            {
                string result = base.getDescription();

                result += IsChartered ? "\n\nThis ship has been chartered and you may come onboard!" : "\n\nYou may charter this ship if you can afford it";

                return result;
            }
        }


        [System.Serializable]
        protected class Caravel : Ship
        {
            public Caravel() : base()
            {
                description = "A caravel lies at anchor.";
                ModelPath = "Models/Caravel";
            }
        }


        [System.Serializable]
        protected class Kogge : Ship
        {
            public Kogge() : base()
            {
                description = "A kogge lies at anchor.";
                ModelPath = "Models/Kogge";
            }
        }
    }
} 
