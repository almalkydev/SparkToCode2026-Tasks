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

	// case 1
	static void AddNewRoom()
	{
		Console.WriteLine("--- Add New Room ---");

		int roomNumber = ReadPositiveInt("Enter room number: ");
		if (roomNumber == -1)
		{
			Console.WriteLine("Room number must be a positive number.");
			return;
		}

		if (rooms.Any(r => r.RoomNumber == roomNumber))
		{
			Console.WriteLine("A room with this number already exists.");
			return;
		}

		Console.Write("Enter room type (Single/Double/Suite): ");
		string roomType = Console.ReadLine();

		double price = ReadPositiveDouble("Enter price per night: ");
		if (price == -1)
		{
			Console.WriteLine("Price must be a positive number.");
			return;
		}

		Room newRoom = new Room(roomNumber, roomType, price, true);
		rooms.Add(newRoom);

		Console.WriteLine("Room added successfully!");
		newRoom.DisplayRoom();
		Console.WriteLine($"Total rooms now: {rooms.Count}");
	}

	// case 2
	static void RegisterNewGuest()
	{
		Console.WriteLine("--- Register New Guest ---");

		Console.Write("Enter guest name: ");
		string name = Console.ReadLine();

		Console.Write("Enter check-in date: ");
		string checkInDate = Console.ReadLine();

		int nights = ReadPositiveInt("Enter number of nights: ");
		if (nights == -1)
		{
			Console.WriteLine("Number of nights must be a positive number.");
			return;
		}

		string guestId = "G" + (guests.Count + 1).ToString("000");
		Guest newGuest = new Guest(guestId, name, checkInDate, nights);
		guests.Add(newGuest);

		Console.WriteLine("Guest registered successfully!");
		newGuest.DisplayGuest();
	}

	// case 3
	static void BookRoom()
	{
		Console.WriteLine("--- Book a Room for a Guest ---");

		Console.Write("Enter guest ID: ");
		string guestId = Console.ReadLine();

		Guest guest = guests.FirstOrDefault(g => g.GuestId == guestId);
		if (guest == null)
		{
			Console.WriteLine("Guest not found.");
			return;
		}

		int roomNumber = ReadPositiveInt("Enter room number to book: ");
		Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
		if (room == null)
		{
			Console.WriteLine("Room not found.");
			return;
		}

		if (!room.IsAvailable)
		{
			Console.WriteLine("Room is already booked.");
			return;
		}

		guest.RoomNumber = room.RoomNumber.ToString();
		room.IsAvailable = false;

		Console.WriteLine("Booking confirmed!");
		Console.WriteLine($"Guest: {guest.GuestName}");
		Console.WriteLine($"Room: {room.RoomNumber} ({room.RoomType}) - OMR {room.PricePerNight:F2}/night");
		Console.WriteLine($"Total nights: {guest.TotalNights}");
		Console.WriteLine($"Total cost: OMR {guest.CalculateTotalCost(rooms):F2}");
	}

	// case 4
	static void ViewAllRooms()
	{
		Console.WriteLine("--- All Rooms ---");

		if (rooms.Count == 0)
		{
			Console.WriteLine("No rooms have been added yet.");
			return;
		}

		Console.WriteLine($"Total rooms: {rooms.Count()}");
		var sortedRooms = rooms.OrderBy(r => r.RoomNumber).Select(r => r);
		foreach (Room r in sortedRooms)
		{
			r.DisplayRoom();
		}
	}

	// case 5
	static void ViewAllGuests()
	{
		Console.WriteLine("--- All Guests ---");

		if (guests.Count == 0)
		{
			Console.WriteLine("No guests have been registered yet.");
			return;
		}

		Console.WriteLine($"Total guests: {guests.Count()}");
		var sortedGuests = guests.OrderBy(g => g.GuestName);
		foreach (Guest g in sortedGuests)
		{
			g.DisplayGuest();
		}
	}
}
