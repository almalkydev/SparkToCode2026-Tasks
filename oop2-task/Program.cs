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

class Program
{
	static List<Room> rooms = new List<Room>();
	static List<Guest> guests = new List<Guest>();

	static void Main()
	{
		LoadStartingRooms();
		RunMenu();
	}

	static void LoadStartingRooms()
	{
		rooms.Add(new Room(101, "Single", 25.00, true));
		rooms.Add(new Room(102, "Single", 25.00, true));
		rooms.Add(new Room(201, "Double", 40.00, true));
		rooms.Add(new Room(202, "Double", 40.00, true));
		rooms.Add(new Room(301, "Suite", 75.00, true));
		rooms.Add(new Room(302, "Suite", 80.00, true));
	}

	static void RunMenu()
	{
		bool running = true;
		while (running)
		{
			Console.WriteLine();
			Console.WriteLine("================================================");
			Console.WriteLine("AHMED HOTEL — MANAGEMENT SYSTEM");
			Console.WriteLine("================================================");
			Console.WriteLine(" 1. Add New Room");
			Console.WriteLine(" 2. Register New Guest");
			Console.WriteLine(" 3. Book a Room for a Guest");
			Console.WriteLine(" 4. View All Rooms");
			Console.WriteLine(" 5. View All Guests");
			Console.WriteLine(" 6. Search & Filter Rooms");
			Console.WriteLine(" 7. Guest & Booking Statistics");
			Console.WriteLine(" 8. Update Room Price");
			Console.WriteLine(" 9. Guest Lookup by Name");
			Console.WriteLine("10. Room Type Breakdown Report");
			Console.WriteLine("11. Check Out a Guest");
			Console.WriteLine("12. Remove Unavailable Rooms");
			Console.WriteLine("13. Extend Guest Stay");
			Console.WriteLine("14. Highest Revenue Booking");
			Console.WriteLine("15. Guest Pagination Viewer");
			Console.WriteLine(" 0. Exit");
			Console.WriteLine("================================================");
			Console.Write("Enter your choice: ");

			string choice = Console.ReadLine();
			Console.WriteLine();

			switch (choice)
			{
				case "1": AddNewRoom(); break;
				case "2": RegisterNewGuest(); break;
				case "3": BookRoom(); break;
				case "4": ViewAllRooms(); break;
				case "5": ViewAllGuests(); break;
				case "6": SearchAndFilterRooms(); break;
				case "7": GuestAndBookingStatistics(); break;
				case "8": UpdateRoomPrice(); break;
				case "9": GuestLookupByName(); break;
				case "10": RoomTypeBreakdownReport(); break;
				case "11": CheckOutGuest(); break;
				case "12": RemoveUnavailableRooms(); break;
				case "13": ExtendGuestStay(); break;
				case "14": HighestRevenueBooking(); break;
				case "15": GuestPaginationViewer(); break;
				case "0": running = false; Console.WriteLine("Goodbye!"); break;
				default: Console.WriteLine("Invalid choice, try again."); break;
			}
		}
	}

	// helpers

	static int ReadPositiveInt(string prompt)
	{
		Console.Write(prompt);
		int value;
		bool ok = int.TryParse(Console.ReadLine(), out value);
		if (!ok || value <= 0) return -1;
		return value;
	}

	static double ReadPositiveDouble(string prompt)
	{
		Console.Write(prompt);
		double value;
		bool ok = double.TryParse(Console.ReadLine(), out value);
		if (!ok || value <= 0) return -1;
		return value;
	}
}
