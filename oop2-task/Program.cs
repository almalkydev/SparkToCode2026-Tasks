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

public class Guest
{
	public string GuestId;
	public string GuestName;
	public string RoomNumber; // "Not Assigned" until a room is booked
	public string CheckInDate;
	public int TotalNights;

	public Guest(string guestId, string guestName, string checkInDate, int totalNights)
	{
		GuestId = guestId;
		GuestName = guestName;
		RoomNumber = "Not Assigned";
		CheckInDate = checkInDate;
		TotalNights = totalNights;
	}

	public void DisplayGuest()
	{
		Console.WriteLine($"{GuestId} | {GuestName} | Room: {RoomNumber} | Check-in: {CheckInDate} | Nights: {TotalNights}");
	}

	// Needs rooms list for price lookup
	public double CalculateTotalCost(List<Room> rooms)
	{
		if (RoomNumber == "Not Assigned")
			return 0;

		Room room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == RoomNumber);
		if (room == null)
			return 0;

		return room.PricePerNight * TotalNights;
	}
}
