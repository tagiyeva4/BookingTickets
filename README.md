# 🎟️ BookingTickets

**BookingTickets** is a modern web-based ticketing platform that allows users to browse and book tickets for various events with seat selection, secure payment, and instant PDF ticket delivery via email. The system features role-based access for Admins, Event Organizers, and Users, making it scalable and easy to manage.

---

## 🚀 Project Features

- **Role-Based Access**: Separate dashboards for Admin, Event Organizer, and Users
- **Event Management**: Organizers can create events; users see them after admin approval
- **Seat Selection**: Interactive seating layout with dynamic pricing
- **Secure Payments**: Integrated with Kapital Bank payment gateway
- **PDF Ticket Generation**: Users receive QR-coded PDF tickets after successful payment
- **Email Notification**: Automatic delivery of order confirmation and tickets
- **Blog System**: Blog posts with user comments
- **Chatbot**: Lightweight chatbot to guide users
- **Admin Panel**: Full control over events, users, blogs, and settings

---

## 🛠 Technologies and Tools

- **Backend**: ASP.NET Core 9 MVC  
- **Frontend**: HTML, CSS, JavaScript  
- **Database**: Microsoft SQL Server  
- **ORM**: Entity Framework Core  
- **Authentication**: ASP.NET Identity (Role-Based)  
- **PDF Generation**: QuestPDF  
- **QR Code**: QRCoder  
- **Image Hosting**: Cloudinary  
- **Email**: SMTP / MailKit 
- **Payments**: Kapital Bank API  
- **Architecture**: Repository Pattern, DTOs, AutoMapper, Service Layer

---

## ⚙️ Installation

Follow these steps to run the project locally:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/tagiyeva4/BookingTickets.git
Navigate to the project directory:

bash
Copy
Edit
cd BookingTickets
Install dependencies:

Use Visual Studio 2022+ or Visual Studio Code

Ensure .NET 9 SDK is installed

Configure appsettings.json:

SQL Server connection string

Kapital Bank API credentials

Cloudinary credentials

SMTP email settings

Apply database migrations:

bash
Copy
Edit
dotnet ef database update
Run the project:

bash
Copy
Edit
dotnet run
Access the site:
Open in your browser: http://localhost:5000

🤝 Contributors
Want to contribute?

Fork the repository

Create a new branch:

bash
Copy
Edit
git checkout -b my-feature
Commit your changes:

bash
Copy
Edit
git commit -m "Add new feature"
Push to your branch and open a Pull Request

📄 License
This project is licensed under the MIT License.
See the LICENSE file for details.

📬 Contact
Feel free to reach out for feedback or collaboration:

* Name: Aysu Tagiyeva
* Email: [tagizadeaysu002@gmail.com](mailto:tagizadeaysu002@gmail.com)
* GitHub: [tagiyeva4](https://github.com/tagiyeva4)
