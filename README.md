# MovieReviewPlatform
A full-stack movie review platform built using React and ASP.NET Core, designed to demonstrate secure API integration, full-stack communication, and multi-framework proficiency. Fetches data from TMDB (The Movie Database).

**Overview**

This project explores a real-world challenge: integrating a JavaScript-based frontend (React) with a C# backend (ASP.NET Core). The app fetches movie data from an external API, relays it through the backend, and renders it on the client side. The front-end UI is still under construction, but the data flow and system architecture are fully functional.

This project was created to stretch my abilities by working across two distinct frameworks—something that’s expected in many modern tech stacks.

**Technologies Used:**
- Frontend: React (JavaScript), HTML, CSS
- Backend: ASP.NET Core (C#)
- Database: LocalDB with Entity Framework Core
- External API: TMDB API
- Environment Management: .env file for secrets
- Version Control: Git & GitHub
- Tooling: Visual Studio, VS Code, .NET CLI, npm

**Features:**
- Full-stack Data Flow: API requests are initiated from React, relayed to ASP.NET Core, and returned with processed movie data.
- Movie Catalog: Displays external movie data (from API) via backend.
- Multi-Framework Integration: Demonstrates a working system across React and .NET Core.
- Secure API Key Handling: .env files used to protect sensitive credentials.

❗ **Dev Insight: Security Lesson** ❗

Early in development, I accidentally committed my API key to the public repo. Realizing the security risk:
1. I revoked the exposed key.
2. Introduced a .env file to hold sensitive values.
3. Updated .gitignore to exclude the .env.

This mistake taught me the importance of secret management in version control.

**Getting Started :)**

**Prerequisites:**
- .NET 6+ SDK
- Node.js & npm
- Visual Studio and/or VS Code

**Backend Setup (ASP.NET Core)**
1.	Clone the repository:
- git clone https://github.com/Eduard-02/MovieReviewPlatform.git

2.	Navigate to the backend directory and configure your .env:
- API_KEY=your_api_key_here

3.	Apply EF migrations:
- Update-Database

4.	Run the backend:
- dotnet run

**Frontend Setup (React)**
1.	Navigate to the client directory (or wherever your React app lives):
- cd client
- npm install
- npm start

Make sure the backend and frontend are configured to communicate (e.g., CORS settings in .NET, proxy setup in React).

**Learning Outcomes:**
- Cross-framework integration (React ↔ ASP.NET Core)
- Securely managing sensitive credentials with .env files
- Handling API calls between client, server, and third-party APIs

**Future Enhancements:**
- Finalize and polish React UI (responsive layout, reusable components)

**Contact**

Interested in collaborating, hiring, or giving feedback? Let’s connect:
- GitHub: Eduard-02
- LinkedIn: Eduardo Major Cebola
