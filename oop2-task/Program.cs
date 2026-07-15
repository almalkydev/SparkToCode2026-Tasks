using System;
using System.Collections.Generic;
using System.Linq;

public class Room
{
	public int RoomNumber;
	public string RoomType;
	public double PricePerNight;
	public bool IsAvailable;

	public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable)
	{
		RoomNumber = roomNumber;
		RoomType = roomType;
		PricePerNight = pricePerNight;
		IsAvailable = isAvailable;
	}

	public void DisplayRoom()
	{
		string status = IsAvailable ? "Available" : "Booked";
		Console.WriteLine($"Room {RoomNumber} | {RoomType} | OMR {PricePerNight:F2}/night | {status}");
	}
}
