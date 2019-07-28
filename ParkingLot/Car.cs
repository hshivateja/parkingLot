using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        string regNo;
        string color;
        public Car(string regNo,string color)
        {
            this.regNo = regNo;
            this.color = color;
        }

        public String getRegNo()
        {
            return regNo;
        }

        public void setRegNo(String regNo)
        {
            this.regNo = regNo;
        }

        public String getColor()
        {
            return color;
        }

        public void setColor(String color)
        {
            this.color = color;
        }

        
        public String toString()
        {
            return "Car [regNo=" + regNo + ", color=" + color + "]";
        }
    }
}