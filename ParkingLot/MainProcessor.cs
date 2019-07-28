using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class MainProcessor
    {
        Parking parking = null;
        public MainProcessor()
        {

        }

        public string findcommand(string st)
        {
            if (st == "create_parking_lot")
                return "CREATE";
            else if (st == "park")
                return "PARK";
            else if (st == "leave")
                return "LEAVE";
            else if (st == "status")
                return "STATUS";
            else if (st == "registration_numbers_for_cars_with_colour")
                return "FETCH_CAR_FROM_COLOR";
            else if (st == "slot_numbers_for_cars_with_colour")
                return "FETCH_SLOT_FROM_COLOR";
            else if (st == "slot_number_for_registration_number")
                return "FETCH_SLOT_FROM_REG_NO";
            return null;
        }
        public void validateandprocess(string str)
        {
            string[] strings = str.Split(' ');
            string command = findcommand(strings[0]);
            switch(command)
            {
                case "CREATE":
                    if (strings.Length != 2)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    int noOfPrakingSlots = int.Parse(strings[1]);
                    parking = Parking.createParkingLot(noOfPrakingSlots);
                    break;
                case "PARK":
                    if (strings.Length != 3)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    String regNo = strings[1];
                    String color = strings[2];
                    parking.parkCar(new Car(regNo, color));
                    break;
                case "LEAVE":
                    if (strings.Length != 2)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    int slotNo = int.Parse(strings[1]);
                    parking.leaveSlot(slotNo);
                    break;
                case "STATUS":
                    if (strings.Length != 1)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    parking.getStatus();
                    break;
                case "FETCH_CAR_FROM_COLOR":
                    if (strings.Length != 2)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    parking.getRegistrationNumbersFromColor(strings[1]);  //color
                    break;
                case "FETCH_SLOT_FROM_COLOR":
                    if (strings.Length != 2)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    parking.getSlotNumbersFromColor(strings[1]);  //color
                    break;
                case "FETCH_SLOT_FROM_REG_NO":
                    if (strings.Length != 2)
                    {
                        throw new Exception("Invalid no of arguments for command : " + command);
                    }
                    parking.getSlotNumberFromRegNo(strings[1]);  //regNo
                    break;
            }
        }

        public virtual void Process()
        {

        }
    }
}
