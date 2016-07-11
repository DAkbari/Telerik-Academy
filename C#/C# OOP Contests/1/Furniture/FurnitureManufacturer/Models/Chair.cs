﻿namespace FurnitureManufacturer.Models
{    
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair
    {
        // there is no validation
        public int NumberOfLegs { get; protected set; }

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
            this.NumberOfLegs = numberOfLegs;
        }
          
        public override string ToString()
        {
            return base.ToString() + string.Format(
                ", Legs: {0}", this.NumberOfLegs);
        }

    }
}