# Daily Stand-up Assistant
The Daily Stand-up Assistant is a full-stack web application that helps users generate clear, structured daily stand-up reports using AI. Users simply input their notes, select a preferred template, and the system produces a polished, ready-to-use report powered by the OpenAI API.

🚀 Key Features
AI-Driven Report Generation
Converts raw notes into professional stand-up updates using AI.
Customizable Templates
Supports multiple report formats such as standard stand-ups.
User-Friendly Interface
Built with React to provide a clean and intuitive experience.
Scalable Backend Architecture
A C# ASP.NET Core Web API manages business logic and AI integration.
Clear Separation of Concerns
Frontend and backend are decoupled for maintainability and scalability.

💻 Tech Stack
Frontend
React – UI development
JavaScript (ES6+) – Async operations and logic
Fetch API – Backend communication
CSS – Styling
Backend
C# – Core programming language
.NET – Application framework
ASP.NET Core – REST API development
OpenAI API – AI-powered report generation
Swagger – API testing and documentation

⚙️ Getting Started

Follow these steps to run the project locally:

Prerequisites

Make sure you have:

Node.js (with npm)
.NET SDK (v6.0 or later)
An OpenAI API key

1. Backend Setup (server)

1. Navigate to the server folder:

cd server

2. Create a file named appsettings.Development.json and add your API key:

{
"OpenAI": {
"ApiKey": "YOUR_OPENAI_API_KEY_HERE"
}
}

3. Install dependencies and run the server:

dotnet restore
dotnet run

Backend will run on:
http://localhost:5183

2. Frontend Setup (src)

1. Open a new terminal and go to the project root:

cd ..

2. Install dependencies:

npm install

3. Start the React app:

npm start

Frontend will run on:
http://localhost:3000

🧑‍💻 Usage
1. Open http://localhost:3000 in your browser
2. Enter your daily work notes
3. Select a report template
4. Click Generate
5. View your AI-generated stand-up report instantly

🔌 API Endpoint
Generate Report
Endpoint: POST /api/Report
Description: Generates a stand-up report from user input
Request
{
"notes": "string",
"selectedTemplate": "string"
}
Response
{
"report": "Generated report text..."
}