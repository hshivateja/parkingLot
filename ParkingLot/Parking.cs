using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Parking
    {

        private int noOfParkingSlots = 0;

        private List<int> availableSlotList;

        private Dictionary<int, Car> slotCarMap;

        private Dictionary<string, int> regNoCarSlotMap;

        private Dictionary<string, List<String>> colorCarMap;

        public static Parking parkingLotProcessor = null;

        //Making the class singleton
        public Parking(int noOfParkingSlots)
        {
            this.noOfParkingSlots = noOfParkingSlots;
            availableSlotList = new List<int>();

            for (int i = 1; i <= noOfParkingSlots; i++)
            {
                availableSlotList.Add(i);
            }

            slotCarMap = new Dictionary<int, Car>();
            regNoCarSlotMap = new Dictionary<string, int>();
            colorCarMap = new Dictionary<string, List<string>>();
            Console.WriteLine("Created parking lot with " + noOfParkingSlots + " slots");
            Console.WriteLine();
        }

        public static Parking createParkingLot(int noOfParkingSlots)
        {
            if (parkingLotProcessor != null)
            {
                return parkingLotProcessor;
            }
            else
            {
                parkingLotProcessor =
                        new Parking(noOfParkingSlots);
                return parkingLotProcessor;
            }

        }

        public void parkCar(Car car)
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\n");
                return;
            }
            else if (slotCarMap.Count == noOfParkingSlots)
            {
                Console.WriteLine("Sorry, parking lot is full\n");
                return;
            }
            else
            {
                availableSlotList.Sort();
                int slot = availableSlotList[0];
                slotCarMap.Add(slot, car);
                regNoCarSlotMap.Add(car.getRegNo(), slot);
                if (colorCarMap.ContainsKey(car.getColor()))
                {
                    List<String> regNoList = colorCarMap[car.getColor()];
                    colorCarMap.Remove(car.getColor());
                    regNoList.Add(car.getRegNo());
                    colorCarMap.Add(car.getColor(), regNoList);
                }
                else
                {
                    List<String> regNoList =
                            new List<String>();
                    regNoList.Add(car.getRegNo());
                    colorCarMap.Add(car.getColor(), regNoList);
                }
                Console.WriteLine("Allocated slot number: " + slot + "\n");
                availableSlotList.RemoveAt(0);
            }
        }

        public void leaveSlot(int slotNo)
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\\n");
            }
            else if (slotCarMap.Count > 0)
            {
                Car carToLeave = slotCarMap[slotNo];
                if (carToLeave != null)
                {
                    slotCarMap.Remove(slotNo);
                    regNoCarSlotMap.Remove(carToLeave.getRegNo());
                    List<String> regNoList = colorCarMap[carToLeave.getColor()];
                    if (regNoList.Contains(carToLeave.getRegNo()))
                    {
                        regNoList.Remove(carToLeave.getRegNo());
                    }
                    // Add the Lot No. back to available slot list.
                    availableSlotList.Add(slotNo);
                    Console.WriteLine("Slot number " + slotNo + " is free\n");
                }
                else
                {
                    Console.WriteLine("Slot number " + slotNo + " is already empty\n");
                }
            }
            else
            {
                Console.WriteLine("Parking lot is empty\n");
            }
        }

        public void getStatus()
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\n");
            }
            else if (slotCarMap.Count > 0)
            {
                Console.WriteLine("Slot No.\tRegistration No.\tColor\n");
                Car car;
                for (int i = 1; i <= noOfParkingSlots; i++)
                {
                    if (slotCarMap.ContainsKey(i))
                    {
                        car = slotCarMap[i];
                        Console.WriteLine(i + "\t" + car.getRegNo() + "\t" + car.getColor());
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Parking lot is empty\n");
            }
        }

        public void getRegistrationNumbersFromColor(String color)
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\n");
            }
            else if (colorCarMap.ContainsKey(color))
            {
                List<String> regNoList = colorCarMap[color];
                Console.WriteLine();
                for (int i = 0; i < regNoList.Count; i++)
                {
                    if (!(i == regNoList.Count - 1))
                    {
                        Console.WriteLine(regNoList[i] + ",");
                    }
                    else
                    {
                        Console.WriteLine(regNoList[i]);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Not found\n");
            }
        }

        public void getSlotNumbersFromColor(String color)
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\n");
            }
            else if (colorCarMap.ContainsKey(color))
            {
                List<String> regNoList = colorCarMap[color];
                List<int> slotList = new List<int>();
                Console.WriteLine();
                for (int i = 0; i < regNoList.Count; i++)
                {
                    slotList.Add(Convert.ToInt32(regNoCarSlotMap[regNoList[i]]));
                }
                slotList.Sort();
                for (int j = 0; j < slotList.Count; j++)
                {
                    if (!(j == slotList.Count - 1))
                    {
                        Console.Write(slotList[j] + ", ");
                    }
                    else
                    {
                        Console.Write(slotList[j]);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Not found\n");
            }
        }

        public void getSlotNumberFromRegNo(String regNo)
        {
            if (noOfParkingSlots == 0)
            {
                Console.WriteLine("Sorry, parking lot is not created\n");
            }
            else if (regNoCarSlotMap.ContainsKey(regNo))
            {
                Console.WriteLine(regNoCarSlotMap[regNo]);
            }
            else
            {
                Console.WriteLine("Not found\n");
            }
        }
    }
}