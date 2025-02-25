using System;
					
public class Status
{
    public static void Main()
    {
        string[] orderStatuses = { "Pending", "Shipped", "Delivered", "Cancelled" };

		for (int i = 0; i < orderStatuses.Length; i++) {
			string status = orderStatuses[i];
			switch (status) {
				case "Pending":
					Console.WriteLine("Order is pending.");
					break;
				case "Shipped":
					Console.WriteLine("Order has been shipped.");
					break;
				case "Delivered":
					Console.WriteLine("Order has been delivered.");
					break;
				case "Cancelled":
					Console.WriteLine("Order has been cancelled.");
					break;
				default:
					Console.WriteLine("Unknown status.");
					break;
			}
		}
    }
}